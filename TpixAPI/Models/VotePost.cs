using System;
using System.Collections.Generic;

namespace TpixAPI.Models
{
    public partial class VotePost
    {
        public int VoteValue { get; set; }
        public int FkPostId { get; set; }
        public int FkMemberId { get; set; }
    }
}
