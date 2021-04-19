using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SafetyFunctionDetailModelSIL : ExtendedModelBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool UsedOnMachine { get; set; }

        [Required]
        public TypeOfFunctionModel TypeOfFunction { get; set; }

        [Required]
        public EvaluationMethodModel EvaluationMethod { get; set; }

        public PFHdModel SILCL { get; set; }
        public PFHdModel SILresult { get; set; }
        public SeModel Se { get; set; }
        public FrModel Fr { get; set; }
        public PrModel Pr { get; set; }
        public AvModel Av { get; set; }

        public SubsystemDetailModelSIL InputSubsystem { get; set; }
        public SubsystemDetailModelSIL Communication1Subsystem { get; set; }
        public SubsystemDetailModelSIL LogicSubsystem { get; set; }
        public SubsystemDetailModelSIL Communication2Subsystem { get; set; }
        public SubsystemDetailModelSIL OutputSubsystem { get; set; }
    }

    public class SafetyFunctionDetailModelSILMapperProfile : Profile
    {
        public SafetyFunctionDetailModelSILMapperProfile()
        {
            CreateMap<SafetyFunction, SafetyFunctionDetailModelSIL>().IgnoreSource(src => src.TypeOfFunctionId)
                                                                     .IgnoreSource(src => src.EvaluationMethodId)
                                                                     .IgnoreSource(src => src.AccessPointSafetyFunctions)
                                                                     .IgnoreSource(src => src.PLr)
                                                                     .IgnoreSource(src => src.PLrId)
                                                                     .IgnoreSource(src => src.PLresult)
                                                                     .IgnoreSource(src => src.PLresultId)
                                                                     .IgnoreSource(src => src.S)
                                                                     .IgnoreSource(src => src.SId)
                                                                     .IgnoreSource(src => src.F)
                                                                     .IgnoreSource(src => src.FId)
                                                                     .IgnoreSource(src => src.P)
                                                                     .IgnoreSource(src => src.PId)
                                                                     .IgnoreSource(src => src.SILCLId)
                                                                     .IgnoreSource(src => src.SILresultId)
                                                                     .IgnoreSource(src => src.SeId)
                                                                     .IgnoreSource(src => src.FrId)
                                                                     .IgnoreSource(src => src.PrId)
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
