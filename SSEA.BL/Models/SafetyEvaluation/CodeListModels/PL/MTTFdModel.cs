using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class MTTFdModel : CodeListModelBase
    {
        public string Value { get; set; }
        public short Min { get; set; }
        public short Max { get; set; }
        public short CompareValue { get; set; }
    }

    public class MTTFdModelMapperProfile : Profile
    {
        public MTTFdModelMapperProfile()
        {
            CreateMap<MTTFd, MTTFdModel>().IgnoreSource(src => src.ValueCZ)
                                          .MapMember(dest => dest.Value, src => src.ValueEN)
                                          .ReverseMap();
        }
    }
}
