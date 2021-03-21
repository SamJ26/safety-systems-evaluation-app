using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.JoinModels
{
    public class SubsystemCCFModel : ModelBase
    {
        public int SubsystemId { get; set; }
        public int CCFId { get; set; }
    }

    public class SubsystemCCFModelMapperProfile : Profile
    {
        public SubsystemCCFModelMapperProfile()
        {
            CreateMap<SubsystemCCF, SubsystemCCFModel>().IgnoreSource(src => src.Subsystem)
                                                        .IgnoreSource(src => src.CCF)
                                                        .ReverseMap();
        }
    }
}
