namespace Application.Interfaces
{
    public interface IMapper<TViewModel, TEntity>
    {
        public TViewModel Map(TEntity entity);
        public IEnumerable<TViewModel> Map(IEnumerable<TEntity> entities);
    }
}
