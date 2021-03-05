using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class SeModel : CodeListModelBase
    {
        public string Description { get; set; }
        public short Value { get; set; }
    }

    public class SeModelMapperProfile : Profile
    {
        public SeModelMapperProfile()
        {
            CreateMap<Se, SeModel>().IgnoreSource(src => src.DescriptionEN)
                                    .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                    .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                    .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                    .ReverseMap();
        }
    }
}
