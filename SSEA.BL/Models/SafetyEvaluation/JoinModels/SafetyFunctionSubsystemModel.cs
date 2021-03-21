using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.JoinModels
{
    public class SafetyFunctionSubsystemModel : ModelBase
    {
        public int SafetyFunctionId { get; set; }
        public int SubsystemId { get; set; }
    }

    public class SafetyFunctionSubsystemModelMapperProfile : Profile
    {
        public SafetyFunctionSubsystemModelMapperProfile()
        {
            CreateMap<SafetyFunctionSubsystem, SafetyFunctionSubsystemModel>().IgnoreSource(src => src.SafetyFunction)
                                                                              .IgnoreSource(src => src.Subsystem)
                                                                              .ReverseMap();
        }
    }
}
