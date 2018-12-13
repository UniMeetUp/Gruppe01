using AutoMapper;
using CommonLib.Models;
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
