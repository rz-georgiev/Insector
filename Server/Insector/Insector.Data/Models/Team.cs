namespace Insector.Data.Models
{
    public class Team : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }

        public virtual IEnumerable<User> Users { get; set; }

    }
}