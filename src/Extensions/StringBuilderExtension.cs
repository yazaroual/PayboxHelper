using System.Text;

namespace PayboxHelper
{
    /// <summary>
    /// Extension methods used to build strings containing the Paybox Params
    /// </summary>
    internal static class StringBuilderExtension
    {

        /// <summary>
        /// Appends a Paybox param to Query String. Used  for signing.
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="name">Name of the value to append</param>
        /// <param name="value">Value to append if not null</param>
        public static StringBuilder AppendAsQueryParamIfNotNull(this StringBuilder sb, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                sb.Append($"{name}={value}&");
            };

            return sb;
        }

        /// <summary>
        /// Append a paybox param to an Url Encoded Form.
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="name">Name of the value to append</param>
        /// <param name="value">Value to append if not null</param>
        public static StringBuilder AppendAsFormValueIfNotNull(this StringBuilder sb, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                sb.Append($"<input type=\"hidden\" name=\"{name}\" value=\"{value}\">");
            };

            return sb;
        }
    }
}