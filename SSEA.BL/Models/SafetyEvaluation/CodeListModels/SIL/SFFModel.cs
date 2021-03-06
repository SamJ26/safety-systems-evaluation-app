﻿using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class SFFModel : CodeListModelBase
    {
        public string ComponentName { get; set; }
        public string FailureMode { get; set; }
        public uint Value { get; set; }
    }

    public class SFFModelMapperProfile : Profile
    {
        public SFFModelMapperProfile()
        {
            CreateMap<SFF, SFFModel>().IgnoreSource(src => src.ComponentNameEN)
                                      .IgnoreSource(src => src.FailureModeEN)
                                      .IgnoreSource(src => src.ElementSFFs)
                                      .MapMember(dest => dest.ComponentName, src => src.ComponentNameCZ)
                                      .MapMember(dest => dest.FailureMode, src => src.FailureModeCZ)
                                      .ReverseMap();
        }
    }
}
