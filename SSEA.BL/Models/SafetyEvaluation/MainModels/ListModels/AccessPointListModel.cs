﻿using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;

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
                                                          .IgnoreSource(src => src.CurrentStateId)
                                                          .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                          .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                          .ReverseMap();
        }
    }
}
