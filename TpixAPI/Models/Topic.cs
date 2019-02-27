using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpixAPI.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DatePosted { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
