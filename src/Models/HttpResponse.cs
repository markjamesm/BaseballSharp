using System.Net;

namespace BaseballSharp.Models;

public class HttpResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T deserializedObject { get; set; } = default!;
    public string jsonResponse { get; set; } = default!;

    public bool IsError { get; set; }
    public string AdditionalInformation { get; set; } = default!;
    public string ExceptionMsg { get; set; } = default!;
}