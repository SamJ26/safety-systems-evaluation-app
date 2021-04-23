using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class CategoryModel : CodeListModelBase
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string FailureBehavior { get; set; }
        public bool Logic { get; set; }
        public bool RelevantCCF { get; set; }
        public short Channels { get; set; }
        public short CompareValue { get; set; }
        public MTTFdModel MinMTTFd { get; set; }
        public MTTFdModel MaxMTTFd { get; set; }
        public DCModel MinDC { get; set; }
        public DCModel MaxDC { get; set; }
    }

    public class CategoryModelMapperProfile : Profile
    {
        public CategoryModelMapperProfile()
        {
            CreateMap<Category, CategoryModel>().IgnoreSource(src => src.DescriptionCZ)
                                                .IgnoreSource(src => src.RequirementsCZ)
                                                .IgnoreSource(src => src.FailureBehaviorCZ)
                                                .IgnoreSource(src => src.MinMTTFdId)
                                                .IgnoreSource(src => src.MaxMTTFdId)
                                                .IgnoreSource(src => src.MinDCId)
                                                .IgnoreSource(src => src.MaxDCId)
                                                .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                                .MapMember(dest => dest.Requirements, src => src.RequirementsEN)
                                                .MapMember(dest => dest.FailureBehavior, src => src.FailureBehaviorEN)
                                                .ReverseMap();
        }
    }
}