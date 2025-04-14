namespace HTTPServer.HTTPResponse;
public class ResponseFactory
{
	public static Response Create(string status, string mime, Byte[] data)
	{
		return new Response(status, mime, data);
	}
}