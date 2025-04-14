using HTTPServer.HTTPRequest;
using System.Net.Sockets;
using System.Text;

namespace HTTPServer.HTTPResponse;
public class ResponseHandler
{
	public static Response Result(Request? request)
	{
		if (request == null)
			return HandleNotFoundRequest();

		if (request.Method == "GET")
		{
			if (request.Path == "/")
				return HandleOkRequest();

			if (request.Path == "/home")
				return HandleHomePathRequest();
		}
		return HandleNotFoundRequest();
	}

	private static Response HandleHomePathRequest()
	{
		string res = "<h1>Welcome to my home</h1>";
		byte[] data = Encoding.UTF8.GetBytes(res);
		var response = ResponseFactory.Create("200 Ok", "text/html", data);
		return response;
	}

	private static Response HandleNotFoundRequest()
	{
		//byte[] data = Encoding.UTF8.GetBytes(res);
		var response = ResponseFactory.Create("404 Not Found", "text/html", []);
		return response;
	}
	private static Response HandleOkRequest()
	{
		string res = "<h1>Welcome to my server</h1>";
		byte[] data = Encoding.UTF8.GetBytes(res);
		var response = ResponseFactory.Create("200 Ok", "text/html", data);
		return response;
	}
	public static void Post(NetworkStream stream, Response response)
	{
		using (StreamWriter writer = new StreamWriter(stream, leaveOpen: true))
		{
			writer.Write(
				$"HTTP/1.1 {response.Status}\r\n" +
				$"Server: Sherif Mesbah\r\n" +
				$"Content-Type: {response.Mime}\r\n" +
				$"Accept-Ranges: bytes\r\n" +
				$"Content-Length: {response.Data.Length}\r\n" +
				"\r\n");
			writer.Flush();
		}

		stream.Write(response.Data, 0, response.Data.Length);
	}
}
