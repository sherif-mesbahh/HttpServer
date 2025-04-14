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
	public void Start()
	{
		_running = true;
		_listener.Start();
		while (_running)
		{
			TcpClient client = _listener.AcceptTcpClient();
			HandleClient(client);
		}
		_running = false;
		_listener.Stop();
	}

	private void HandleClient(TcpClient client)
	{
		using (client)
		using (NetworkStream stream = client.GetStream())
		{
			var requestBytes = new byte[4096];
			var bytesRead = stream.Read(requestBytes, 0, requestBytes.Length);
			if (bytesRead == 0) return;
			var request = RequestHandler.Handle(Encoding.UTF8.GetString(requestBytes, 0, bytesRead));
			var response = ResponseHandler.Result(request);
			ResponseHandler.Post(stream, response);
		}
	}
}