using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics
{
    /// <summary>
    /// This class represents frequncy and/or exposure to hazard parameter
    /// </summary>
    public class F : EntityBase
    {
        [StringLength(2)]
        public string Value { get; set; }

        [StringLength(30)]
        public string Description { get; set; }
    }
}
