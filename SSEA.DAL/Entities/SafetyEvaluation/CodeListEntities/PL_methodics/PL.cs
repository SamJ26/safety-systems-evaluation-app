using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics
{
    public class PL : EntityBase
    {
        [StringLength(2)]
        public char Label { get; set; }
    }
}
