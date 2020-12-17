namespace _04._Collector
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string CollectGettersAndSetters(string investigatedClass)
        {
            var @namespace = this.GetType().Namespace;
            Type classType = Type.GetType($"{@namespace}.{investigatedClass}");

            if (classType == null)
            {
                throw new ArgumentException("Invalid class name!");
            }

            PropertyInfo[] properties = classType
                .GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo property in properties.Where(m => m.GetMethod.IsPublic || m.GetMethod.IsPrivate)) // Where(m => m.Name.StartsWith("get")))
            {
                var getMethod = property.GetMethod;
                sb.AppendLine($"{getMethod.Name} will return {getMethod.ReturnType}");
            }

            foreach (PropertyInfo property in properties.Where(m => m.SetMethod.IsPublic || m.SetMethod.IsPrivate))
            {
                sb.AppendLine($"{property.SetMethod.Name} will set field of {property.PropertyType.FullName}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
