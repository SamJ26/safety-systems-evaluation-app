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
                                                        .IgnoreSource(src => src.MTTFdResult)
                                                        .IgnoreSource(src => src.MTTFdResultId)
                                                        .IgnoreSource(src => src.DCresult)
                                                        .IgnoreSource(src => src.DCresultId)
                                                        .IgnoreSource(src => src.PLresult)
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
                                                        .IgnoreSource(src => src.CurrentStateId)
                                                        .MapMember(dest => dest.TypeOfSubsystem, src => src.TypeOfSubsystem.NameCZ)
                                                        .MapMember(dest => dest.OperationPrinciple, src => src.OperationPrinciple.NameCZ)
                                                        .MapMember(dest => dest.Category, src => src.Category.Label)
                                                        .MapMember(dest => dest.MTTFd, src => src.MTTFdResult.ValueCZ)
                                                        .MapMember(dest => dest.DC, src => src.DCresult.ValueCZ)
                                                        .MapMember(dest => dest.PL, src => src.PLresult.Label)
                                                        .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                        .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                        .ReverseMap();

        }
    }
}
