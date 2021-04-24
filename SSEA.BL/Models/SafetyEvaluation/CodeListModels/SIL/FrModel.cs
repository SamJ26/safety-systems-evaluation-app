using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class FrModel : CodeListModelBase
    {
        public string FrequencyOfThreat { get; set; }
        public short Value { get; set; }
    }

    public class FrModelMapperProfile : Profile
    {
        public FrModelMapperProfile()
        {
            CreateMap<Fr, FrModel>().IgnoreSource(src => src.FrequencyOfThreatCZ)
                                    .MapMember(dest => dest.FrequencyOfThreat, src => src.FrequencyOfThreatEN)
                                    .ReverseMap();
        }
    }
}
