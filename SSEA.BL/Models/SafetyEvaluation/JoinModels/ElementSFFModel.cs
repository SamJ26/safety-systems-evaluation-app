using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.JoinModels
{
    public class ElementSFFModel : ModelBase
    {
        public int ElementId { get; set; }
        public int SFFId { get; set; }
    }

    public class ElementSFFModelMapperProfiel : Profile
    {
        public ElementSFFModelMapperProfiel()
        {
            CreateMap<ElementSFF, ElementSFFModel>().IgnoreSource(src => src.Element)
                                                    .IgnoreSource(src => src.SFF)
                                                    .ReverseMap();
        }
    }
}
