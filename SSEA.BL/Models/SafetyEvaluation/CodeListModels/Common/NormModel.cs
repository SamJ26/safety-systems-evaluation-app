using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class NormModel : CodeListModelBase
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public string CatalogNumber { get; set; }
        public string NormCategory { get; set; }
    }
}
