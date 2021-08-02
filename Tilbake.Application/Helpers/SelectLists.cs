using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Helpers
{
    public class SelectLists
    {
        public static SelectList Carriers(IEnumerable<CarrierResource> carriers, Guid? carrierId)
        {
            List<SelectListItem> items = new();

            foreach (var item in carriers)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (carrierId == Guid.Empty || String.IsNullOrEmpty(carrierId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", carrierId);
        }

        public static SelectList Countries(IEnumerable<CountryResource> countries, Guid? countryId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Country", Value = "" });

            foreach (var item in countries)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (countryId == Guid.Empty || String.IsNullOrEmpty(countryId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", countryId);
        }

        public static SelectList Genders(IEnumerable<GenderResource> genders, Guid? genderId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Gender", Value = "" });

            foreach (var item in genders)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (genderId == Guid.Empty || String.IsNullOrEmpty(genderId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", genderId);
        }

        public static SelectList FileFormats(IEnumerable<FileFormatResource> fileFormats, Guid? fileFormatId)
        {
            List<SelectListItem> items = new();

            foreach (var item in fileFormats)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (fileFormatId == Guid.Empty || String.IsNullOrEmpty(fileFormatId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", fileFormatId);
        }

        public static SelectList InvoiceStatuses(IEnumerable<InvoiceStatusResource> invoiceStatuses, Guid? invoiceStatusId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Invoice Status", Value = "" });

            foreach (var item in invoiceStatuses)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (invoiceStatusId == Guid.Empty || String.IsNullOrEmpty(invoiceStatusId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", invoiceStatusId);
        }

        public static SelectList Occupations(IEnumerable<OccupationResource> occupations, Guid? occupationId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Occupation", Value = "" });

            foreach (var item in occupations)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (occupationId == Guid.Empty || String.IsNullOrEmpty(occupationId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", occupationId);
        }

        public static SelectList Taxes(IEnumerable<TaxResource> taxes, Guid? taxId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Tax", Value = "" });

            foreach (var item in taxes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (taxId == Guid.Empty || String.IsNullOrEmpty(taxId.ToString())) ?
                                new SelectList(items, "Value", "Text") :
                                new SelectList(items, "Value", "Text", taxId);
        }

        public static SelectList Titles(IEnumerable<TitleResource> titles, Guid? titleId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Title", Value = "" });

            foreach (var item in titles)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (titleId == Guid.Empty || String.IsNullOrEmpty(titleId.ToString())) ?
                                new SelectList(items, "Value", "Text") :
                                new SelectList(items, "Value", "Text", titleId);
        }        
    }
}
