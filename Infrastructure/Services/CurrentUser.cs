using Application.DTOs;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class CurrentUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public CurrentUser(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;

        }
        public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public string? Username => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
        public ApplicationUserDto AppUser
        {
            get
            {
                return _mapper.Map<ApplicationUserDto>(_userManager.Users.First(c => c.Id == Id));
            }
            set
            {
                AppUser = value;
            }
        }

        public async Task UpdateAppUser(ApplicationUserDto applicationUserDto)
        {
            var user = _userManager.Users.First(c => c.Id == Id);
            user.FirstName = applicationUserDto.FirstName;
            user.LastName = applicationUserDto.LastName;
            await _userManager.UpdateAsync(user);
        }

        public async Task UpdateAppUserPic(string picUrl)
        {
            var user = _userManager.Users.First(c => c.Id == Id);
            user.ProfilePictureUrl = picUrl;
            await _userManager.UpdateAsync(user);
        }
    }
}
