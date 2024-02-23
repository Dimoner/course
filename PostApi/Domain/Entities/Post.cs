using ExampleCore.Dal.Base;

namespace ProfileDal.Entities;

public record Post : BaseEntityDal<Guid>
{
    public required Guid UserId { get; init; }
    
    public required string Title { get; init; }
    
    public required string Content { get; init; }
    
    public int LikeCount { get; init; }
}