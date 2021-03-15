using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SafetyFunctionDetailModelPL : ExtendedModelBase
    {
        [Required]
        [StringLength(50)]
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

        public ICollection<SafetyFunctionSubsystemModel> SafetyFunctionSubsystems { get; set; }
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
                                                                    .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                                    .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                                    .ReverseMap();
        }
    }
}
