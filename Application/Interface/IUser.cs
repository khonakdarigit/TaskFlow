

using Application.DTOs;

namespace Application.Interface
{
    public interface IUser
    {
        string? Id { get; }
        string Username { get; }
        string Email { get; }
        public ApplicationUserDto AppUser { get; }
    }
}
