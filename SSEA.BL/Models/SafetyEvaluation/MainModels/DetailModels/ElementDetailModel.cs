using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public abstract class ElementDetailModel : ExtendedModelBase
    {
        public string CatalogNumber { get; set; }
        public double B10d { get; set; }
        public ProducerModel Producer { get; set; }
        public DCModel DC { get; set; }
    }
}
