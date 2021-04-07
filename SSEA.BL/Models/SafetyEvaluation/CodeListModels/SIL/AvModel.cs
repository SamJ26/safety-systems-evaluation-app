using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class AvModel : CodeListModelBase
    {
        public string Description { get; set; }
        public short Value { get; set; }
    }

    public class AvModelMapperProfile : Profile
    {
        public AvModelMapperProfile()
        {
            CreateMap<Av, AvModel>().IgnoreSource(src => src.DescriptionEN)
                                    .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                    .ReverseMap();
        }
    }
}
