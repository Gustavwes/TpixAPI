using System;
using System.Collections.Generic;

namespace TpixAPI.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public int FkMemberReportedId { get; set; }
        public int FkPostId { get; set; }
        public int FkTopicId { get; set; }
        public int FkReportingMemberId { get; set; }
        public string Reason { get; set; }

        public virtual Member FkMemberReported { get; set; }
        public virtual Post FkPost { get; set; }
        public virtual Member FkReportingMember { get; set; }
        public virtual Topic FkTopic { get; set; }
    }
}
