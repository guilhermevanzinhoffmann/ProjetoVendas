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

        public User Get(string userName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Username == userName && x.Password == password);
            //var users = new List<User>
            //{
            //    new() { Id = 1, Username = "nome1", Password = "12345", Role = "manager" },
            //    new() { Id = 2, Username = "nome2", Password = "12345", Role = "employee" }
            //};
        }
    }
}
