using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class DCModel : CodeListModelBase
    {
        public string Value { get; set; }
        public short Min { get; set; }
        public short Max { get; set; }
        public short CompareValue { get; set; }
    }

    public class DCModelMapperProfile : Profile
    {
        public DCModelMapperProfile()
        {
            CreateMap<DC, DCModel>().IgnoreSource(src => src.ValueEN)
                                    .MapMember(dest => dest.Value, src => src.ValueCZ)
                                    .ReverseMap();
        }
    }
}
