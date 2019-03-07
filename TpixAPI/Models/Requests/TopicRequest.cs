using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TpixAPI.Models.Database;

namespace TpixAPI.Models.Requests
{
    public class TopicRequest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string MainBody { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        [Required]
        public int FkCategoryId { get; set; }
        [Required]
        public int FkCreatedBy { get; set; }
        [JsonProperty(PropertyName = "CreatedByMember")]
        public MemberRequest FkCreatedByNavigation { get; set; }
        public List<PostRequest> Post { get; set; }
    }
}
