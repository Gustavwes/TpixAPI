using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpixAPI.Models
{
    public partial class VoteTopic
    {
        [Required]
        public int VoteValue { get; set; }
        [Required]
        public int FkTopicId { get; set; }
        [Required]
        public int FkMemberId { get; set; }
    }
}
