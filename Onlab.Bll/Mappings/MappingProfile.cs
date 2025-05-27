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
            CreateMap<BandData, Band>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Id to prevent overwriting existing band Ids
                


            CreateMap<CreateBandData, Band>()
          
            .ForMember(dest => dest.Users, opt => opt.Ignore()); // Ignore Users for now

            CreateMap<User, UserData>();
            CreateMap<UserData, User>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Id to prevent overwriting existing user Ids

            CreateMap<CreateUserData, User>();



            CreateMap<CreateSetlistData, Setlist>()
                // Name, Description, BandId will map directly.
                // ConcertId will also map if CreateSetlistData has it and Setlist entity has ConcertId.
                // My recommended CreateSetlistData in the previous turn included ConcertId.
                // Your provided CreateSetlistData in this turn does NOT have ConcertId.
                // If you want to set ConcertId on creation, add it to CreateSetlistData.
                // For now, assuming CreateSetlistData DOES NOT have ConcertId based on your latest DTO:
                .ForMember(dest => dest.ConcertId, opt => opt.Ignore()) // Because CreateSetlistData (your version) lacks it
                .ForMember(dest => dest.Concert, opt => opt.Ignore());


            CreateMap<Setlist, SetlistData>()
                .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band != null ? src.Band.Name : null))
                // Map the Concert navigation property on Setlist entity to the nested ConcertData DTO
                .ForMember(dest => dest.Concert, opt => opt.MapFrom(src => src.Concert))
                // ConcertId on SetlistData will be automatically mapped from Setlist.ConcertId if names match
                // Or explicitly: .ForMember(dest => dest.ConcertId, opt => opt.MapFrom(src => src.ConcertId))
                .MaxDepth(1); // IMPORTANT: Prevents circular mapping with ConcertData having SetlistData

            // For updating a Setlist entity from a SetlistData DTO
            CreateMap<SetlistData, Setlist>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Don't map/overwrite the Id
                .ForMember(dest => dest.Band, opt => opt.Ignore())   // Ignore navigation property, use BandId
                .ForMember(dest => dest.Concert, opt => opt.Ignore()); // Ignore navigation property, use ConcertId
                                                                       // Name, Description, BandId, ConcertId will map by convention if names match

            CreateMap<CreateConcertData, Concert>(); // CreateConcertData now has SetlistId?
            CreateMap<Concert, ConcertData>()
                .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band != null ? src.Band.Name : null))
                // If ConcertData has a nested SetlistData (and Concert entity has a Setlist nav prop)
                .ForMember(dest => dest.Setlist, opt => opt.MapFrom(src => src.Setlist))
                .MaxDepth(1); // Prevent circular mapping if SetlistData also contains ConcertData

            CreateMap<ConcertData, Concert>() // For updates (if you use ConcertData to update Concert)
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Band, opt => opt.Ignore())
                .ForMember(dest => dest.Setlist, opt => opt.Ignore()); // Typically manage relationship via FK

            CreateMap<TaskItem, TaskItemData>();
            CreateMap<CreateTaskItemData, TaskItem>();
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