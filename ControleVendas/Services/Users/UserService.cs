using ControleVendas.Models;
using ControleVendas.Repositories.Users;

namespace ControleVendas.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetAsync(string email, string password)
            => await _repository.GetAsync(email, password);
    }
}
