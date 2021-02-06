using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("Se")]
    public class Se : EntityBase
    {
        [StringLength(50)]
        public string Description { get; set; }

        public short Value { get; set; }

        public ICollection<SafetyFunction> SafetyFunctions { get; set; }
    }
}
