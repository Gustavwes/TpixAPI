using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MemberRequest, Member>();
            CreateMap<PostRequest, Post>();
            CreateMap<TopicRequest, Topic>();
            CreateMap<CategoryRequest, Category>();
        }
    }
}
