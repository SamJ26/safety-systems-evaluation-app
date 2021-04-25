using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels
{
    public class SubsystemListModelSIL : ExtendedModelBase
    {
        public string TypeOfSubsystem { get; set; }
        public string OperationPrinciple { get; set; }
        public string Architecture { get; set; }
        public double HFT { get; set; }
        public short SFF { get; set; }
        public string SIL { get; set; }
    }

    public class SubsystemListModelSILMapperProfile : Profile
    {
        public SubsystemListModelSILMapperProfile()
        {
            CreateMap<Subsystem, SubsystemListModelSIL>().IgnoreSource(src => src.TypeOfSubsystemId)
                                                         .IgnoreSource(src => src.OperationPrincipleId)
                                                         .IgnoreSource(src => src.SafetyFunctionSubsystems)
                                                         .IgnoreSource(src => src.Elements)
                                                         .IgnoreSource(src => src.SubsystemCCFs)
                                                         .IgnoreSource(src => src.ValidCCF)
                                                         .IgnoreSource(src => src.CategoryId)
                                                         .IgnoreSource(src => src.Category)
                                                         .IgnoreSource(src => src.ResultantMTTFd)
                                                         .IgnoreSource(src => src.ResultantMTTFdId)
                                                         .IgnoreSource(src => src.ResultantDC)
                                                         .IgnoreSource(src => src.ResultantDCId)
                                                         .IgnoreSource(src => src.ResultantPL)
                                                         .IgnoreSource(src => src.ResultantPLId)
                                                         .IgnoreSource(src => src.T1)
                                                         .IgnoreSource(src => src.T2)
                                                         .IgnoreSource(src => src.ResultantSFF)
                                                         .IgnoreSource(src => src.ArchitectureId)
                                                         .IgnoreSource(src => src.Architecture)
                                                         .IgnoreSource(src => src.ResultantPFHdId)
                                                         .IgnoreSource(src => src.ResultantPFHd)
                                                         .IgnoreSource(src => src.CFF)
                                                         .IgnoreSource(src => src.CalculatedPFHd)
                                                         .IgnoreSource(src => src.CurrentStateId)
                                                         .MapMember(dest => dest.TypeOfSubsystem, src => src.TypeOfSubsystem.NameEN)
                                                         .MapMember(dest => dest.OperationPrinciple, src => src.OperationPrinciple.NameEN)
                                                         .MapMember(dest => dest.Architecture, src => src.Architecture.Label)
                                                         .MapMember(dest => dest.SFF, src => src.ResultantSFF)
                                                         .MapMember(dest => dest.SIL, src => src.ResultantPFHd.ValueSIL)
                                                         .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                         .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                         .ReverseMap();
        }
    }
}
