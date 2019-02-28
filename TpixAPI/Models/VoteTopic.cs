using System;
using System.Collections.Generic;

namespace TpixAPI.Models
{
    public partial class VoteTopic
    {
        public int VoteValue { get; set; }
        public int FkTopicId { get; set; }
        public int FkMemberId { get; set; }
    }
}
