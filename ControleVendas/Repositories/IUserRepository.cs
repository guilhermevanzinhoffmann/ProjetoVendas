using ControleVendas.Models;

namespace ControleVendas.Repositories
{
    public interface IUserRepository
    {
        User Get(string userName, string password);
    }
}
