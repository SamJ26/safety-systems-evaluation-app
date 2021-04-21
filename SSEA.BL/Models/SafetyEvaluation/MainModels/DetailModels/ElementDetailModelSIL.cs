using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.Collections.Generic;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class ElementDetailModelSIL : ElementDetailModel
    {    
        public double C { get; set; }
        public double LambdaC { get; set; }
        public double SummedSFF { get; set; }
        public HashSet<SFFModel> SelectedSFFs { get; set; }
    }

    public class ElementDetailModelSILMapperProfile : Profile
    {
        public ElementDetailModelSILMapperProfile()
        {
            CreateMap<Element, ElementDetailModelSIL>().IgnoreSource(src => src.ProducerId)
                                                       .IgnoreSource(src => src.SubsystemId)
                                                       .IgnoreSource(src => src.Subsystem)
                                                       .IgnoreSource(src => src.DCId)
                                                       .IgnoreSource(src => src.Nop)
                                                       .IgnoreSource(src => src.Hop)
                                                       .IgnoreSource(src => src.Dop)
                                                       .IgnoreSource(src => src.Tcycles)
                                                       .IgnoreSource(src => src.MTTFdCounted)
                                                       .IgnoreSource(src => src.MTTFdResult)
                                                       .IgnoreSource(src => src.MTTFdResultId)
                                                       .IgnoreSource(src => src.ElementSFFs)
                                                       .IgnoreSource(src => src.CurrentStateId)
                                                       .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                       .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                       .ReverseMap();
        }
    }
}
