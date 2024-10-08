using MovieApi.Models;
using MovieApi.Models.DTOs;

namespace MovieApi.UsersService
{
    public interface IUsersInterface
    {
        Task<ServiceResponse<UserDto>> CreateUser(UserCreateDto newUser);
        Task<ServiceResponse<List<UserDto>>> GetUsers();
        Task<ServiceResponse<UserDto>> GetUserById(int id);
        Task<ServiceResponse<UserDto>> SoftDelete(int id);
        Task<ServiceResponse<string>> Login(UserCreateDto login);
    }
}