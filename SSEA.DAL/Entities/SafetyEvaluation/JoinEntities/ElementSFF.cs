using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    [Table("ElementSFF")]
    public class ElementSFF : EntityBase
    {
        [Column("Element_Id")]
        public int ElementId { get; set; }

        [Column("SFF_Id")]
        public int SFFId { get; set; }

        public Element Element { get; set; }
        public SFF SFF { get; set; }
    }
}
