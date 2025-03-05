using System;
using System.Diagnostics;
using application.Activities.DTOs;
using AutoMapper;

namespace application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
        CreateMap<CreateActivityDto, Activity>();
    }
}
