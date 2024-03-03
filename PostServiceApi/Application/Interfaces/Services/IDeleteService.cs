namespace Application.Interfaces.Services
{
    public interface IDeleteService<TViewModel> where TViewModel : class
    {
        Task DeleteAsync(Guid id);
    }
}
