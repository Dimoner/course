using CoreLib.HttpServiceV2.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;
using ProfileConnectionLib.ConnectionServices.Interfaces;

namespace ProfileConnectionLib.ConnectionServices;

public class ProfileConnectionService : IProfileConnectionServcie
{
    private readonly IHttpRequestService _httpClientFactory;

    public ProfileConnectionService(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        if (configuration.GetSection("dsgf").Value == "http")
        {
            _httpClientFactory = serviceProvider.GetRequiredService<IHttpRequestService>();
        }
        else
        {
            // RPC по rabbit
        }
     
    }
    public Task<UserNameListProfileApiResponse[]> GetUserNameListAsync(UserNameListProfileApiRequest request)
    {
        throw new NotImplementedException();
    }
    
    public async Task<CheckUserExistProfileApiResponse> CheckUserExistAsync(CheckUserExistProfileApiRequest checkUserExistProfileApiRequest)
    {
        // var client = _httpClientFactory.SendRequestAsync<>();
        // var res = await client.GetAsync("dfgsdf");
        return null;
    }
}
