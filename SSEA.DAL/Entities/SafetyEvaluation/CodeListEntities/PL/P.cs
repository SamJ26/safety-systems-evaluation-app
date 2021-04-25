using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL
{
    /// <summary>
    /// This class represents possibility of avoiding hazard or limiting harm parameter
    /// </summary>
    [Table("P")]
    public class P : CodeListEntityBase
    {
        [StringLength(2)]
        public string Value { get; set; }

        [StringLength(50)]
        public string DescriptionCZ { get; set; }

        [StringLength(50)]
        public string DescriptionEN { get; set; }
    }
}
