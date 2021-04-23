using AutoMapper;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class PLModel : CodeListModelBase
    {
        public string Label { get; set; }
        public short CompareValue { get; set; }
    }

    public class PLModelMapperProfile : Profile
    {
        public PLModelMapperProfile()
        {
            CreateMap<PerformanceLevel, PLModel>().ReverseMap();
        }
    }
}
