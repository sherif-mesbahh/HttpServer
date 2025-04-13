using System.Net.Sockets;
using System.Text;

namespace HTTPServer.HTTPResponse;
public class ResponseHandler
{
	public static void Handle(NetworkStream stream)
	{
		var response = "HTTP/1.1 200 OK\r\nContent-Type: text/html\r\n\r\n<h1>Welcome to my server</h1>";
		byte[] responseBytes = Encoding.UTF8.GetBytes(response);
		stream.Write(responseBytes, 0, responseBytes.Length);
		Console.WriteLine(response);
	}
}
