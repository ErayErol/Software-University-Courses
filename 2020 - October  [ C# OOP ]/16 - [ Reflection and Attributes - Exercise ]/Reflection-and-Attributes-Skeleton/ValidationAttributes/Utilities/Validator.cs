namespace ValidationAttributes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Attributes;

    public static class Validator
    {
        /// <summary>
        /// Checks all object's properties for custem attributes and if all are valid, then the whole object is Valid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            // If all properties are valid with their custom attributes -> Object is Valid
            // If one property is not valid for one of it's custom attributes -> Object is not Valid
            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> attributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (attribute.IsValid(property.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
