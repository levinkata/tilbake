using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Helpers
{
    public class SelectLists
    {
        public static SelectList Titles(IEnumerable<Title> titles, Guid? titleId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Title", Value = "" });

            foreach (Title item in titles)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (titleId == Guid.Empty || String.IsNullOrEmpty(titleId.ToString())) ? new SelectList(items, "Value", "Text") : new SelectList(items, "Value", "Text", titleId);
        }
    }
}
