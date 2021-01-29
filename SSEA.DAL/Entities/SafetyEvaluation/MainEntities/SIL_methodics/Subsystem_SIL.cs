using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.SIL_methodics
{
    public class Subsystem_SIL : ExtendedEntityBase
    {
        [StringLength(50)]
        public string CatalogNumber { get; set; }

        public double T1 { get; set; }
        public double T2 { get; set; }
        public double SFF_result { get; set; }

        //public virtual TypeOfSubsystem TypeOfSubsystem { get; set; }
        //public virtual Architecture Category { get; set; }
        //public virtual Producer Producer { get; set; }
        //public virtual HFT HFT { get; set; }
        //public virtual PFHd PFHd_result { get; set; }
        //public virtual CFF CFF { get; set; }
        //public virtual ICollection<Element_SIL> Elements { get; set; }
        //public virtual ICollection<SafetyFunctionSubsystem> Subsystems { get; set; }
        //public virtual ICollection<CCF> CCFs { get; set; }
    }
}
