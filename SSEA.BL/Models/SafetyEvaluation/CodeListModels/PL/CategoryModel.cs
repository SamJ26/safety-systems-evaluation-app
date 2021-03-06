using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class CategoryModel : CodeListModelBase
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string FailureBehavior { get; set; }
        public bool Logic { get; set; }
        public short Channels { get; set; }
        public bool RelevantCCF { get; set; }
        public string MinMTTFd { get; set; }
        public string MaxMTTFd { get; set; }
        public string MinDC { get; set; }
        public string MaxDC { get; set; }
    }

    public class CategoryModelMapperProfile : Profile
    {
        public CategoryModelMapperProfile()
        {
            CreateMap<Category, CategoryModel>().IgnoreSource(src => src.DescriptionEN)
                                                .IgnoreSource(src => src.RequirementsEN)
                                                .IgnoreSource(src => src.FailureBehaviorEN)
                                                .IgnoreSource(src => src.MinMTTFdId)
                                                .IgnoreSource(src => src.MaxMTTFdId)
                                                .IgnoreSource(src => src.MinDCId)
                                                .IgnoreSource(src => src.MaxDCId)
                                                .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                                .MapMember(dest => dest.Requirements, src => src.RequirementsCZ)
                                                .MapMember(dest => dest.DateTimeCreated, src => src.DateTimeCreated.ToString())
                                                .MapMember(dest => dest.DateTimeUpdated, src => src.DateTimeUpdated.ToString())
                                                .MapMember(dest => dest.MinMTTFd, src => src.MinMTTFd.ValueCZ)
                                                .MapMember(dest => dest.MaxMTTFd, src => src.MaxMTTFd.ValueCZ)
                                                .MapMember(dest => dest.MinDC, src => src.MinDC.ValueCZ)
                                                .MapMember(dest => dest.MaxDC, src => src.MaxDC.ValueCZ)
                                                .ReverseMap();
        }
    }
}