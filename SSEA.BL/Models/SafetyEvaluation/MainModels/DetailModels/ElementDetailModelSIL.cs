using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class ElementDetailModelSIL : ExtendedModelBase
    {
        public short OrderNum { get; set; }
        public double B10d { get; set; }
        public string CatalogNumber { get; set; }
        public double C { get; set; }
        public double LambdaC { get; set; }

        public ProducerModel Producer { get; set; }
        public DCModel DC { get; set; }
    }

    public class ElementDetailModelSILMapperProfile : Profile
    {
        public ElementDetailModelSILMapperProfile()
        {
            CreateMap<Element, ElementDetailModelPL>().IgnoreSource(src => src.ProducerId)
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
                                                      .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                      .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                      .ReverseMap();
        }
    }
}
