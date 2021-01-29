using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics
{
    public class Se : EntityBase
    {
        [StringLength(50)]
        public string Description { get; set; }

        public short Value { get; set; }
    }
}
