using ControleVendas.DBManager;
using ControleVendas.Models;

namespace ControleVendas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SalesContext _context;

        public UserRepository(SalesContext context)
        {
            _context = context;
        }

        public User Get(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
