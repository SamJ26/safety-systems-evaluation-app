using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SafetyFunctionDetailModelPL : SafetyFunctionDetailModel<SubsystemDetailModelPL>
    {
        public PLModel ResultantPL { get; set; }
        public PLModel RequiredPL { get; set; }
        public SModel S { get; set; }
        public FModel F { get; set; }
        public PModel P { get; set; }
    }

    public class SafetyFunctionDetailModelPLMapperProfile : Profile
    {
        public SafetyFunctionDetailModelPLMapperProfile()
        {
            CreateMap<SafetyFunction, SafetyFunctionDetailModelPL>().IgnoreSource(src => src.TypeOfFunctionId)
                                                                    .IgnoreSource(src => src.EvaluationMethodId)
                                                                    .IgnoreSource(src => src.AccessPointSafetyFunctions)
                                                                    .IgnoreSource(src => src.PLrId)
                                                                    .IgnoreSource(src => src.PLresultId)
                                                                    .IgnoreSource(src => src.SId)
                                                                    .IgnoreSource(src => src.FId)
                                                                    .IgnoreSource(src => src.PId)
                                                                    .IgnoreSource(src => src.SILCL)
                                                                    .IgnoreSource(src => src.SILCLId)
                                                                    .IgnoreSource(src => src.SILresult)
                                                                    .IgnoreSource(src => src.SILresultId)
                                                                    .IgnoreSource(src => src.Se)
                                                                    .IgnoreSource(src => src.SeId)
                                                                    .IgnoreSource(src => src.Fr)
                                                                    .IgnoreSource(src => src.FrId)
                                                                    .IgnoreSource(src => src.Pr)
                                                                    .IgnoreSource(src => src.PrId)
                                                                    .IgnoreSource(src => src.Av)
                                                                    .IgnoreSource(src => src.AvId)
                                                                    .IgnoreSource(src => src.CurrentStateId)
                                                                    .Ignore(dest => dest.InputSubsystem)
                                                                    .Ignore(dest => dest.Communication1Subsystem)
                                                                    .Ignore(dest => dest.LogicSubsystem)
                                                                    .Ignore(dest => dest.Communication2Subsystem)
                                                                    .Ignore(dest => dest.OutputSubsystem)
                                                                    .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                                    .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                                    .ReverseMap();
        }
    }
}
