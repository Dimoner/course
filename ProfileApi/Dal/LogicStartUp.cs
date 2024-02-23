using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProfileDal.Users;
using ProfileDal.Users.Interfaces;

namespace ProfileDal;

public static class DalStartUp
{
    public static IServiceCollection TryAddDal(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IUserRepository, UserRepository>();
        return serviceCollection;
    }
}