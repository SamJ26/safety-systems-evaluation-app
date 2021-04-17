using AutoMapper;
using Newtonsoft.Json;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class MachineDetailModel : ExtendedModelBase
    {
        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool Communication { get; set; }
        public bool HMI { get; set; }
        public bool PLC { get; set; }
        public bool MachineHelp { get; set; }
        public bool CodeProtection { get; set; }
        public bool SecurityOfSafetyParts { get; set; }
        public bool SafetyMasterInPlace { get; set; }

        [Required]
        public EvaluationMethodModel EvaluationMethod { get; set; }

        [Required]
        public MachineTypeModel MachineType { get; set; }

        [Required]
        public ProducerModel Producer { get; set; }

        public TypeOfLogicModel TypeOfLogic { get; set; }

        public ICollection<AccessPointListModel> AccessPoints { get; set; }
        public HashSet<NormModel> Norms { get; set; }
    }

    public class MachineDetailModelMapperProfile : Profile
    {
        public MachineDetailModelMapperProfile()
        {
            CreateMap<Machine, MachineDetailModel>().IgnoreSource(src => src.ProducerId)
                                                    .IgnoreSource(src => src.EvaluationMethodId)
                                                    .IgnoreSource(src => src.MachineTypeId)
                                                    .IgnoreSource(src => src.TypeOfLogicId)
                                                    .IgnoreSource(src => src.CurrentStateId)
                                                    .IgnoreSource(src => src.MachineNorms)
                                                    .Ignore(dest => dest.Norms)
                                                    .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                    .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                    .ReverseMap();
        }
    }
}
