using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("MachineType")]
    public class MachineType : CodeListEntityBase
    {
        [Required]
        [StringLength(50)]
        public string NameCZ { get; set; }

        [StringLength(50)]
        public string NameEN { get; set; }

        [StringLength(200)]
        public string DescriptionCZ { get; set; }

        [StringLength(200)]
        public string DescriptionEN { get; set; }
    }
}
