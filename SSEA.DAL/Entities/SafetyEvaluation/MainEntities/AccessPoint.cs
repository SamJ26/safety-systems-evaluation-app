using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("AccessPoint")]
    public class AccessPoint : ExtendedEntityBase
    {
        [Required]
        [StringLength(100)]
        public string ShortName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Column("Machine_Id")]
        public Machine Machine { get; set; }

        public ICollection<AccessPointSafetyFunction> AccessPointSafetyFunctions { get; set; }
    }
}
