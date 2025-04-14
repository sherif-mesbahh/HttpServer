namespace HTTPServer.HTTPRequest;
public class RequestFactory
{
	public static Request Create(string method, string path, string host)
	{
		return new Request(method, path, host);
	}
}