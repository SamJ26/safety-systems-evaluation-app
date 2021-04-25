using AutoMapper;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class PFHdModel : CodeListModelBase
    {
        public short ValueSIL { get; set; }
        public float MinPFHd { get; set; }
        public float MaxPFHd { get; set; }
    }

    public class PFHdModelMapperProfile : Profile
    {
        public PFHdModelMapperProfile()
        {
            CreateMap<PFHd, PFHdModel>().ReverseMap();
        }
    }
}
