using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels
{
    public class MachineListModel : ExtendedModelBase
    {
        public string Name { get; set; }
        public bool Communication { get; set; }
        public string EvaluationMethod { get; set; }
        public string MachineType { get; set; }
        public string Producer { get; set; }
        public TypeOfLogicModel TypeOfLogic { get; set; }
    }

    public class MachineListModelMapperProfile : Profile
    {
        public MachineListModelMapperProfile()
        {
            CreateMap<Machine, MachineListModel>().IgnoreSource(src => src.Description)
                                                  .IgnoreSource(src => src.HMI)
                                                  .IgnoreSource(src => src.PLC)
                                                  .IgnoreSource(src => src.MachineHelp)
                                                  .IgnoreSource(src => src.CodeProtection)
                                                  .IgnoreSource(src => src.SecurityOfSafetyParts)
                                                  .IgnoreSource(src => src.SafetyMasterInPlace)
                                                  .IgnoreSource(src => src.AccessPoints)
                                                  .IgnoreSource(src => src.MachineNorms)
                                                  .MapMember(dest => dest.EvaluationMethod, src => src.EvaluationMethod.Shortcut)
                                                  .MapMember(dest => dest.MachineType, src => src.MachineType.NameCZ)
                                                  .MapMember(dest => dest.Producer, src => src.Producer.Name)
                                                  .ReverseMap();
        }
    }
}
