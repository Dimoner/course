namespace Application.Interfaces.Services
{
    public interface IGetService<TViewModel> where TViewModel : class
    {
        Task<TViewModel> GetAsync(Guid id);
    }
}
