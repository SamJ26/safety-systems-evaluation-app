using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.PL_methodics
{
    public class Subsystem_PL : ExtendedEntityBase
    {
        [StringLength(50)]
        public string CatalogNumber { get; set; }

        // public virtual TypeOfSubsystem TypeOfSubsystem { get; set; }
        // public virtual Category Category { get; set; }
        // public virtual MTTFd MTTFd_result { get; set; }
        // public virtual DC DC_result { get; set; }
        // public virtual PL PL_result { get; set; }
        // public virtual bool CCF_valid { get; set; }
        // public virtual ICollection<Element_PL> Elements { get; set; }
        // public virtual ICollection<SafetyFunctionSubsystem> SafetyFunctions { get; set; }
        // public virtual ICollection<CCF> CCFs { get; set; }
    }
}
