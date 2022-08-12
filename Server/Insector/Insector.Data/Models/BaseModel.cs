namespace Insector.Data.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public int LastUpdatedByUserId { get; set; }
    }
}