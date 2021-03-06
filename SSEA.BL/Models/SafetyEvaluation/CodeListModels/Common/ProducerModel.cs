﻿using AutoMapper;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class ProducerModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
    }

    public class ProducerModelMapperProfile : Profile
    {
        public ProducerModelMapperProfile()
        {
            CreateMap<Producer, ProducerModel>().ReverseMap();
        }
    }
}
