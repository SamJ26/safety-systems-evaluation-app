using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class OperationPrincipleModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class OperationPrincipleModelMapperProfile : Profile
    {
        public OperationPrincipleModelMapperProfile()
        {
            CreateMap<OperationPrinciple, OperationPrincipleModel>().IgnoreSource(src => src.NameEN)
                                                                    .IgnoreSource(src => src.DescriptionEN)
                                                                    .MapMember(dest => dest.Name, src => src.NameCZ)
                                                                    .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                                                    .ReverseMap();
        }
    }
}
