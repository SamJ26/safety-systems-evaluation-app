using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.Common
{
    public class Machine : ExtendedEntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public bool Communication { get; set; }
        public bool HMI { get; set; }
        public bool PLC { get; set; }
        public bool MachineHelp { get; set; }
        public bool CodeProtection { get; set; }
        public bool SecurityOfSafetyParts { get; set; }
        public bool SafetyMasterInPlace { get; set; }

        // public virtual EvaluationMethod EvaluationMethod { get; set; }
        // public virtual MachineType MachineType { get; set; }
        // public virtual TypeOfLogic TypeOfLogic { get; set; }
        // public virtual Producer Producer { get; set; }
        // public virtual ICollection<AccessPoint> AccessPoints { get; set; }
    }
}
