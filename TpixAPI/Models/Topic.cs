using System;
using System.Collections.Generic;

namespace TpixAPI.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Post = new HashSet<Post>();
            Report = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string MainBody { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        public int FkCategoryId { get; set; }
        public int FkCreatedBy { get; set; }

        public virtual Category FkCategory { get; set; }
        public virtual Member FkCreatedByNavigation { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Report> Report { get; set; }
    }
}
