namespace HTTPServer.HTTPRequest;
public class RequestHandler
{
	public static Request Handle(string msg)
	{
		var tokens = msg.Split(' ');
		var method = tokens[0];
		var path = tokens[1];
		var host = tokens[3].Substring(0, tokens[3].IndexOf('\r'));
		var request = RequestFactory.Create(method, path, host);
		return request;
	}
}