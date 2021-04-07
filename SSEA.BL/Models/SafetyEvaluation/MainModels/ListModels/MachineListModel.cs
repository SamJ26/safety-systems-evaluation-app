using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels
{
    public class MachineListModel : ExtendedModelBase
    {
        public string Name { get; set; }
        public bool Communication { get; set; }
        public string EvaluationMethod { get; set; }
        public string MachineType { get; set; }
        public string Producer { get; set; }
        public string TypeOfLogic { get; set; }
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
                                                  .IgnoreSource(src => src.CurrentStateId)
                                                  .MapMember(dest => dest.EvaluationMethod, src => src.EvaluationMethod.Shortcut)
                                                  .MapMember(dest => dest.MachineType, src => src.MachineType.NameCZ)
                                                  .MapMember(dest => dest.Producer, src => src.Producer.Name)
                                                  .MapMember(dest => dest.TypeOfLogic, src => src.TypeOfLogic != null ? src.TypeOfLogic.NameCZ : "Not selected")
                                                  .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                  .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                  .ReverseMap();
        }
    }
}
