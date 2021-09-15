using Microsoft.AspNetCore.Mvc.Rendering;
//using System;
//using System.Collections.Generic;
//using System.Linq;
using Tilbake.Application.Extensions;
using Tilbake.Application.Resources;
using Tilbake.Domain.Enums;

namespace Tilbake.Application.Helpers
{
    public class SelectLists
    {
        public static MultiSelectList Carriers(IEnumerable<CarrierResource> carriers, Guid[] carrierIds)
        {
            List<SelectListItem> items = new();

            foreach (var item in carriers)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (carrierIds == null) ?
                                new MultiSelectList(items, "Value", "Text") :
                                new MultiSelectList(items, "Value", "Text", carrierIds);
        }

        public static SelectList Cities(IEnumerable<CityResource> cities, Guid? cityId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select City", Value = "" });

            foreach (var item in cities)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (cityId == Guid.Empty || String.IsNullOrEmpty(cityId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", cityId);
        }

        public static SelectList ClientTypes(IEnumerable<ClientTypeResource> clientTypes, Guid? clientTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Client Type", Value = "" });

            foreach (var item in clientTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (clientTypeId == Guid.Empty || String.IsNullOrEmpty(clientTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", clientTypeId);
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

        public static SelectList FileFormats(Guid? fileFormatId)
        {
            var formatTypes = Enum.GetValues(typeof(FileType))
                                    .Cast<FileType>().Select(c => new
                                    {
                                        Id = c.ToString(),
                                        Name = c.GetDisplayName()
                                    }).ToList();

            List<SelectListItem> items = new();

            foreach (var item in formatTypes)
            {
                items.Add(new SelectListItem() { Text = item.Id, Value = item.Id.ToString() });
            }

            return (fileFormatId == Guid.Empty || String.IsNullOrEmpty(fileFormatId.ToString())) ?
                                        new SelectList(items, "Value", "Text") :
                                        new SelectList(items, "Value", "Text", fileFormatId);
        }

        public static SelectList IdDocuments(Guid? IdDocumentId)
        {
            var IdDocuments = Enum.GetValues(typeof(IdDocument))
                                    .Cast<IdDocument>().Select(c => new
                                    {
                                        Id = c.ToString(),
                                        Name = c.GetDisplayName()
                                    }).ToList();

            List<SelectListItem> items = new();

            foreach (var item in IdDocuments)
            {
                items.Add(new SelectListItem() { Text = item.Id, Value = item.Id.ToString() });
            }

            return (IdDocumentId == Guid.Empty || String.IsNullOrEmpty(IdDocumentId.ToString())) ?
                                        new SelectList(items, "Value", "Text") :
                                        new SelectList(items, "Value", "Text", IdDocumentId);
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

        public static SelectList PaymentTypes(IEnumerable<PaymentTypeResource> paymentTypes, Guid? paymentTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Payment Type", Value = "" });

            foreach (var item in paymentTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (paymentTypeId == Guid.Empty || String.IsNullOrEmpty(paymentTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", paymentTypeId);
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
