﻿namespace Insector.Data.Models
{
    public class Right
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public virtual IEnumerable<Role> Roles { get; set; }
    }
}