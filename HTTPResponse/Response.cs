namespace HTTPServer.HTTPResponse;
public class Response(string status, string mime, Byte[] data)
{
	public Byte[] Data = data;
	public string Status = status;
	public string Mime = mime;
}
