using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.Abstractions;

namespace VehicleHub.Mapper
{
    public class Mapper : IMyMapper
    {
        public TDestination Map<TDestination, TSource>(TSource source)
        {
            return source.Adapt<TDestination>();
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources)
        {
            return sources.Adapt<IList<TDestination>>();
        }

        public TDestination Map<TDestination>(object source)
        {
            return source.Adapt<TDestination>();
        }

        public IList<TDestination> Map<TDestination>(IList<object> source)
        {
            return source.Adapt<IList<TDestination>>();
        }
    }
}
