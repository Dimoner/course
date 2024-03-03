namespace ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;

public record CheckUserExistProfileApiRequest
{
    public required Guid UserId { get; init; }
}
