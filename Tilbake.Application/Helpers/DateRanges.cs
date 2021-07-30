using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Tilbake.Application.Helpers
{
    public class DateRanges
    {
        public static SelectList Years(int range = 10)
        {
            var currentYear = DateTime.Now.Year;

            List<SelectListItem> years = new();
            years.Add(new SelectListItem() { Text = "Select Year", Value = "" });

            for (int i = 0; i < range; i++)
            {
                years.Add(new SelectListItem() { Text = currentYear.ToString(), Value = currentYear.ToString() });
                currentYear--;
            }

            return new SelectList(years, "Value", "Text");
        }
    }
}
