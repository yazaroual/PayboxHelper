using System.Collections.Generic;

namespace PayboxHelper
{

    /// <summary>
    /// Thanks to Matías Fidemraizer (http://designpatternninja.github.io/) for this extension method
    /// Discussion link : https://stackoverflow.com/a/4944547
    /// </summary>
    internal static class DictionaryExtension
    {
        public static T ToObject<T>(this IDictionary<string, string> source)
        where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType
                         .GetProperty(item.Key)
                         .SetValue(someObject, item.Value, null);
            }

            return someObject;
        }
    }
}