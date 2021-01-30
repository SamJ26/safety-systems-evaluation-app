using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    public class ElementSFF : EntityBase
    {
        public int ElementId { get; set; }
        public Element Element { get; set; }
        public int SFF_Id { get; set; }
        public SFF SFF { get; set; }
    }
}
