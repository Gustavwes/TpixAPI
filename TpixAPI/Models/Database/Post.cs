using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpixAPI.Models.Database
{
    public partial class Post
    {
        public Post()
        {
            Report = new HashSet<Report>();
        }

        public int Id { get; set; }
        [Required]
        public string MainBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        [Required]
        public int FkParentTopicId { get; set; }
        [Required]
        public int FkCreatedBy { get; set; }

        public virtual Member FkCreatedByNavigation { get; set; }
        public virtual Topic FkParentTopic { get; set; }
        public virtual ICollection<Report> Report { get; set; }
    }
}
