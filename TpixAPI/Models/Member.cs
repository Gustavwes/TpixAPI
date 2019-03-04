﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpixAPI.Models
{
    public partial class Member
    {
        public Member()
        {
            Category = new HashSet<Category>();
            Post = new HashSet<Post>();
            ReportFkMemberReported = new HashSet<Report>();
            ReportFkReportingMember = new HashSet<Report>();
            Topic = new HashSet<Topic>();
        }

        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Report> ReportFkMemberReported { get; set; }
        public virtual ICollection<Report> ReportFkReportingMember { get; set; }
        public virtual ICollection<Topic> Topic { get; set; }
    }
}
