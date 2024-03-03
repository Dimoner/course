namespace Application.Interfaces.Services
{
    public interface IGetPageService<TViewModel> where TViewModel : class
    {
        Task<IEnumerable<TViewModel>> GetPageAsync(int pageNumber, int pageSize);
    }
}
