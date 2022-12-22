using Microsoft.AspNetCore.Identity;

namespace ControleVendas.Models.Views
{
    public class UserView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public static implicit operator UserView(User user)
            => new()
            {
                Id = user.Id,
                Name = user.Name, 
                Email = user.Email,
                Role = user.Role
            };
    }
}
