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
    private static readonly Uri BaseUrl = new("https://statsapi.mlb.com/api/v1/");
    public async Task<HttpResponse<T>> GetResponseAsync<T>(string endpoint, CancellationToken ct)
    {
        var httpResponse = new HttpResponse<T>();
        
        try
        {
            using var httpClient = new HttpClient {BaseAddress = BaseUrl};
            var returnMessage = await httpClient.GetAsync(endpoint, ct).ConfigureAwait(false);
            
            httpResponse.StatusCode = returnMessage.StatusCode;
            if (returnMessage.IsSuccessStatusCode)
            {
                try
                {
                    httpResponse.jsonResponse = await returnMessage.Content.ReadAsStringAsync(ct);
                }
                catch (Exception ex)
                {
                    httpResponse.jsonResponse = "";
                    httpResponse.IsError = true;
                    httpResponse.ExceptionMsg = ex.Message;
                    httpResponse.AdditionalInformation = "Error during reading response as string from http response content";
                    return httpResponse;
                }


                try
                {
                    var options = new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        NumberHandling = JsonNumberHandling.AllowReadingFromString,
                        IncludeFields = true,
                        PropertyNameCaseInsensitive = true
                    };
                    httpResponse.deserializedObject = JsonSerializer.Deserialize<T>(httpResponse.jsonResponse, options);
                }
                catch (ArgumentNullException ex)
                {
                    httpResponse.IsError = true;
                    httpResponse.ExceptionMsg = ex.Message;
                    httpResponse.AdditionalInformation = "Tried to deserialize from null.";
                }
                catch (JsonException ex)
                {
                    httpResponse.IsError = true;
                    httpResponse.ExceptionMsg = ex.Message;
                    httpResponse.AdditionalInformation = "Error during deserializing response to object from json sting";
                }
                catch (Exception ex)
                {
                    httpResponse.IsError = true;
                    httpResponse.ExceptionMsg = ex.Message;
                    httpResponse.AdditionalInformation = "Unexpected error";
                }
            }
            else
            {
                httpResponse.IsError = true;
                httpResponse.AdditionalInformation = "Not expected incorrect response code - received no 200";
            }
        }
        catch (Exception ex)
        {
            httpResponse.IsError = true;
            httpResponse.AdditionalInformation = "Unknown internal error";
            httpResponse.ExceptionMsg = ex.Message;
        }


        return httpResponse;
    }
}