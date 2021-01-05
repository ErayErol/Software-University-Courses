namespace _01._Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            var @namespace = this.GetType().Namespace;
            Type classType = Type.GetType($"{@namespace}.{investigatedClass}");

            if (classType == null)
            {
                throw new ArgumentException("Invalid class name!");
            }

            FieldInfo[] classFields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            Object classInstance = Activator
                .CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field?.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
