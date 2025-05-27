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
            CreateMap<UserData, User>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Id to prevent overwriting existing user Ids

            CreateMap<CreateUserData, User>();
            


            CreateMap<Setlist, SetlistData>();
            CreateMap<CreateSetlistData, Setlist>();

            CreateMap<TaskItem, TaskItemData>();
            CreateMap<CreateTaskItemData, TaskItem>();

            CreateMap<Concert, ConcertData>();
            CreateMap<CreateConcertData, Concert>();

            CreateMap<ConcertData, Concert>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Never update the PK from a DTO
                .ForMember(dest => dest.Band, opt => opt.Ignore()) // Ignore navigation properties, we only care about the FK
                .ForMember(dest => dest.Setlist, opt => opt.Ignore()); // Ignore navigation properties


        }
    }
}
/*
// --- Band Mappings ---
CreateMap<Band, BandData>();
CreateMap<CreateBandData, Band>();

// --- User Mappings ---
CreateMap<CreateUserData, User>();
CreateMap<User, UserData>()
    // Populate BandName from the User's Band navigation property
    .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band != null ? src.Band.Name : null));
CreateMap<UserData, User>()
    .ForMember(dest => dest.Id, opt => opt.Ignore()); // Don't update PK

// --- TaskItem Mappings ---
CreateMap<CreateTaskItemData, TaskItem>();
CreateMap<TaskItem, TaskItemData>()
    // Explicitly map the User entity to the UserData DTO
    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

// --- Setlist Mappings ---
CreateMap<CreateSetlistData, Setlist>();
CreateMap<Setlist, SetlistData>()
    .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band != null ? src.Band.Name : null))
    // When mapping Setlist->SetlistData, also map its Concert entity to a ConcertData DTO
    .ForMember(dest => dest.Concert, opt => opt.MapFrom(src => src.Concert))
    // IMPORTANT: Prevent infinite loops
    .MaxDepth(1);

// --- Concert Mappings ---
CreateMap<CreateConcertData, Concert>();
CreateMap<Concert, ConcertData>()
    .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band != null ? src.Band.Name : null))
    // When mapping Concert->ConcertData, also map its Setlist entity to a SetlistData DTO
    .ForMember(dest => dest.Setlist, opt => opt.MapFrom(src => src.Setlist))
    // IMPORTANT: Prevent infinite loops
    .MaxDepth(1);

// This map is used for updates (PUT requests)
CreateMap<ConcertData, Concert>()
    .ForMember(dest => dest.Id, opt => opt.Ignore())       // Never map Id from DTO to entity
    .ForMember(dest => dest.Band, opt => opt.Ignore())     // Ignore navigation properties
    .ForMember(dest => dest.Setlist, opt => opt.Ignore()); // Ignore navigation properties
        }

*/