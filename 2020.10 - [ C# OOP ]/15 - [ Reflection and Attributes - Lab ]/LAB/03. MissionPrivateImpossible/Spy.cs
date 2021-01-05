namespace _03._MissionPrivateImpossible
{
    using System;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string RevealPrivateMethods(string investigatedClass)
        {
            var @namespace = this.GetType().Namespace;
            Type classType = Type.GetType($"{@namespace}.{investigatedClass}");

            if (classType == null)
            {
                throw new ArgumentException("Invalid class name!");
            }

            string baseClassName = classType.BaseType.Name;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
            sb.AppendLine($"Base Class: {baseClassName}");

            MethodInfo[] methods = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
