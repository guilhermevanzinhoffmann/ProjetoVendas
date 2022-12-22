using ControleVendas.Models;

namespace ControleVendas.Services.Users
{
    public interface IUserService
    {
        Task<User> GetAsync(string email, string password);
    }
}
