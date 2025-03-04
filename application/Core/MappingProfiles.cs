using System;
using System.Diagnostics;
using AutoMapper;

namespace application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
    }
}
