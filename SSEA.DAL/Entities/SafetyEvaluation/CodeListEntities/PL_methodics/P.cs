using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics
{
    /// <summary>
    /// This class represents possibility of avoiding hazard or limiting harm parameter
    /// </summary>
    public class P : EntityBase
    {
        [StringLength(2)]
        public string Value { get; set; }

        [StringLength(30)]
        public string Description { get; set; }
    }
}
