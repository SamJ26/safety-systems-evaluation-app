using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class PrModel : CodeListModelBase
    {
        public string Description { get; set; }
        public short Value { get; set; }
    }

    public class PrModelMapperProfile : Profile
    {
        public PrModelMapperProfile()
        {
            CreateMap<Pr, PrModel>().IgnoreSource(src => src.DescriptionCZ)
                                    .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                    .ReverseMap();
        }
    }
}
