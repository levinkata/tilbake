using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Tilbake.Application.Resources;
using Tilbake.Core.Enums;

namespace Tilbake.Application.Helpers
{
    public class SelectLists
    {
        public static SelectList RegisteredDays(int day)
        {
            List<int> days = new();

            for (int i = 0; i < 32; i++)
            {
                days.Add(i);
            }

            var dayRanges = days.Select(c => new
                                {
                                    Id = c.ToString(),
                                    Name = c.ToString()
                                }).ToList();

            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Day", Value = "" });

            foreach (var item in dayRanges)
            {
                items.Add(new SelectListItem() { Text = item.Id, Value = item.Id.ToString() });
            }

            return (day == 0) ? new SelectList(items, "Value", "Text") :
                                new SelectList(items, "Value", "Text", day);
        }

        public static SelectList RegisteredRisks(string risk)
        {
            List<string> registeredRisks = new();
            registeredRisks.Add("AllRisks");
            registeredRisks.Add("Building");
            registeredRisks.Add("Content");
            registeredRisks.Add("House");
            registeredRisks.Add("Motor");

            var risks = registeredRisks.Select(c => new
                                        {
                                            Id = c.ToString(),
                                            Name = c.ToString()
                                        }).ToList();

            List<SelectListItem> items = new();

            foreach (var item in risks)
            {
                items.Add(new SelectListItem() { Text = item.Id, Value = item.Id.ToString() });
            }

            return (risk == "" || String.IsNullOrEmpty(risk)) ?
                                        new SelectList(items, "Value", "Text") :
                                        new SelectList(items, "Value", "Text", risk);
        }

        public static SelectList RegisteredYears(int year)
        {
            var range = 20;
            var currentYear = DateTime.Now.Year;

            List<int> years = new();

            for (int i = 0; i < range; i++)
            {
                years.Add(currentYear);
                currentYear--;
            }

            var dateRanges = years.Select(c => new
            {
                Id = c.ToString(),
                Name = c.ToString()
            }).ToList();

            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Year", Value = "" });

            foreach (var item in dateRanges)
            {
                items.Add(new SelectListItem() { Text = item.Id, Value = item.Id.ToString() });
            }

            return (year == 0) ? new SelectList(items, "Value", "Text") :
                                new SelectList(items, "Value", "Text", year);
        }


        public static SelectList RoofTypes(IEnumerable<RoofTypeResource> roofTypes, Guid? roofTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Roof Type", Value = "" });

            foreach (var item in roofTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (roofTypeId == Guid.Empty || String.IsNullOrEmpty(roofTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", roofTypeId);
        }


    }
}
