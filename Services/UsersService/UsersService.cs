using System.Diagnostics;
using System.Drawing.Printing;
using Azure.Identity;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using MovieApi.DataContext;
using MovieApi.Models;
using MovieApi.Models.DTOs;
using MovieApi.Services;
using MovieApi.UsersService;

namespace MovieApi.UsersService
{
    public class UsersService(ApplicationDbContext context) : IUsersInterface
    {
        private readonly ApplicationDbContext _context = context;
        private readonly AuthService _authService;

        public async Task<ServiceResponse<UserDto>> CreateUser(UserCreateDto newUser)
        {
            ServiceResponse<UserDto> serviceResponse = new();

            try
            {
                if (await _context.Users.FirstOrDefaultAsync(u => u.Username == newUser.Username) != null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário já existe";

                    return serviceResponse;
                }
                var createUser = new UserModel
                {
                    Username = newUser.Username,
                    Password = Argon2.Hash(newUser.Password)
                };

                _context.Users.Add(createUser);
                await _context.SaveChangesAsync();

                UserDto userDto = new UserDto
                {
                    Id = createUser.Id,
                    Username = createUser.Username,
                    Created_at = DateTime.Now.ToLocalTime(),
                    Updated_at = DateTime.Now.ToLocalTime(),
                };

                serviceResponse.Data = userDto;
                serviceResponse.Message = "Usuário criado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<UserDto>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<UserDto>>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<string>> Login(UserCreateDto login)
        {
            ServiceResponse<string> serviceResponse = new();
            try
            {
                // Verifica se o usuário existe no banco de dados
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username);
                if (user == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário ou senha incorretos.";
                    return serviceResponse;
                }

                if (!Argon2.Verify(user.Password, login.Password))
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário ou senha incorretos.";
                    return serviceResponse;
                }

                // Criação do token
                var authService = new AuthService();
                string token = authService.GenerateJwtToken(user);

                // Retorno do token para o cliente
                serviceResponse.Data = token;
                serviceResponse.Message = "Usuário logado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<UserDto>> SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
    }
}