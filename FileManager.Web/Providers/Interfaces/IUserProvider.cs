using System.Threading.Tasks;

namespace FileManager.Web.Providers.Interfaces
{
    public interface ICurrentUserProvider
    {
        bool IsLoggedIn();
        Task<Domain.Entities.User.User> GetCurrentUser();
        long? GetCurrentUserId();
    }
}