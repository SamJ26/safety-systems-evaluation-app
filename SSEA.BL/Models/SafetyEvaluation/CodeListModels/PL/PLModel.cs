using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class PLModel : CodeListModelBase
    {
        public string Label { get; set; }
    }

    public class PLModelMapperProfile : Profile
    {
        public PLModelMapperProfile()
        {
            CreateMap<PerformanceLevel, PLModel>().MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                  .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                  .ReverseMap();
        }
    }
}
