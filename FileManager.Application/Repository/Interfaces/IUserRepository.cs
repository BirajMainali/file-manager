namespace FileManager.Application.Repository.Interfaces
{
    public interface IUserRepository : Base.IBaseRepository<Domain.Entities.User.User>
    {
        Task<bool> IsEmailUsed(string email, long? excludedId = null);
    }
}