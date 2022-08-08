namespace Insector.Data.Models
{
    public class RoleRight
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int RightId { get; set; }

        public virtual Role Role { get; set; }

        public virtual Right Right { get; set; }
    }
}