using System.Globalization;
using System.Text;

namespace CsfdClientNet.Cache
{

    internal static class CacheUtils
    {
        internal static string Normalize(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;
            var normalizedString = name.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark) stringBuilder.Append(c);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToUpper();
        }
    }
}