namespace MiniORM
{
	using System;
	using System.Linq;
	using System.Reflection;

	internal static class ReflectionHelper
	{
		public static void ReplaceBackingField(object sourceObj, string propertyName, object targetObj)
		{
			var backingField = sourceObj.GetType()
				.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField)
				.First(fi => fi.Name == $"<{propertyName}>k__BackingField");

			backingField.SetValue(sourceObj, targetObj);
		}

		public static bool HasAttribute<T>(this MemberInfo mi)
			where T : Attribute
		{
			var hasAttribute = mi.GetCustomAttribute<T>() != null;
			return hasAttribute;
		}
	}
}