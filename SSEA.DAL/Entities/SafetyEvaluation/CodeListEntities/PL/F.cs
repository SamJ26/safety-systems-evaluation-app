using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL
{
    /// <summary>
    /// This class represents frequency and/or exposure to hazard parameter
    /// </summary>
    [Table("F")]
    public class F : CodeListEntityBase
    {
        [StringLength(2)]
        public string Value { get; set; }

        [StringLength(30)]
        public string Description { get; set; }

        public ICollection<SafetyFunction> SafetyFunctions { get; set; }
    }
}
