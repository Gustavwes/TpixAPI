﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TpixAPI.Models.Requests
{
    public class PostRequest
    {
        public int Id { get; set; }
        [Required]
        public string MainBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        [Required]
        public int FkParentTopicId { get; set; }
        [Required]
        public int FkCreatedBy { get; set; }
    }
}