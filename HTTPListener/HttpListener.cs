using HTTPServer.HTTPRequest;
using HTTPServer.HTTPResponse;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HTTPServer.HTTPListener;

public class HttpListener(int port)
{
	private readonly TcpListener _listener = new(IPAddress.Any, port);
	private bool _running = false;
	private readonly SemaphoreSlim _connectionLimiter = new SemaphoreSlim(10);
	public async Task Start()
	{
		_running = true;
		_listener.Start();
		while (_running)
		{
			await _connectionLimiter.WaitAsync();

			TcpClient client = await _listener.AcceptTcpClientAsync();

			var startTime = DateTime.UtcNow;

			Console.WriteLine($"[Task Started at {startTime:HH:mm:ss.fff}");

			_ = Task.Run(async () =>
			{
				try
				{
					await HandleClientAsync(client);
				}
				finally
				{
					_connectionLimiter.Release();
				}
			});
		}
	}

	private async Task HandleClientAsync(TcpClient client)
	{
		try
		{
			using (client)
			await using (var stream = client.GetStream())
			{
				var requestBytes = new byte[4096];
				var bytesRead = await stream.ReadAsync(requestBytes, 0, requestBytes.Length);
				if (bytesRead == 0) return;

				var request = RequestHandler.Handle(Encoding.UTF8.GetString(requestBytes, 0, bytesRead));
				Console.WriteLine(request);
				await ResponseHandler.Post(stream, ResponseHandler.Result(request));
				_ = Task.Run(async () =>
				{
					await Task.Delay(5000);
					Console.WriteLine($"Task Completed background work for {request.Path}");
				});
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Client error: {ex}");
		}
	}
}