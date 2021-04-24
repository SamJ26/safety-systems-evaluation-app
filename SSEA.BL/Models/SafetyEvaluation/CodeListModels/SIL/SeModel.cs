using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class SeModel : CodeListModelBase
    {
        public string Description { get; set; }
        public short Value { get; set; }
    }

    public class SeModelMapperProfile : Profile
    {
        public SeModelMapperProfile()
        {
            CreateMap<Se, SeModel>().IgnoreSource(src => src.DescriptionCZ)
                                    .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                    .ReverseMap();
        }
    }
}
