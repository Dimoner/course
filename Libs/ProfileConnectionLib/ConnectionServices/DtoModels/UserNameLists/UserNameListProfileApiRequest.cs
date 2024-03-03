namespace ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;

// "{name}{servicename}{request/response}"
public record UserNameListProfileApiRequest
{
    public required Guid[] UserIdList { get; init; }
}
