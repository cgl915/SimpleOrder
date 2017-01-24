using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace HF.PLM.Framework.EF
{
	public class IFactory
	{
        private static object object_0 = new object();

        private static IUnityContainer iunityContainer_0 = new UnityContainer();

        //public static T Instance<T>() where T : class
        //{
        //    Func<Type, bool> func = null;
        //    if (!UnityContainerExtensions.IsRegistered<T>(IFactory.iunityContainer_0))
        //    {
        //        bool flag = false;
        //        try
        //        {
        //            object obj;
        //            Monitor.Enter(obj = IFactory.object_0, ref flag);
        //            Assembly assembly = typeof(T).Assembly;
        //            Class2 @class = Class2.smethod_0(assembly);
        //            if (@class.method_0() != null)
        //            {
        //                foreach (ContainerRegistration current in @class.method_0().Registrations)
        //                {
        //                    if (!UnityContainerExtensions.IsRegistered(IFactory.iunityContainer_0, current.RegisteredType))
        //                    {
        //                        UnityContainerExtensions.RegisterType(IFactory.iunityContainer_0, current.RegisteredType, current.MappedToType, new InjectionMember[0]);
        //                    }
        //                }
        //            }
        //            string bllSuffix = ".BLL";
        //            IEnumerable<Type> arg_DB_0 = assembly.GetTypes();
        //            if (func == null)
        //            {
        //                func = new Func<Type, bool>(IFactory.smethod_0<T>);
        //            }
        //            IEnumerable<Type> enumerable = from type in arg_DB_0.Where(func)
        //                                           where type.BaseType != null && type.BaseType.IsGenericType && !type.IsInterface && typeof(T).IsAssignableFrom(type) && type.Namespace.EndsWith(bllSuffix)
        //                                           select type;
        //            foreach (Type current2 in enumerable)
        //            {
        //                UnityContainerExtensions.RegisterType(IFactory.iunityContainer_0, typeof(T), current2, new InjectionMember[0]);
        //            }
        //        }
        //        finally
        //        {
        //            if (flag)
        //            {
        //                object obj=0;
        //                Monitor.Exit(obj);
        //            }
        //        }
        //    }
        //    return UnityContainerExtensions.Resolve<T>(IFactory.iunityContainer_0, new ResolverOverride[0]);



        //    Func<Type, bool> predicate = null;
        //    if (!iunityContainer_0.IsRegistered<T>())
        //    {
        //        lock (object_0)
        //        {
        //            Assembly assembly = typeof(T).Assembly;
        //            Class2 class3 = Class2.smethod_0(assembly);
        //            if (class3.method_0() != null)
        //            {
        //                foreach (ContainerRegistration registration in class3.method_0().Registrations)
        //                {
        //                    if (!UnityContainerExtensions.IsRegistered(iunityContainer_0, registration.RegisteredType))
        //                    {
        //                        UnityContainerExtensions.RegisterType(iunityContainer_0, registration.RegisteredType, registration.MappedToType, new InjectionMember[0]);
        //                    }
        //                }
        //            }
        //            string bllSuffix = ".BLL";
        //            if (predicate == null)
        //            {
        //                predicate = new Func<Type, bool>(IFactory.smethod_0<T>);
        //            }
        //            foreach (Type type in from type in assembly.GetTypes().Where<Type>(predicate)
        //                                  where (((type.BaseType != null) && type.BaseType.IsGenericType) && (!type.IsInterface && typeof(T).IsAssignableFrom(type))) && type.Namespace.EndsWith(bllSuffix)
        //                                  select type)
        //            {
        //                UnityContainerExtensions.RegisterType(iunityContainer_0, typeof(T), type, new InjectionMember[0]);
        //            }
        //        }
        //    }
        //    return iunityContainer_0.Resolve<T>(new ResolverOverride[0]);
        //}

        public static T Instance<T>() where T : class
        {
            Func<Type, bool> predicate = null;
            if (!iunityContainer_0.IsRegistered<T>())
            {
                lock (object_0)
                {
                    Assembly assembly = typeof(T).Assembly;
                    Class2 class3 = Class2.smethod_0(assembly);
                    if (class3.method_0() != null)
                    {
                        foreach (ContainerRegistration registration in class3.method_0().Registrations)
                        {
                            if (!UnityContainerExtensions.IsRegistered(iunityContainer_0, registration.RegisteredType))
                            {
                                UnityContainerExtensions.RegisterType(iunityContainer_0, registration.RegisteredType, registration.MappedToType, new InjectionMember[0]);
                            }
                        }
                    }
                    string bllSuffix = ".BLL";
                    if (predicate == null)
                    {
                        predicate = new Func<Type, bool>(IFactory.smethod_0<T>);
                    }
                    foreach (Type type in from type in assembly.GetTypes().Where<Type>(predicate)
                                          where (((type.BaseType != null) && type.BaseType.IsGenericType) && (!type.IsInterface && typeof(T).IsAssignableFrom(type))) && type.Namespace.EndsWith(bllSuffix)
                                          select type)
                    {
                        UnityContainerExtensions.RegisterType(iunityContainer_0, typeof(T), type, new InjectionMember[0]);
                    }
                }
            }
            return iunityContainer_0.Resolve<T>(new ResolverOverride[0]);
        }

        [CompilerGenerated]
        private static bool smethod_0<T>(Type type_0) where T : class
        {
            return !string.IsNullOrEmpty(type_0.Namespace);
        }
	}
}
