using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProfileLogic.Users;
using ProfileLogic.Users.Interfaces;

namespace ProfileLogic;

public static class LogicStartUp
{
    public static IServiceCollection TryAddLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IUserLogicManager, UserLogicManager>();
        return serviceCollection;
    }
}