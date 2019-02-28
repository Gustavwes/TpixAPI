using System;
using System.Collections.Generic;

namespace TpixAPI.Models
{
    public partial class Post
    {
        public Post()
        {
            Report = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string MainBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        public int FkParentTopicId { get; set; }
        public int FkCreatedBy { get; set; }

        public virtual Member FkCreatedByNavigation { get; set; }
        public virtual Topic FkParentTopic { get; set; }
        public virtual ICollection<Report> Report { get; set; }
    }
}
