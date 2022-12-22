using ControleVendas.DBManager;
using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SalesContext _context;

        public UserRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(string email, string password)
            => await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        
    }
}
