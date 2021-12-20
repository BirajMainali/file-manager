using System.Threading.Tasks;

namespace FileManager.Web.Manager.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<AuthResult> Login(string identity, string password);
    }
}