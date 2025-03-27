
using Application.DTOs;

namespace Application.Interface
{
    public interface IUser
    {
        string? Id { get; }
        string Username { get; }
        string Email { get; }
        public ApplicationUserDto AppUser { get; set; }

        Task UpdateAppUser(ApplicationUserDto applicationUserDto);
        Task UpdateAppUserPic(string picUrl);
    }
}
