using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.JoinModels
{
    public class AccessPointSafetyFunctionModel : ModelBase
    {
        public int AccessPointId { get; set; }
        public int SafetyFunctionId { get; set; }
    }

    public class AccessPointSafetyFunctionModelMapperProfile : Profile
    {
        public AccessPointSafetyFunctionModelMapperProfile()
        {
            CreateMap<AccessPointSafetyFunction, AccessPointSafetyFunctionModel>().IgnoreSource(src => src.AccessPoint)
                                                                                  .IgnoreSource(src => src.SafetyFunction)
                                                                                  .ReverseMap();
        }
    }
}
