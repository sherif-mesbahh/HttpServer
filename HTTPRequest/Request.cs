namespace HTTPServer.HTTPRequest;
public class Request(string method, string path, string host)
{
	public string Method { get; set; } = method;
	public string Host { get; set; } = host;
	public string Path { get; set; } = path;
}