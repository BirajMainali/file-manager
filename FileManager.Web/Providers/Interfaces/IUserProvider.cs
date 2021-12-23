using System.Threading.Tasks;
using FileManager.Domain.Entities;

namespace FileManager.Web.Providers.Interfaces
{
    public interface ICurrentUserProvider
    {
        bool IsLoggedIn();
        Task<User> GetCurrentUser();
        long? GetCurrentUserId();
        Task<Organization> GetCurrentOrganization();
    }
}