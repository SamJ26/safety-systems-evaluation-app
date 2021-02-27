using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class PrModel : CodeListModelBase
    {
        public string Description { get; set; }
        public short Value { get; set; }
    }

    public class PrModelMapperProfile : Profile
    {
        public PrModelMapperProfile()
        {
            CreateMap<Pr, PrModel>().IgnoreSource(src => src.DescriptionEN)
                                    .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                    .ReverseMap();
        }
    }
}
