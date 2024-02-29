namespace Dal.UserProfiles
{
    public interface IUserProfileRepository: IRepository<UserProfileDal>
    {
        Task<UserProfileDal?> GetByUserIdAsync(Guid id);
    }
}
