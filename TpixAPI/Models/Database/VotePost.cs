using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpixAPI.Models.Database
{
    public partial class VotePost
    {
        [Required]
        public int VoteValue { get; set; }
        [Required]
        public int FkPostId { get; set; }
        [Required]
        public int FkMemberId { get; set; }
    }
}
