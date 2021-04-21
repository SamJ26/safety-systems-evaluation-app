using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class ElementDetailModelPL : ElementDetailModel
    {
        public double Nop { get; set; }
        public double Hop { get; set; }
        public double Dop { get; set; }
        public double Tcycles { get; set; }
        public double MTTFdCounted { get; set; }      
        public MTTFdModel MTTFdResult { get; set; }
    }

    public class ElementDetailModelPLMapperProfile : Profile
    {
        public ElementDetailModelPLMapperProfile()
        {
            CreateMap<Element, ElementDetailModelPL>().IgnoreSource(src => src.ProducerId)
                                                      .IgnoreSource(src => src.SubsystemId)
                                                      .IgnoreSource(src => src.Subsystem)
                                                      .IgnoreSource(src => src.DCId)
                                                      .IgnoreSource(src => src.MTTFdResultId)
                                                      .IgnoreSource(src => src.C)
                                                      .IgnoreSource(src => src.LambdaC)
                                                      .IgnoreSource(src => src.ElementSFFs)
                                                      .IgnoreSource(src => src.CurrentStateId)
                                                      .IgnoreSource(src => src.SummedSFF)
                                                      .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                      .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                      .ReverseMap();
        }
    }
}
