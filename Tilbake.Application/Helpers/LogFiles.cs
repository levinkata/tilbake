using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Helpers
{
    public static class LogFiles
    {
        public static void WriteLogFile(IWebHostEnvironment environment, string s, string folder, string filename)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            };

            string dt = DateTime.Now.ToString("yyyyMMdd", CultureInfo.CurrentCulture);
            string filePath = Path.Combine(environment.WebRootPath, $"logs/{folder}/{dt}-{filename}.txt");

            if (File.Exists(filePath))
            {
                using (var tw = new StreamWriter(filePath, true))
                {
                    tw.WriteLine(s);
                    tw.Close();
                };
            }
            else
            {
                using FileStream fs = new(filePath, FileMode.CreateNew);
                fs.Close();
                fs.Dispose();
                using (var tw = new StreamWriter(filePath, true))
                {
                    tw.WriteLine(s);
                    tw.Close();
                };
            }
        }
    }
}
