using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class ArchitectureModel : CodeListModelBase
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public bool Logic { get; set; }
        public bool Diagnostic { get; set; }
        public short HFT { get; set; }
        public short Channels { get; set; }
        public short CompareValue { get; set; }
        public double MinSFF { get; set; }
        public double MaxSFF { get; set; }
        public PFHdModel MaxPFHd { get; set; }
    }

    public class ArchitectureModelMapperProfile : Profile
    {
        public ArchitectureModelMapperProfile()
        {
            CreateMap<Architecture, ArchitectureModel>().IgnoreSource(src => src.DescriptionEN)
                                                        .IgnoreSource(src => src.MaxPFHdId)
                                                        .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                                        .ReverseMap();
        }
    }
}
