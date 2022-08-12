namespace Insector.Data.Models
{
    public class Task : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public float Progress { get; set; }

        public int TypeId { get; set; }

        public int ProgressId { get; set; }

        public virtual TaskType TaskType { get; set; }

        public virtual ProgressType ProgressType { get; set; }

        public int AssignedToUserId { get; set; }

        public virtual User AssignedToUser { get; set; }
    }
}