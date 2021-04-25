using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SubsystemDetailModelPL : SubsystemDetailModel
    {
        public bool ValidCCF { get; set; }     

        [Required]
        public CategoryModel Category { get; set; }

        public MTTFdModel ResultantMTTFd { get; set; }
        public DCModel ResultantDC { get; set; }
        public PLModel ResultantPL { get; set; }

        public ICollection<ElementDetailModelPL> Elements { get; set; }
    }

    public class SubsystemDetailModelPLMapperProfile : Profile
    {
        public SubsystemDetailModelPLMapperProfile()
        {
            CreateMap<Subsystem, SubsystemDetailModelPL>().IgnoreSource(src => src.TypeOfSubsystemId)
                                                          .IgnoreSource(src => src.OperationPrincipleId)
                                                          .IgnoreSource(src => src.SafetyFunctionSubsystems)
                                                          .IgnoreSource(src => src.SubsystemCCFs)
                                                          .IgnoreSource(src => src.CategoryId)
                                                          .IgnoreSource(src => src.ResultantMTTFdId)
                                                          .IgnoreSource(src => src.ResultantDCId)
                                                          .IgnoreSource(src => src.ResultantPLId)
                                                          .IgnoreSource(src => src.T1)
                                                          .IgnoreSource(src => src.T2)
                                                          .IgnoreSource(src => src.HFT)
                                                          .IgnoreSource(src => src.ResultantSFF)
                                                          .IgnoreSource(src => src.ArchitectureId)
                                                          .IgnoreSource(src => src.Architecture)
                                                          .IgnoreSource(src => src.ResultantPFHdId)
                                                          .IgnoreSource(src => src.ResultantPFHd)
                                                          .IgnoreSource(src => src.CFF)
                                                          .IgnoreSource(src => src.CurrentStateId)
                                                          .IgnoreSource(src => src.CalculatedPFHd)
                                                          .Ignore(dest => dest.SelectedCCFs)
                                                          .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                          .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                          .ReverseMap();
        }
    }
}
