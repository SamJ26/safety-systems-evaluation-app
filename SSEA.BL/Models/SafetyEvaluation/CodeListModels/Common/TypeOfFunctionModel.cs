using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class TypeOfFunctionModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TypeOfFunctionModelMapperProfile : Profile
    {
        public TypeOfFunctionModelMapperProfile()
        {
            CreateMap<TypeOfFunction, TypeOfFunctionModel>().IgnoreSource(src => src.NameCZ)
                                                            .IgnoreSource(src => src.DescriptionCZ)
                                                            .MapMember(dest => dest.Name, src => src.NameEN)
                                                            .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                                            .ReverseMap();
        }
    }
}
