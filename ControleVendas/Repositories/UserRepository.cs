using ControleVendas.Models;

namespace ControleVendas.Repositories
{
    public static class UserRepository
    {
        public static User GetUser(string userName, string password)
        {
            var users = new List<User>
            {
                new() { Id = 1, Username = "nome1", Password = "12345", Role = "manager" },
                new() { Id = 2, Username = "nome2", Password = "12345", Role = "employee" }
            };

            return users.FirstOrDefault(x => x.Username == userName && x.Password == password);
        }
    }
}
