using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpixAPI.Models.Database
{
    public partial class Category
    {
        public Category()
        {
            Topic = new HashSet<Topic>();
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        [Required]
        public int FkCreatedBy { get; set; }

        public virtual Member FkCreatedByNavigation { get; set; }
        public virtual ICollection<Topic> Topic { get; set; }
    }
}
