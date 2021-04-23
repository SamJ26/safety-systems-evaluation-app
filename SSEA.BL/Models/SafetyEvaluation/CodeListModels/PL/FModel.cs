using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class FModel : CodeListModelBase
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class FModelMapperProfile : Profile
    {
        public FModelMapperProfile()
        {
            CreateMap<F, FModel>().IgnoreSource(src => src.DescriptionCZ)
                                  .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                  .ReverseMap();
        }
    }
}
