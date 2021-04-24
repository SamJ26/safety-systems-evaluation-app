using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

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
        public int SubsystemId { get; set; }
        public uint EthernetAdressesMaxCount { get; set; }
        public PLModel MaxPL { get; set; }
        public CategoryModel MaxCategory { get; set; }
        public PFHdModel MaxSIL { get; set; }
        public ArchitectureModel MaxArchitecture { get; set; }
    }

    public class TypeOfLogicModelMapperProfile : Profile
    {
        public TypeOfLogicModelMapperProfile()
        {
            CreateMap<TypeOfLogic, TypeOfLogicModel>().IgnoreSource(src => src.NameCZ)
                                                      .IgnoreSource(src => src.DescriptionCZ)
                                                      .IgnoreSource(src => src.MaxPLId)
                                                      .IgnoreSource(src => src.MaxCategoryId)
                                                      .IgnoreSource(src => src.MaxSILId)
                                                      .IgnoreSource(src => src.MaxArchitectureId)
                                                      .IgnoreSource(src => src.Subsystem)
                                                      .MapMember(dest => dest.Name, src => src.NameEN)
                                                      .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                                      .ReverseMap();
        }
    }
}
