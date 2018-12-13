using System;
using System.Reflection;

namespace ThuongMaiDienTuAPI.Helpers
{
    public class ReflectionProperty
    {
        public static PropertyInfo Get(Object obj,string propertyName)
        {
            return obj.GetType().GetProperty(propertyName,
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.IgnoreCase);
        }
    }
}
