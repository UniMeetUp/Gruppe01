using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonLib.Models;
using UniMeetUpServer.Controllers;
using UniMeetUpServer.DTO;

namespace UniMeetUpServer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserToPostDTO>();
        }
    }
}
