using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Helper
{
    public static class HtmlHelpers
    {
        public static IHtmlContent StripHtmlAndLimit(this IHtmlHelper htmlHelper, string input, int maxLength = 50)
        {
            var result = StripHtmlAndLimit(input, maxLength);

            return new HtmlString(result);
        }

        public static string StripHtmlAndLimit(string input, int maxLength = 50)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            string textOnly = Regex.Replace(input, "<.*?>", string.Empty);

            if (textOnly.Length <= maxLength)
                return textOnly;

            return textOnly.Substring(0, maxLength) + "...";
        }
    }
}
