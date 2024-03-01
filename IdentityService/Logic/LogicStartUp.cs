using IdentityLogic.FriendRequests;
using IdentityLogic.FriendRequests.Interfaces;
using IdentityLogic.Notifications;
using IdentityLogic.Notifications.Interfaces;
using IdentityLogic.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using IdentityLogic.Users.Interfaces;

namespace IdentityLogic;

public static class LogicStartUp
{
    public static IServiceCollection TryAddLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IUserLogicManager, UserLogicManager>();
        serviceCollection.TryAddScoped<IPasswordManager, PasswordManager>();
        serviceCollection.TryAddScoped<IFriendRequestManager, FriendRequestManager>();
        serviceCollection.TryAddScoped<INotificationManager, NotificationManager>();
        return serviceCollection;
    }
}