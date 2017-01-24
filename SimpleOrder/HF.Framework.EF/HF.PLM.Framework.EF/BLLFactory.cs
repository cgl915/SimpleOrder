using System;
using System.Collections;
using System.Reflection;

namespace HF.PLM.Framework.EF
{
	public class BLLFactory<T> where T : class
	{
		private static object object_0 = new object();

		private static Hashtable hashtable_0 = new Hashtable();

		public static T Instance
		{
			get
			{
				string fullName = typeof(T).FullName;
				T t = (T)((object)BLLFactory<T>.hashtable_0[fullName]);
				if (t == null)
				{
					lock (BLLFactory<T>.object_0)
					{
						if (t == null)
						{
							Assembly assembly = typeof(T).Assembly;
							t = (T)((object)assembly.CreateInstance(fullName));
							BLLFactory<T>.hashtable_0.Add(typeof(T).FullName, t);
						}
					}
				}
				return t;
			}
		}
	}
}
