using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Tilbake.Core.Enums;
using Tilbake.MVC.Extensions;

namespace Tilbake.MVC.Helpers
{
    public static class MVCHelperExtensions
    {
        private static readonly Regex Reg = new Regex("([a-z,0-9](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", RegexOptions.Compiled);

        /// <summary>
        /// This splits up a string based on capital letters
        /// e.g. "MyAction" would become "My Action" and "My10Action" would become "My10 Action"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SplitPascalCase(this string str)
        {
            return Reg.Replace(str, "$1 ");
        }

        public static SelectList ToSelectList<T>(IEnumerable<T> enumerable, Guid id)
        {
            List<SelectListItem> items = new();
            var initItem = 0;
            
            foreach (var item in enumerable)
            {
                Type t = item.GetType();
                string fieldName;
                object propertyValue;
                string? value = null;
                string? text = null;
                string? name = SplitPascalCase(t.Name);

                if(initItem == 0)
                {
                    items.Add(new SelectListItem() { Text = "Select " + name, Value = "" });
                    initItem++;
                }

                foreach (PropertyInfo property in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    // Get the name and value of the property
                    fieldName = property.Name;

                    if(fieldName == "Name")
                    {
                        // Get the value of the property
                        propertyValue = property.GetValue(item, null);
                        text = propertyValue.ToString();
                    }

                    if (fieldName == "Id")
                    {
                        // Get the value of the property
                        propertyValue = property.GetValue(item, null);
                        value = propertyValue.ToString();
                    }

                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrEmpty(text))
                    {
                        items.Add(new SelectListItem() { Text = text, Value = value });
                        break;
                    }
                }
            }

            return (id == Guid.Empty || String.IsNullOrEmpty(id.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", id);
        }

        public static MultiSelectList ToMultiSelectList<T>(IEnumerable<T> enumerable, List<Guid> ids)
        {
            List<SelectListItem> items = new();
            var initItem = 0;

            foreach (var item in enumerable)
            {
                Type t = item.GetType();
                string fieldName;
                object propertyValue;
                string? value = null;
                string? text = null;
                string? name = t.Name;

                if (initItem == 0)
                {
                    items.Add(new SelectListItem() { Text = "Select " + t.Name, Value = "" });
                    initItem++;
                }

                foreach (PropertyInfo property in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    // Get the name and value of the property
                    fieldName = property.Name;

                    if (fieldName == "Name")
                    {
                        // Get the value of the property
                        propertyValue = property.GetValue(item, null);
                        text = propertyValue.ToString();
                    }

                    if (fieldName == "Id")
                    {
                        // Get the value of the property
                        propertyValue = property.GetValue(item, null);
                        value = propertyValue.ToString();
                    }

                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrEmpty(text))
                    {
                        items.Add(new SelectListItem() { Text = text, Value = value });
                        break;
                    }
                }
            }

            return (ids == null) ?
                            new MultiSelectList(items, "Value", "Text") :
                            new MultiSelectList(items, "Value", "Text", ids);
        }

        public static SelectList EnumToSelectList<T>(FileType? id = null) where T : Enum
        {
            var enumerable = Enum.GetValues(typeof(T))
                                    .Cast<T>().Select(c => new
                                    {
                                        Id = c.ToString(),
                                        Name = c.GetDisplayName()
                                    }).ToList();

            List<SelectListItem> items = new();

            foreach (var item in enumerable)
            {
                items.Add(new SelectListItem() { Text = item.Id, Value = item.Id.ToString() });
            }

            return (String.IsNullOrEmpty(id.ToString())) ?
                            new SelectList(items, "Value", "Text") :
                            new SelectList(items, "Value", "Text", id);
        }
    }

}
