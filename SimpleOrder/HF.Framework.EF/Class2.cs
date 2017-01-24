using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class Class2
{
	private static object object_0 = new object();

	private static Class2 class2_0 = null;

	[CompilerGenerated]
	private IUnityContainer iunityContainer_0;

	[CompilerGenerated]
	public IUnityContainer method_0()
	{
		return this.iunityContainer_0;
	}

	[CompilerGenerated]
	public void method_1(IUnityContainer iunityContainer_1)
	{
		this.iunityContainer_0 = iunityContainer_1;
	}

	public static Class2 smethod_0(Assembly assembly_0)
	{
		if (Class2.class2_0 == null)
		{
			lock (Class2.object_0)
			{
				if (Class2.class2_0 == null)
				{
					Class2.class2_0 = new Class2();
					Class2.class2_0.method_1(new UnityContainer());
					Class2.smethod_1(Class2.class2_0.method_0(), assembly_0);
				}
			}
		}
		return Class2.class2_0;
	}

	private static void smethod_1(IUnityContainer iunityContainer_1, Assembly assembly_0)
	{
		Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
		Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>();
		string value = ".DAL";
		string value2 = ".IDAL";
		Type[] types = assembly_0.GetTypes();
		for (int i = 0; i < types.Length; i++)
		{
			Type type = types[i];
			string @namespace = type.Namespace;
			if (!string.IsNullOrEmpty(@namespace))
			{
				if (type.IsInterface && @namespace.EndsWith(value2))
				{
					if (!dictionary.ContainsKey(type.FullName))
					{
						dictionary.Add(type.FullName, type);
					}
				}
				else if (@namespace.EndsWith(value) && !dictionary2.ContainsKey(type.FullName))
				{
					dictionary2.Add(type.FullName, type);
				}
			}
		}
		foreach (string current in dictionary.Keys)
		{
			Type type2 = dictionary[current];
			foreach (string current2 in dictionary2.Keys)
			{
				Type type3 = dictionary2[current2];
				if (type2.IsAssignableFrom(type3))
				{
					UnityContainerExtensions.RegisterType(iunityContainer_1, type2, type3, new InjectionMember[0]);
				}
			}
		}
	}
}
