using ProjectCore.Dal.Base;

namespace IdentityDal.Notifications.Models;

/// <summary>
/// Dal модель уведомления, получаемого на сервисе
/// </summary>
public record NotificationDal : BaseEntityDal<Guid>
{
    /// <summary>
    /// Id пользователя, которому пришло уведомление
    /// </summary>
    public required Guid UserId { get; init; }
    
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