using Domain.Interfaces;
using ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using ProfileConnectionLib.ConnectionServices.Interfaces;

namespace Infastracted.Connections;

// 1 микросервис может предоставлять RPC библиотеку для в/д с ним (в виде  csproj)
// 2 этот сервис может сам решать какой канал в/д он использует
// 3 мы не должны в/д с этим сервис в обход его connection Lib

internal class CheckUser : ICheckUser
{
    private readonly IProfileConnectionServcie _profileConnectionServcie;

    public CheckUser(IProfileConnectionServcie profileConnectionServcie)
    {
        _profileConnectionServcie = profileConnectionServcie;
    }
    
    public async Task CheckUserExistAsync(Guid userId)
    {
        await _profileConnectionServcie.CheckUserExistAsync(new CheckUserExistProfileApiRequest
        {
            UserId = userId
        });
    }
}