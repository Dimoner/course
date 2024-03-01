using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.HttpLogic.Services.Interfaces;

namespace ProjectCore.HttpLogic.Services;

public enum ContentType
{
    ///
    Unknown = 0,

    ///
    ApplicationJson = 1,

    ///
    XWwwFormUrlEncoded = 2,

    ///
    Binary = 3,

    ///
    ApplicationXml = 4,

    ///
    MultipartFormData = 5,

    /// 
    TextXml = 6,

    /// 
    TextPlain = 7,

    ///
    ApplicationJwt = 8
}

public record HttpRequestData
{
    /// <summary>
    /// Тип метода
    /// </summary>
    public HttpMethod Method { get; set; }

    /// <summary>
    /// Адрес http + dns + path
    /// </summary>
    [Obsolete("Используй св-во Uri")]
    public string Url { get; set; }

    /// <summary>
    /// Адрес запроса
    /// </summary>
    /// <remarks>
    /// Значение здесь затрёт значение в <see cref="Url"/>, если оно там будет
    /// </remarks>
    public Uri Uri { set; get; }

    /// <summary>
    /// Тело метода
    /// </summary>
    public object Body { get; set; }
    
    /// <summary>
    /// content-type, указываемый при запросе
    /// </summary>
    public ContentType ContentType { get; set; } = ContentType.ApplicationJson;

    /// <summary>
    /// Заголовки, передаваемые в запросе
    /// </summary>
    public IDictionary<string, string> HeaderDictionary { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Параметры запроса
    /// </summary>
    [Obsolete("Используй QueryParameterList")]
    public IDictionary<string, string> QueryParameterDictionary { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Запрос будет сформирован с телом
    /// </summary>
    public bool IsWithBody => (Method == HttpMethod.Post || Method == HttpMethod.Put || Method == HttpMethod.Patch) && Body != null;

    /// <summary>
    /// Коллекция параметров запроса
    /// </summary>
    public ICollection<KeyValuePair<string, string>> QueryParameterList { get; set; } = new List<KeyValuePair<string, string>>();
}

public record BaseHttpResponse
{
    /// <summary>
    /// Статус ответа
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Заголовки, передаваемые в ответе
    /// </summary>
    public HttpResponseHeaders Headers { get; set; }

    /// <summary>
    /// Заголовки контента
    /// </summary>
    public HttpContentHeaders ContentHeaders { get; init; }

    /// <summary>
    /// Является ли статус код успешным
    /// </summary>
    public bool IsSuccessStatusCode
    {
        get
        {
            var statusCode = (int)StatusCode;

            return statusCode >= 200 && statusCode <= 299;
        }
    }
}

public record HttpResponse<TResponse> : BaseHttpResponse
{
    /// <summary>
    /// Тело ответа
    /// </summary>
    public TResponse Body { get; set; }
}

/// <inheritdoc />
public class HttpRequestService : IHttpRequestService
{
    private readonly IHttpConnectionService _httpConnectionService;

    ///
    public HttpRequestService(
        IHttpConnectionService httpConnectionService)
    {
        _httpConnectionService = httpConnectionService;
    }
    
    /// <inheritdoc />
    public async Task<HttpResponse<TResponse>> SendRequestAsync<TResponse>(HttpRequestData requestData, HttpConnectionData connectionData)
    {
        var client = _httpConnectionService.CreateHttpClient(connectionData);
       // _httpConnectionService.SendRequestAsync();
       return null;
    }
    
     private static HttpContent PrepairContent(object body, ContentType contentType)
    {
        switch (contentType)
        {
            case ContentType.ApplicationJson:
            {
                if (body is string stringBody)
                {
                    body = JToken.Parse(stringBody);
                }

                var serializeSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                };
                var serializedBody = JsonConvert.SerializeObject(body, serializeSettings);
                var content = new StringContent(serializedBody, Encoding.UTF8, MediaTypeNames.Application.Json);
                return content;
            }

            case ContentType.XWwwFormUrlEncoded:
            {
                if (body is not IEnumerable<KeyValuePair<string, string>> list)
                {
                    throw new Exception($"Body for content type {contentType} must be {typeof(IEnumerable<KeyValuePair<string, string>>).Name}");
                }

                return new FormUrlEncodedContent(list);
            }
            case ContentType.ApplicationXml:
            {
                if (body is not string s)
                {
                    throw new Exception($"Body for content type {contentType} must be XML string");
                }

                return new StringContent(s, Encoding.UTF8, MediaTypeNames.Application.Xml);
            }
            case ContentType.Binary:
            {
                if (body.GetType() != typeof(byte[]))
                {
                    throw new Exception($"Body for content type {contentType} must be {typeof(byte[]).Name}");
                }

                return new ByteArrayContent((byte[]) body);
            }
            case ContentType.TextXml:
            {
                if (body is not string s)
                {
                    throw new Exception($"Body for content type {contentType} must be XML string");
                }

                return new StringContent(s, Encoding.UTF8, MediaTypeNames.Text.Xml);
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(contentType), contentType, null);
        }
    }
}