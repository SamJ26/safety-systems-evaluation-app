using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics
{
    public class Category : EntityBase
    {
        [Required]
        [StringLength(1)]
        public char Label { get; set; }

        [Required]
        public bool Logic { get; set; }

        [Required]
        public uint Channels { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public bool CCF_relevant { get; set; }

        [StringLength(250)]
        public string Requirements { get; set; }

        [StringLength(250)]
        public string FailureBehavior { get; set; }

        [Required]
        public MTTFd MTTFd_min { get; set; }

        [Required]
        public MTTFd MTTFd_max { get; set; }

        [Required]
        public DC DC_min { get; set; }

        [Required]
        public DC DC_max { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}
