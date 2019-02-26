using System;
using System.Collections.Generic;

namespace TpixAPI.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TopicId { get; set; }
        public DateTime DatePosted { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
