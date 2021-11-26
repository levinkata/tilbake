using System.Globalization;
using System.Threading;

namespace Tilbake.MVC.Extensions
{
    public class SentenceCase
    {
        public static string ToProperCase(string text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);
        }
    }
}