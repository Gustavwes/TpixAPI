using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TpixAPI.Models.Requests
{
    public class ReportRequest
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
    }
}
