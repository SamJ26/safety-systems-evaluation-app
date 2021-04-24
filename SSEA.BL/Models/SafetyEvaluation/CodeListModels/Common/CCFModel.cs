using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class CCFModel : CodeListModelBase
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public uint Points { get; set; }
    }

    public class CCFModelMapperProfile : Profile
    {
        public CCFModelMapperProfile()
        {
            CreateMap<CCF, CCFModel>().IgnoreSource(src => src.DescriptionEN)
                                      .IgnoreSource(src => src.TypeEN)
                                      .IgnoreSource(src => src.ForPL)
                                      .IgnoreSource(src => src.SubsystemCCFs)
                                      .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                      .MapMember(dest => dest.Type, src => src.TypeCZ)
                                      .ReverseMap();
        }
    }
}
