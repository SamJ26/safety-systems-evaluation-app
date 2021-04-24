using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("AccessPoint")]
    public class AccessPoint : ExtendedEntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column("Machine_Id")]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public ICollection<AccessPointSafetyFunction> AccessPointSafetyFunctions { get; set; }
    }
}
