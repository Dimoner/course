using IdentityDal.FriendRequests;
using IdentityDal.FriendRequests.Interfaces;
using IdentityDal.Notifications;
using IdentityDal.Notifications.Interfaces;
using IdentityDal.Users;
using IdentityDal.Users.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IdentityDal;

public static class DalStartUp
{
    public static IServiceCollection TryAddDal(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IUserRepository, UserRepository>();
        serviceCollection.TryAddScoped<IFriendRequestRepository, FriendRequestRepository>();
        serviceCollection.TryAddScoped<INotificationRepository, NotificationRepository>();
        return serviceCollection;
    }
}