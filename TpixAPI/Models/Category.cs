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
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int FkCreatedBy { get; set; }

        public virtual Member FkCreatedByNavigation { get; set; }
        public virtual ICollection<Topic> Topic { get; set; }
    }
}
