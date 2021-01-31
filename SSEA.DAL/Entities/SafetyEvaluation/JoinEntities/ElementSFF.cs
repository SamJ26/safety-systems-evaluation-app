using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics;
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
        public int ElementId { get; set; }
        public int SFF_Id { get; set; }

        [Column("Element_Id")]
        public Element Element { get; set; }

        [Column("SFF_Id")]
        public SFF SFF { get; set; }
    }
}
