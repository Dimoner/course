namespace Application.Interfaces.Services
{
    public interface ICreateService<TViewModel> where TViewModel : class
    {
        Task<Guid> CreateAsync(TViewModel viewModel);
    }
}
