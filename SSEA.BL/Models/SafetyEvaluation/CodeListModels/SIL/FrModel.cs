using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class FrModel : CodeListModelBase
    {
        public string FrequencyOfThreat { get; set; }
        public short Value { get; set; }
    }

    public class FrModelMapperProfile : Profile
    {
        public FrModelMapperProfile()
        {
            CreateMap<Fr, FrModel>().IgnoreSource(src => src.FrequencyOfThreatEN)
                                    .MapMember(dest => dest.FrequencyOfThreat, src => src.FrequencyOfThreatCZ)
                                    .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                    .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                    .ReverseMap();
        }
    }
}
