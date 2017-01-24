using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HF.PLM.Framework.EF
{
	public static class AutoMapperHelper
	{
		public static T MapTo<T>(this object obj)
		{
			T result;
			if (obj == null)
			{
				result = default(T);
			}
			else
			{
				Mapper.CreateMap(obj.GetType(), typeof(T));
				result = Mapper.Map<T>(obj);
			}
			return result;
		}

		public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
		{
			IEnumerator enumerator = source.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					Type type = current.GetType();
					Mapper.CreateMap(type, typeof(TDestination));
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return Mapper.Map<List<TDestination>>(source);
		}

		public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
		{
			Mapper.CreateMap<TSource, TDestination>();
			return Mapper.Map<List<TDestination>>(source);
		}

		public static IQueryable<TDestination> MapToList<TSource, TDestination>(this IQueryable<TSource> source)
		{
			Mapper.CreateMap<TSource, TDestination>();
			return Mapper.Map<IQueryable<TDestination>>(source);
		}

		public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination) where TSource : class where TDestination : class
		{
			TDestination result;
			if (source == null)
			{
				result = destination;
			}
			else
			{
				Mapper.CreateMap<TSource, TDestination>();
				result = Mapper.Map<TSource, TDestination>(source, destination);
			}
			return result;
		}

		public static IEnumerable<T> DataReaderMapTo<T>(this IDataReader reader)
		{
			Mapper.Reset();
			Mapper.CreateMap<IDataReader, IEnumerable<T>>();
			return Mapper.Map<IDataReader, IEnumerable<T>>(reader);
		}
	}
}
