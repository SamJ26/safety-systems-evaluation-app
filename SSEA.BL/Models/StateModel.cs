﻿using AutoMapper;
using SSEA.BL.Extensions;
using SSEA.DAL.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models
{
    public class StateModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StateNumber { get; set; }
        public bool Valid { get; set; }
    }

    public class StateModelMapperProfile : Profile
    {
        public StateModelMapperProfile()
        {
            CreateMap<State, StateModel>().IgnoreSource(src => src.InitialState)
                                          .IgnoreSource(src => src.FinalState)
                                          .IgnoreSource(src => src.Entity)
                                          .IgnoreSource(src => src.EntityId)
                                          .IgnoreSource(src => src.NameEN)
                                          .IgnoreSource(src => src.DescriptionEN)
                                          .MapMember(dest => dest.Description, src => src.DescriptionCZ)
                                          .MapMember(dest => dest.Name, src => src.NameCZ)
                                          .ReverseMap();
        }
    }
}
