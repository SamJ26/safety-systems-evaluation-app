using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class AccessPointDetailModel : ExtendedModelBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public MachineListModel Machine { get; set; }

        public ICollection<AccessPointSafetyFunctionModel> AccessPointSafetyFunctions { get; set; }
    }

    public class AccessPointDetailModelMapperProfile : Profile
    {
        public AccessPointDetailModelMapperProfile()
        {
            CreateMap<AccessPoint, AccessPointDetailModel>().IgnoreSource(src => src.MachineId)
                                                            .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                            .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                            .ReverseMap();

        }
    }
}
