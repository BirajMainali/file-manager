using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FileManager.Application.Repository.Interfaces;
using FileManager.Domain.Entities;
using FileManager.Web.Providers.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FileManager.Web.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public CurrentUserProvider(IHttpContextAccessor contextAccessor, IUserRepository userRepository,
            IOrganizationRepository organizationRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
        }

        public bool IsLoggedIn()
            => GetCurrentUserId() != null;

        public async Task<Domain.Entities.User.User> GetCurrentUser()
        {
            var userId = GetCurrentUserId();
            if (userId.HasValue) return await _userRepository.FindOrThrowAsync(userId.Value);
            return null;
        }

        public long? GetCurrentUserId()
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirstValue("Id");
            if (string.IsNullOrWhiteSpace(userId)) return null;
            return Convert.ToInt64(userId);
        }

        public async Task<Organization> GetCurrentOrganization()
        {
            var user = await GetCurrentUser();
            return user.Organization;
        }
    }
}