using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class SModel : CodeListModelBase
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class SModelMapperProfile : Profile
    {
        public SModelMapperProfile()
        {
            CreateMap<S, SModel>().IgnoreSource(src => src.DescriptionEN)
                                  .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                  .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                  .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                  .ReverseMap();
        }
    }
}
