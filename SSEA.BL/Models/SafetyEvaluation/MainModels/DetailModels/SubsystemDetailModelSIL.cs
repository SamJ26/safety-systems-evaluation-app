using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SubsystemDetailModelSIL : SubsystemDetailModel
    {
        public double T1 { get; set; }
        public double T2 { get; set; }
        public short HFT { get; set; }
        public double CFF { get; set; }
        public double ResultantSFF { get; set; }
        public double CalculatedPFHd { get; set; }

        [Required]
        public ArchitectureModel Architecture { get; set; }

        public PFHdModel ResultantPFHd { get; set; }

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
                                                           .IgnoreSource(src => src.ResultantMTTFd)
                                                           .IgnoreSource(src => src.ResultantMTTFdId)
                                                           .IgnoreSource(src => src.ResultantDC)
                                                           .IgnoreSource(src => src.ResultantDCId)
                                                           .IgnoreSource(src => src.ResultantPL)
                                                           .IgnoreSource(src => src.ResultantPLId)
                                                           .IgnoreSource(src => src.ArchitectureId)
                                                           .IgnoreSource(src => src.ResultantPFHdId)
                                                           .IgnoreSource(src => src.CurrentStateId)
                                                           .Ignore(dest => dest.SelectedCCFs)
                                                           .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                           .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                           .ReverseMap();
        }
    }
}
