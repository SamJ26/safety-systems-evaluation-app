using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels
{
    public class SubsystemListModelPL : ExtendedModelBase
    {
        public string TypeOfSubsystem { get; set; }
        public string OperationPrinciple { get; set; }
        public string Category { get; set; }
        public string MTTFd { get; set; }
        public string DC { get; set; }
        public string PL { get; set; }
    }

    public class SubsystemListModelPLMapperProfile : Profile
    {
        public SubsystemListModelPLMapperProfile()
        {
            CreateMap<Subsystem, SubsystemListModelPL>().IgnoreSource(src => src.TypeOfSubsystemId)
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
                                                        .IgnoreSource(src => src.HFT)
                                                        .IgnoreSource(src => src.ResultantSFF)
                                                        .IgnoreSource(src => src.ArchitectureId)
                                                        .IgnoreSource(src => src.Architecture)
                                                        .IgnoreSource(src => src.ResultantPFHdId)
                                                        .IgnoreSource(src => src.ResultantPFHd)
                                                        .IgnoreSource(src => src.CFF)
                                                        .IgnoreSource(src => src.CurrentStateId)
                                                        .IgnoreSource(src => src.CalculatedPFHd)
                                                        .MapMember(dest => dest.TypeOfSubsystem, src => src.TypeOfSubsystem.NameEN)
                                                        .MapMember(dest => dest.OperationPrinciple, src => src.OperationPrinciple.NameEN)
                                                        .MapMember(dest => dest.Category, src => src.Category.Label)
                                                        .MapMember(dest => dest.MTTFd, src => src.ResultantMTTFd.ValueEN)
                                                        .MapMember(dest => dest.DC, src => src.ResultantDC.ValueEN)
                                                        .MapMember(dest => dest.PL, src => src.ResultantPL.Label)
                                                        .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                        .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                        .ReverseMap();
        }
    }
}
