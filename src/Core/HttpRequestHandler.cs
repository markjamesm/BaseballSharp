using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using BaseballSharp.Models;

namespace BaseballSharp.Core;

public class HttpRequestHandler
{
    private static readonly Uri baseUrl = new("https://statsapi.mlb.com/api/v1");
    public async Task<HttpResponse<T>> GetResponseAsync<T>(string endpoint, CancellationToken ct)
    {
        var httpResponse = new HttpResponse<T>();
        
        try
        {
            using (var httpClient = new HttpClient() {BaseAddress = baseUrl})
            {
                var returnMessage = await httpClient.GetAsync(endpoint, ct).ConfigureAwait(false);
                httpResponse.StatusCode = returnMessage.StatusCode;
                if (returnMessage.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions()
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    };
                    httpResponse.jsonResponse = await returnMessage.Content.ReadAsStringAsync(ct);
                    httpResponse.deserializedObject = JsonSerializer.Deserialize<T>(httpResponse.jsonResponse, options);
                }
                else
                {
                    httpResponse.AdditionalInformation = "Not expected incorrect response code - not 200";
                }
            }
        }
        catch (Exception ex)
        {
            httpResponse.AdditionalInformation = "Unknown internal error";
            httpResponse.ExceptionMsg = ex.Message;
        }


        return httpResponse;
    }
}