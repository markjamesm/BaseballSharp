using System.Net;

namespace BaseballSharp.Models;

public class HttpResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T? deserializedObject { get; set; }
    public string jsonResponse { get; set; }

    public string AdditionalInformation { get; set; }
    public string ExceptionMsg { get; set; }
}