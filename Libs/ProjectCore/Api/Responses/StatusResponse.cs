namespace ProjectCore.Api.Responses;

/// <summary>
/// Стандартный ответ, отправляемый из разных рестов
/// </summary>
public class StatusResponse
{
    /// <summary>
    /// Были ли выполнены запрошенные действия успешно
    /// </summary>
    public required bool IsSuccess { get; set; }
    
    /// <summary>
    /// Дополнительные сведения о статусе запроса
    /// </summary>
    public required string Message { get; set; }
}