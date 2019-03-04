using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpixAPI.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        [Required]
        public int FkMemberReportedId { get; set; }
        [Required]
        public int FkPostId { get; set; }
        [Required]
        public int FkTopicId { get; set; }
        [Required]
        public int FkReportingMemberId { get; set; }
        public string Reason { get; set; }

        public virtual Member FkMemberReported { get; set; }
        public virtual Post FkPost { get; set; }
        public virtual Member FkReportingMember { get; set; }
        public virtual Topic FkTopic { get; set; }
    }
}
