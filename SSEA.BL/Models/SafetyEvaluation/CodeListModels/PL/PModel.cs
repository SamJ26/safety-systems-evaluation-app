using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class PModel : CodeListModelBase
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class PModelMapperProfile : Profile
    {
        public PModelMapperProfile()
        {
            CreateMap<P, PModel>().IgnoreSource(src => src.DescriptionCZ)
                                  .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                  .ReverseMap();
        }
    }
}
