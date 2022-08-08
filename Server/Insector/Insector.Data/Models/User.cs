namespace Insector.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }

        public string AvatarUrl { get; set; }

        public virtual IEnumerable<Role> Roles { get; set; }

    }
}