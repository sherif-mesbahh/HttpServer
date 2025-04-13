using HTTPServer.HTTPRequest;
using HTTPServer.HTTPResponse;
using System.Net;
using System.Net.Sockets;

namespace HTTPServer.HTTPListener;
public class HttpListener
{
	public HttpListener() { }
	public TcpListener Listener = new TcpListener(IPAddress.Any, 8080);

	public void Start()
	{
		Listener.Start();
		while (true)
		{
			using TcpClient client = Listener.AcceptTcpClient();
			using NetworkStream stream = client.GetStream();
			RequestHandler.Handle(stream); //In the future, I will use  multi-threading
										   //Map to endpoint
			ResponseHandler.Handle(stream);
		}
	}

}