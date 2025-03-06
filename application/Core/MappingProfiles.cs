using System;
using System.Diagnostics;
using application.Activities.DTOs;
using application.Profiles.DTOs;
using AutoMapper;
using Domain;

namespace application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Activity, Domain.Activity>();
        CreateMap<CreateActivityDto, Domain.Activity>();
        CreateMap<Domain.Activity, ActivityDto>()
            .ForMember(d => d.HostDisplayName, o => o.MapFrom(s => 
                s.Attendees.FirstOrDefault(x => x.IsHost)!.User.DisplayName))
             .ForMember(d => d.HostDisplayName, o => o.MapFrom(s => 
                s.Attendees.FirstOrDefault(x => x.IsHost)!.User.Id)); 
        CreateMap<ActivityAttendee, UserProfile>()
            .ForMember(d => d.DisplayName, o => o.MapFrom(s =>s.User.DisplayName))
            .ForMember(d => d.Bio, o => o.MapFrom(s =>s.User.Bio))
            .ForMember(d => d.ImageUrl, o => o.MapFrom(s =>s.User.ImageUrl))
            .ForMember(d => d.Id, o => o.MapFrom(s =>s.User.Id));
 
    }
}
