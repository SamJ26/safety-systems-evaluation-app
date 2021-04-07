using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.JoinModels
{
    public class MachineNormModel : ModelBase
    {
        public int MachineId { get; set; }
        public int NormId { get; set; }
    }

    public class MachineNormModelMapperProfile : Profile
    {
        public MachineNormModelMapperProfile()
        {
            CreateMap<MachineNorm, MachineNormModel>().IgnoreSource(src => src.Machine)
                                                      .IgnoreSource(src => src.Norm)
                                                      .ReverseMap();
        }
    }
}
