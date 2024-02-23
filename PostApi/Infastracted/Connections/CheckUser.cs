using Services;

namespace ProfileDal;

public class CheckUser : ICheckUser
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CheckUser(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task CheckUserExistAsync(Guid userId)
    {
        var client = _httpClientFactory.CreateClient();
        var res = await client.GetAsync("dfgsdf");
    }
}