using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class TypeOfSubsystemModel : CodeListModelBase
    {
        public string Name { get; set; }
    }

    public class TypeOfSubsystemModelMapperProfile : Profile
    {
        public TypeOfSubsystemModelMapperProfile()
        {
            CreateMap<TypeOfSubsystem, TypeOfSubsystemModel>().IgnoreSource(src => src.NameEN)
                                                              .MapMember(dest => dest.Name, src => src.NameCZ)
                                                              .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                              .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                              .ReverseMap();
        }
    }
}
