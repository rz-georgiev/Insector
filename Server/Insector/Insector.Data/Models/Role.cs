﻿namespace Insector.Data.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Right> Rights { get; set; } 
    }
}