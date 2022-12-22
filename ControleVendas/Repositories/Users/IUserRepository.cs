using ControleVendas.Models;

namespace ControleVendas.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string userName, string password);
    }
}
