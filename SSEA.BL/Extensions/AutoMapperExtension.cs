using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SSEA.BL.Extensions
{
    public static class AutoMapperExtension
    {
        public static IMappingExpression<TSource, TDestination> MapMember<TSource, TDestination, TSourceMember>(this IMappingExpression<TSource, TDestination> map,
                                                                                                                Expression<Func<TDestination, object>> destiantionSelector,
                                                                                                                Expression<Func<TSource, TSourceMember>> sourceSelector)
        {
            map.ForMember(destiantionSelector, config => config.MapFrom(sourceSelector));
            return map;
        }

        public static IMappingExpression<TSource, TDestination> UseValue<TSource, TDestination, TValue>(this IMappingExpression<TSource, TDestination> map,
                                                                                                        Expression<Func<TDestination, object>> destiantionSelector,
                                                                                                        TValue value)
        {
            map.ForMember(destiantionSelector, config => config.MapFrom(src => value));
            return map;
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map,
                                                                                                Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, opt => opt.Ignore());
            return map;
        }

        public static IMappingExpression<TSource, TDestination> IgnoreSource<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map,
                                                                                                    Expression<Func<TSource, object>> selector)
        {
            map.ForSourceMember(selector, opt => opt.DoNotValidate());
            return map;
        }
    }
}
