namespace _02._HighQualityMistakes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string AnalyzeAcessModifiers(string investigatedClass)
        {
            var @namespace = this.GetType().Namespace;
            Type classType = Type.GetType($"{@namespace}.{investigatedClass}");

            if (classType == null)
            {
                throw new ArgumentException("Invalid class name!");
            }

            FieldInfo[] nonPrivateFields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            PropertyInfo[] properties = classType
                .GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in nonPrivateFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (PropertyInfo property in properties.Where(m => m.GetMethod.IsPrivate))
            {
                sb.AppendLine($"{property.GetMethod.Name} have to be public!");
            }

            foreach (PropertyInfo property in properties.Where(m => m.SetMethod.IsPublic))
            {
                sb.AppendLine($"{property.SetMethod.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
