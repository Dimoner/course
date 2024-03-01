namespace IdentityApi.Controllers.Notification.Responses;

public class NotificationInfoResponse
{
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Заголовок уведомления
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    /// Основной текст уведомления
    /// </summary>
    public required string Content { get; init; }
    
    /// <summary>
    /// Было ли уведомление уже прочитано
    /// </summary>
    public required bool WasRead { get; set; }
    
    /// <summary>
    /// Дата и время добавления уведомления
    /// </summary>
    public required DateTime CreatedTime { get; init; }
}