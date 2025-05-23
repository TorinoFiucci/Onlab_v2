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
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));

            CreateMap<CreateBandData, Band>()
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));
            //.ForMember(dest => dest.Members, opt => opt.Ignore());
            //.ForMember(dest => dest.Concerts, opt => opt.Ignore())
            //.ForMember(dest => dest.Setlists, opt => opt.Ignore());
            .ForMember(dest => dest.Users, opt => opt.Ignore()); // Ignore Users for now

            CreateMap<User, UserData>();
            // For CreateUserData, ensure properties align.
            // If CreateUserData has Password, and User has PasswordHash/PasswordSalt,
            // this mapping will be simple property-to-property for other fields.
            // Password hashing logic is typically handled in the service, not by AutoMapper directly.
            CreateMap<CreateUserData, User>();
            //.ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id for creation
            //.ForMember(dest => dest.BandId, opt => opt.Ignore()) // Ignore BandId for creation
            //.ForMember(dest => dest.Band, opt => opt.Ignore()); // Ignore Band for creation

            // Assuming CreateUserData exists

            CreateMap<Setlist, SetlistData>();
            CreateMap<CreateSetlistData, Setlist>();

            CreateMap<TaskItem, TaskItemData>();
            CreateMap<CreateTaskItemData, TaskItem>();

            CreateMap<Concert, ConcertData>();
            CreateMap<CreateConcertData, Concert>();


        }
    }
}
