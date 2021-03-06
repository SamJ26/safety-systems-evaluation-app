using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class NormModel : CodeListModelBase
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public string CatalogNumber { get; set; }
        public string NormCategory { get; set; }
    }

    public class NormModelMapperProfile : Profile
    {
        public NormModelMapperProfile()
        {
            CreateMap<Norm, NormModel>().IgnoreSource(src => src.NameEN)
                                        .IgnoreSource(src => src.MachineNorms)
                                        .MapMember(dest => dest.Name, src => src.NameCZ)
                                        .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                        .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                        .ReverseMap();
        }
    }
}
