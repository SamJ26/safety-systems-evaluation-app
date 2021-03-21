using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels
{
    public class SafetyFunctionListModel : ExtendedModelBase
    {
        public string Name { get; set; }
        public TypeOfFunctionModel TypeOfFunction { get; set; }
        public EvaluationMethodModel EvaluationMethod { get; set; }
    }

    public class SafetyFunctionListModelMapperProfile : Profile
    {
        public SafetyFunctionListModelMapperProfile()
        {
            CreateMap<SafetyFunction, SafetyFunctionListModel>().IgnoreSource(src => src.TypeOfFunctionId)
                                                                .IgnoreSource(src => src.EvaluationMethodId)
                                                                .IgnoreSource(src => src.Description)
                                                                .IgnoreSource(src => src.AccessPointSafetyFunctions)
                                                                .IgnoreSource(src => src.SafetyFunctionSubsystems)
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
