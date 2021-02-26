using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class TypeOfLogicModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SI { get; set; }
        public int SO { get; set; }
        public bool Communication { get; set; }
        public int AccessPointsMaxCount { get; set; }
        public uint EthernetAdressesMaxCount { get; set; }
        public PLModel MaxPL { get; set; }
        public CategoryModel MaxCategory { get; set; }
        public PFHdModel MaxSI { get; set; }
        public ArchitectureModel MaxArchitecture { get; set; }
    }

    public class TypeOfLogicModelMapperProfile : Profile
    {
        public TypeOfLogicModelMapperProfile()
        {
            CreateMap<TypeOfLogic, TypeOfLogicModel>().IgnoreSource(src => src.NameEN)
                                                      .IgnoreSource(src => src.DescriptionEN)
                                                      .IgnoreSource(src => src.MaxPLId)
                                                      .IgnoreSource(src => src.MaxCategoryId)
                                                      .IgnoreSource(src => src.MaxSILId)
                                                      .IgnoreSource(src => src.MaxArchitectureId)
                                                      .MapMember(dest => dest.Name, src => src.NameCZ)
                                                      .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                                      .ReverseMap();
        }
    }
}
