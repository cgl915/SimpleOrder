using System;

internal sealed class Class1
{
	private const string string_0 = "参数 '{0}'的值不能为空字符串。";

	private const string string_1 = "参数'{0}'的名称不能为空引用或空字符串。";

	private const string string_2 = "数值必须大于0字节.";

	private const string string_3 = "无效的类型，期待的类型必须为'{0}'。";

	private const string string_4 = "{0}不是{1}的一个有效值";

	private Class1()
	{
	}

	public static void smethod_0(string string_5, string string_6)
	{
		Class1.smethod_1(string_5, string_6);
		Class1.smethod_1(string_6, "variableName");
		if (string_5.Length == 0)
		{
			string message = string.Format("参数 '{0}'的值不能为空字符串。", string_6);
			throw new ArgumentException(message);
		}
	}

	public static void smethod_1(object object_0, string string_5)
	{
		if (string_5 == null)
		{
			throw new ArgumentNullException("variableName");
		}
		if (null == object_0)
		{
			throw new ArgumentNullException(string_5);
		}
	}

	public static void smethod_2(string string_5, string string_6)
	{
		if (string_5 == null || string_5.Length == 0)
		{
			string message = string.Format("参数'{0}'的名称不能为空引用或空字符串。", string_6);
			throw new InvalidOperationException(message);
		}
	}

	public static void smethod_3(byte[] byte_0, string string_5)
	{
		Class1.smethod_1(byte_0, "bytes");
		Class1.smethod_1(string_5, "variableName");
		if (byte_0.Length == 0)
		{
			string message = string.Format("数值必须大于0字节.", string_5);
			throw new ArgumentException(message);
		}
	}

	public static void smethod_4(object object_0, Type type_0)
	{
		Class1.smethod_1(object_0, "variable");
		Class1.smethod_1(type_0, "type");
		if (!type_0.IsAssignableFrom(object_0.GetType()))
		{
			string message = string.Format("无效的类型，期待的类型必须为'{0}'。", type_0.FullName);
			throw new ArgumentException(message);
		}
	}

	public static void smethod_5(Type type_0, object object_0, string string_5)
	{
		Class1.smethod_1(object_0, "variable");
		Class1.smethod_1(type_0, "enumType");
		Class1.smethod_1(string_5, "variableName");
		if (!Enum.IsDefined(type_0, object_0))
		{
			string message = string.Format("{0}不是{1}的一个有效值", object_0.ToString(), type_0.FullName, string_5);
			throw new ArgumentException(message);
		}
	}
}
