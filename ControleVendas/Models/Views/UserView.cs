namespace ControleVendas.Models.Views
{
    public class UserView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static implicit operator UserView(User user)
            => new()
            {
                Id = user.Id,
                Name = user.Username
            };
    }
}
