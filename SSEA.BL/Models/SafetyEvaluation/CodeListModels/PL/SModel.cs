using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class SModel : CodeListModelBase
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class SModelMapperProfile : Profile
    {
        public SModelMapperProfile()
        {
            CreateMap<S, SModel>().IgnoreSource(src => src.DescriptionCZ)
                                  .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                  .ReverseMap();
        }
    }
}
