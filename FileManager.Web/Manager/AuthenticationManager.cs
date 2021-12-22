using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FileManager.Application.Crypter;
using FileManager.Application.Repository.Interfaces;
using FileManager.Web.Manager.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace FileManager.Web.Manager
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public AuthenticationManager(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<AuthResult> Login(string identity, string password)
        {
            var user = await _userRepository.GetItemAsync(x => x.Email.ToLower() == identity.ToLower().Trim());
            var result = new AuthResult();
            if (user == null)
            {
                result.Success = false;
                result.Errors.Add("User not found");
                return result;
            }

            if (!Crypter.Verify(password, user.Password))
            {
                result.Success = false;
                result.Errors.Add("Invalid password");
                return result;
            }

            var httpContext = _httpContextAccessor.HttpContext;
            var claims = new List<Claim>
            {
                new("Id", user.Id.ToString()),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            result.Success = true;
            return result;
        }
    }

    public class AuthResult
    {
        public List<string> Errors = new();
        public bool Success;
    }
}