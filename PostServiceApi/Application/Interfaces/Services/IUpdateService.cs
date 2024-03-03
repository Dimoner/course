namespace Application.Interfaces.Services
{
    public interface IUpdateService<TViewModel> where TViewModel : class
    {
        Task UpdateAsync(TViewModel viewModel);
    }
}
