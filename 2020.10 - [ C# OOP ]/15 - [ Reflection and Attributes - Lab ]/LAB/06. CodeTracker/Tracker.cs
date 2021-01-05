namespace _06._CodeTracker
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public static void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine("{0} iw written by {1}", method.Name, attr.Name);
                    }
                }
            }
        }
    }
}
