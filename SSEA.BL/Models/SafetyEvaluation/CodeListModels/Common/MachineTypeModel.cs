using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class MachineTypeModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class MachineTypeModelMapperProfile : Profile
    {
        public MachineTypeModelMapperProfile()
        {
            CreateMap<MachineType, MachineTypeModel>().IgnoreSource(src => src.NameCZ)
                                                      .IgnoreSource(src => src.DescriptionCZ)
                                                      .MapMember(dest => dest.Name, src => src.NameEN)
                                                      .MapMember(dest => dest.Description, src => src.DescriptionEN)
                                                      .ReverseMap();
        }
    }
}
