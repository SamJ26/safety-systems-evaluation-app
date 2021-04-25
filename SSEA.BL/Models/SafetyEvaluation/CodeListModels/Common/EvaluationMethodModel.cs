using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class EvaluationMethodModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Shortcut { get; set; }
    }

    public class EvaluationMethodModelMapperProfile : Profile
    {
        public EvaluationMethodModelMapperProfile()
        {
            CreateMap<EvaluationMethod, EvaluationMethodModel>().IgnoreSource(src => src.NameCZ)
                                                                .MapMember(dest => dest.Name, src => src.NameEN)
                                                                .ReverseMap();
        }
    }
}
