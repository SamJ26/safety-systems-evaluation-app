using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

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
                                                              .ReverseMap();
        }
    }
}
