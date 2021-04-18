using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SafetyFunctionDetailModelPL : ExtendedModelBase
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public TypeOfFunctionModel TypeOfFunction { get; set; }

        [Required]
        public EvaluationMethodModel EvaluationMethod { get; set; }

        public PLModel PLr { get; set; }
        public PLModel PLresult { get; set; }
        public SModel S { get; set; }
        public FModel F { get; set; }
        public PModel P { get; set; }

        public SubsystemDetailModelPL InputSubsystem { get; set; }
        public SubsystemDetailModelPL Communication1Subsystem { get; set; }
        public SubsystemDetailModelPL LogicSubsystem { get; set; }
        public SubsystemDetailModelPL Communication2Subsystem { get; set; }
        public SubsystemDetailModelPL OutputSubsystem { get; set; }
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
