using API.DTOs;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserAsync(int id);
    }
}
