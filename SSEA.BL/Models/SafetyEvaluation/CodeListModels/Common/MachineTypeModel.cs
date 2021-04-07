using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class MachineTypeModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class MachineTypeModelMapperProfile : Profile
    {
        public MachineTypeModelMapperProfile()
        {
            CreateMap<MachineType, MachineTypeModel>().IgnoreSource(src => src.NameEN)
                                                      .IgnoreSource(src => src.DescriptionEN)
                                                      .MapMember(dest => dest.Name, src => src.NameCZ)
                                                      .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                                      .ReverseMap();
        }
    }
}
