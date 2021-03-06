using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels
{
    public class AccessPointListModel : ExtendedModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public short SafetyFunctionsCount { get; set; }
    }

    public class AccessPointListModelMapperProfile : Profile
    {
        public AccessPointListModelMapperProfile()
        {
            CreateMap<AccessPoint, AccessPointListModel>().IgnoreSource(src => src.Machine)
                                                          .IgnoreSource(src => src.MachineId)
                                                          .MapMember(dest => dest.SafetyFunctionsCount, src => src.AccessPointSafetyFunctions != null ? src.AccessPointSafetyFunctions.Count : 0)
                                                          .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                          .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                          .ReverseMap();
        }
    }
}
