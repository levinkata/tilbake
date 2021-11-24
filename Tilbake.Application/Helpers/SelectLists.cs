using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Tilbake.Application.Extensions;
using Tilbake.Application.Resources;
using Tilbake.Core.Enums;

namespace Tilbake.Application.Helpers
{
    public class SelectLists
    {
        public static SelectList BodyTypes(IEnumerable<BodyTypeResource> bodyTypes, Guid? bodyTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Body Type", Value = "" });

            foreach (var item in bodyTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (bodyTypeId == Guid.Empty || String.IsNullOrEmpty(bodyTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", bodyTypeId);
        }

        public static SelectList BuildingConditions(IEnumerable<BuildingConditionResource> buildingConditions, Guid? buildingConditionId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Building Condition", Value = "" });

            foreach (var item in buildingConditions)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (buildingConditionId == Guid.Empty || String.IsNullOrEmpty(buildingConditionId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", buildingConditionId);
        }


        public static SelectList DocumentTypes(IEnumerable<DocumentTypeResource> documentTypes, Guid? documentTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Document Type", Value = "" });

            foreach (var item in documentTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (documentTypeId == Guid.Empty || String.IsNullOrEmpty(documentTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", documentTypeId);
        }

        public static SelectList DriverTypes(IEnumerable<DriverTypeResource> driverTypes, Guid? driverTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Driver Type", Value = "" });

            foreach (var item in driverTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (driverTypeId == Guid.Empty || String.IsNullOrEmpty(driverTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", driverTypeId);
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

        public static SelectList HouseConditions(IEnumerable<HouseConditionResource> houseConditions, Guid? houseConditionId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select House Condition", Value = "" });

            foreach (var item in houseConditions)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (houseConditionId == Guid.Empty || String.IsNullOrEmpty(houseConditionId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", houseConditionId);
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

        public static SelectList MotorMakes(IEnumerable<MotorMakeResource> motorMakes, Guid? motorMakeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Motor Make", Value = "" });

            foreach (var item in motorMakes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (motorMakeId == Guid.Empty || String.IsNullOrEmpty(motorMakeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", motorMakeId);
        }

        public static SelectList MotorModels(IEnumerable<MotorModelResource> motorModels, Guid? motorModelId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Motor Model", Value = "" });

            foreach (var item in motorModels)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (motorModelId == Guid.Empty || String.IsNullOrEmpty(motorModelId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", motorModelId);
        }

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

        public static SelectList ResidenceTypes(IEnumerable<ResidenceTypeResource> residenceTypes, Guid? residenceTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Residence Type", Value = "" });

            foreach (var item in residenceTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (residenceTypeId == Guid.Empty || String.IsNullOrEmpty(residenceTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", residenceTypeId);
        }

        public static SelectList ResidenceUses(IEnumerable<ResidenceUseResource> residenceUses, Guid? residenceUseId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Residence Use", Value = "" });

            foreach (var item in residenceUses)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (residenceUseId == Guid.Empty || String.IsNullOrEmpty(residenceUseId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", residenceUseId);
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

        public static SelectList WallTypes(IEnumerable<WallTypeResource> wallTypes, Guid? wallTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Wall Type", Value = "" });

            foreach (var item in wallTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (wallTypeId == Guid.Empty || String.IsNullOrEmpty(wallTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", wallTypeId);
        }
    }
}
