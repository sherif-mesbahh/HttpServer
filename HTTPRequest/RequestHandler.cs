using System.Net.Sockets;
using System.Text;

namespace HTTPServer.HTTPRequest;
public class RequestHandler
{
	public static void Handle(NetworkStream stream)
	{
		var requestBytes = new byte[4096];
		var bytesRead = stream.Read(requestBytes, 0, requestBytes.Length);
		var request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
		Console.WriteLine(request);
	}
}