using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics
{
    /// <summary>
    /// This class represents severity of injury parameter
    /// </summary>
    [Table("S")]
    public class S : EntityBase
    {
        [StringLength(2)]
        public string Value { get; set; }

        [StringLength(30)]
        public string Description { get; set; }

        public ICollection<SafetyFunction> SafetyFunctions { get; set; }
    }
}
