using System.Collections;
using System.Reflection;

namespace Eonics.AI.Core;

public static class SecondComponent
{
    public static object? GetNestedPropertyValue(object? obj, string propertyPath)
    {
        if (string.IsNullOrEmpty(propertyPath))
            return obj;

        string[] properties = propertyPath.Split('.');
        object? value = obj;
        foreach (string property in properties)
        {
            if (value == null)
                return null;

            if (property.Contains('['))
            {
                int startIndex = property.IndexOf("[", StringComparison.Ordinal);
                int endIndex = property.IndexOf("]", StringComparison.Ordinal);
                if (startIndex < 0 || endIndex < 0 || endIndex < startIndex)
                    return null;

                string propertyName = property.Substring(0, startIndex);
                int index = int.Parse(property.Substring(startIndex + 1, endIndex - startIndex - 1));

                PropertyInfo? propertyInfo = value.GetType().GetProperty(propertyName);
                if (propertyInfo == null)
                    return null;

                value = propertyInfo.GetValue(value);
                if (value == null)
                    return null;

                if (value is IList list)
                    value = list[index];
                else
                    return null;
            }
            else
            {
                PropertyInfo? propertyInfo = value.GetType().GetProperty(property);
                if (propertyInfo == null)
                    return null;

                value = propertyInfo.GetValue(value);
            }
        }

        return value;
    }
}
