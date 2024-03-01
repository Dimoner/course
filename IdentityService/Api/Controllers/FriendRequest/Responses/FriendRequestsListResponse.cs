namespace IdentityApi.Controllers.FriendRequest.Responses;

/// <summary>
/// Список всех отпрвленных и полученных заявок на добалвения в друзья пользователя
/// </summary>
public class FriendRequestsListResponse
{
    public required List<FriendRequestResponse> Data { get; init; }
}