using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class EvaluationMethodModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Shortcut { get; set; }
    }

    public class EvaluationMethodModelMapperProfile : Profile
    {
        public EvaluationMethodModelMapperProfile()
        {
            CreateMap<EvaluationMethod, EvaluationMethodModel>().IgnoreSource(src => src.NameEN)
                                                                .MapMember(dest => dest.Name, src => src.NameCZ)
                                                                .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                                .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                                .ReverseMap();
        }
    }
}
