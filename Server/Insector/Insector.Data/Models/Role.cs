namespace Insector.Data.Models
{
    public class Role : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}