using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL
{
    /// <summary>
    /// This class represents severity of injury parameter
    /// </summary>
    [Table("S")]
    public class S : CodeListEntityBase
    {
        [StringLength(2)]
        public string Value { get; set; }

        [StringLength(30)]
        public string DescriptionCZ { get; set; }

        [StringLength(30)]
        public string DescriptionEN { get; set; }
    }
}
