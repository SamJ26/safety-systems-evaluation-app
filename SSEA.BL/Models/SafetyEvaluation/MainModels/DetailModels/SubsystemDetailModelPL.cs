using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SubsystemDetailModelPL : ExtendedModelBase
    {
        public bool ValidCCF { get; set; }

        [Required]
        public TypeOfSubsystemModel TypeOfSubsystem { get; set; }

        [Required]
        public CategoryModel Category { get; set; }

        public MTTFdModel MTTFdResult { get; set; }
        public DCModel DCresult { get; set; }
        public PLModel PLresult { get; set; }

        public HashSet<CCFModel> SelectedCCFs { get; set; }
        public ICollection<ElementDetailModelPL> Elements { get; set; }
    }

    public class SubsystemDetailModelPLMapperProfile : Profile
    {
        public SubsystemDetailModelPLMapperProfile()
        {
            CreateMap<Subsystem, SubsystemDetailModelPL>().IgnoreSource(src => src.TypeOfSubsystemId)
                                                          .IgnoreSource(src => src.SafetyFunctionSubsystems)
                                                          .IgnoreSource(src => src.SubsystemCCFs)
                                                          .IgnoreSource(src => src.CategoryId)
                                                          .IgnoreSource(src => src.MTTFdResultId)
                                                          .IgnoreSource(src => src.DCresultId)
                                                          .IgnoreSource(src => src.PLresultId)
                                                          .IgnoreSource(src => src.T1)
                                                          .IgnoreSource(src => src.T2)
                                                          .IgnoreSource(src => src.HFT)
                                                          .IgnoreSource(src => src.SFFresult)
                                                          .IgnoreSource(src => src.ArchitectureId)
                                                          .IgnoreSource(src => src.Architecture)
                                                          .IgnoreSource(src => src.PFHdResultId)
                                                          .IgnoreSource(src => src.PFHdResult)
                                                          .IgnoreSource(src => src.CFFId)
                                                          .IgnoreSource(src => src.CFF)
                                                          .Ignore(dest => dest.SelectedCCFs)
                                                          .IgnoreSource(src => src.CurrentStateId)
                                                          .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                          .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                          .ReverseMap();
        }
    }
}
