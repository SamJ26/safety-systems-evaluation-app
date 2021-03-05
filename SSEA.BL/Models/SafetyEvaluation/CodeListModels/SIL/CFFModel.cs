using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class CFFModel : CodeListModelBase
    {
        public short MinCCF { get; set; }
        public short MaxCCF { get; set; }
        public double Beta { get; set; }
    }

    public class CFFModelMapperProfile : Profile
    {
        public CFFModelMapperProfile()
        {
            CreateMap<CFF, CFFModel>().MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                      .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                      .ReverseMap();
        }
    }
}
