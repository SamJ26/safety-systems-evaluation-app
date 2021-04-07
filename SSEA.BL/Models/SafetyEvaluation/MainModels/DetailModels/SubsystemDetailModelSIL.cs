using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SubsystemDetailModelSIL : ExtendedModelBase
    {
        public bool IsUsed { get; set; } = false;
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double SFFresult { get; set; }

        [Required]
        public TypeOfSubsystemModel TypeOfSubsystem { get; set; }

        [Required]
        public OperationPrincipleModel OperationPrinciple { get; set; }

        [Required]
        public ArchitectureModel Architecture { get; set; }

        public short HFT { get; set; }
        public double CFF { get; set; }
        public PFHdModel PFHdResult { get; set; }

        public HashSet<CCFModel> SelectedCCFs { get; set; }
        public ICollection<ElementDetailModelSIL> Elements { get; set; }
    }

    public class SubsystemDetailModelSILMapperProfile : Profile
    {
        public SubsystemDetailModelSILMapperProfile()
        {
            CreateMap<Subsystem, SubsystemDetailModelSIL>().IgnoreSource(src => src.TypeOfSubsystemId)
                                                           .IgnoreSource(src => src.OperationPrincipleId)
                                                           .IgnoreSource(src => src.SafetyFunctionSubsystems)
                                                           .IgnoreSource(src => src.SubsystemCCFs)
                                                           .IgnoreSource(src => src.ValidCCF)
                                                           .IgnoreSource(src => src.Category)
                                                           .IgnoreSource(src => src.CategoryId)
                                                           .IgnoreSource(src => src.MTTFdResult)
                                                           .IgnoreSource(src => src.MTTFdResultId)
                                                           .IgnoreSource(src => src.DCresult)
                                                           .IgnoreSource(src => src.DCresultId)
                                                           .IgnoreSource(src => src.PLresult)
                                                           .IgnoreSource(src => src.PLresultId)
                                                           .IgnoreSource(src => src.ArchitectureId)
                                                           .IgnoreSource(src => src.PFHdResultId)
                                                           .Ignore(dest => dest.SelectedCCFs)
                                                           .IgnoreSource(src => src.CurrentStateId)
                                                           .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                           .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                           .ReverseMap();
        }
    }
}
