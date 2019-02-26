using System;
using System.Collections.Generic;

namespace TpixAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Topic = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Topic> Topic { get; set; }
    }
}
