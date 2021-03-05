using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class FModel : CodeListModelBase
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class FModelMapperProfile : Profile
    {
        public FModelMapperProfile()
        {
            CreateMap<F, FModel>().IgnoreSource(src => src.DescriptionEN)
                                  .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                  .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                  .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                  .ReverseMap();
        }
    }
}
