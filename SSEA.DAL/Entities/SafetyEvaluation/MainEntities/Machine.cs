﻿using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("Machine")]
    public class Machine : ExtendedEntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool SafetyCommunication { get; set; }
        public bool HMI { get; set; }
        public bool PLC { get; set; }
        public bool MachineHelp { get; set; }
        public bool CodeProtection { get; set; }
        public bool SecurityOfSafetyParts { get; set; }
        public bool SafetyMasterInPlace { get; set; }

        [Column("Producer_Id")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        [Column("EvaluationMethod_Id")]
        public int EvaluationMethodId { get; set; }
        public EvaluationMethod EvaluationMethod { get; set; }

        [Column("MachineType_Id")]
        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; }

        [Column("TypeOfLogic_Id")]
        public int? TypeOfLogicId { get; set; }
        public TypeOfLogic TypeOfLogic { get; set; }

        public ICollection<AccessPoint> AccessPoints { get; set; }
        public ICollection<MachineNorm> MachineNorms { get; set; }
    }
}
