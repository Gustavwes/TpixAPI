using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TpixAPI.Models.Requests
{
    public class CategoryRequest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        [Required]
        public int FkCreatedBy { get; set; }
    }
}
