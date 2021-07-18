using System.Globalization;
using System.Threading;

namespace Tilbake.Application.Extensions
{
    public class SentenceCase
    {
        public string ToProperCase(string text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);
        }
    }
}