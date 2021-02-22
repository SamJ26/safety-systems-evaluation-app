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
        public int ElementId { get; set; }
        public int SFFId { get; set; }

        public Element Element { get; set; }
        public SFF SFF { get; set; }
    }
}
