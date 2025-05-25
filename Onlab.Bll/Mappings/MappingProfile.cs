using Onlab.Dal.Entities;
using Onlab.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Onlab.Bll.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Band, BandData>();
           

            CreateMap<CreateBandData, Band>()
          
            .ForMember(dest => dest.Users, opt => opt.Ignore()); // Ignore Users for now

            CreateMap<User, UserData>();
          
            CreateMap<CreateUserData, User>();
            


            CreateMap<Setlist, SetlistData>();
            CreateMap<CreateSetlistData, Setlist>();

            CreateMap<TaskItem, TaskItemData>();
            CreateMap<CreateTaskItemData, TaskItem>();

            CreateMap<Concert, ConcertData>();
            CreateMap<CreateConcertData, Concert>();


        }
    }
}
