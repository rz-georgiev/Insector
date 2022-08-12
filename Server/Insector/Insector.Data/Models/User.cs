namespace Insector.Data.Models
{
    public class User : BaseModel
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Nickname { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public virtual IEnumerable<Role> Roles { get; set; }

        public virtual IEnumerable<Task> Tasks { get; set; }

    }
}