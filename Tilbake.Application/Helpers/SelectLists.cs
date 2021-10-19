using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Tilbake.Application.Extensions;
using Tilbake.Application.Resources;
using Tilbake.Domain.Enums;

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

        public static MultiSelectList Carriers(IEnumerable<CarrierResource> carriers, Guid[] carrierIds)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "None", Value = "" });

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

        public static SelectList CoverTypes(IEnumerable<CoverTypeResource> coverTypes, Guid? coverTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Cover Type", Value = "" });

            foreach (var item in coverTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (coverTypeId == Guid.Empty || String.IsNullOrEmpty(coverTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", coverTypeId);
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
        
        public static SelectList IdDocumentTypes(IEnumerable<IdDocumentTypeResource> idDocumentTypes, Guid? IdDocumentTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select ID Document Type", Value = "" });

            foreach (var item in idDocumentTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (IdDocumentTypeId == Guid.Empty || String.IsNullOrEmpty(IdDocumentTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", IdDocumentTypeId);
        }

        public static SelectList Insurers(IEnumerable<InsurerResource> insurers, Guid? insurerId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Insurer", Value = "" });

            foreach (var item in insurers)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (insurerId == Guid.Empty || String.IsNullOrEmpty(insurerId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", insurerId);
        }

        public static SelectList InsurerBranches(IEnumerable<InsurerBranchResource> insurerBranches, Guid? insurerBranchId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Insurer Branch", Value = "" });

            foreach (var item in insurerBranches)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (insurerBranchId == Guid.Empty || String.IsNullOrEmpty(insurerBranchId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", insurerBranchId);
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

        public static SelectList MaritalStatuses(IEnumerable<MaritalStatusResource> maritalStatuses, Guid? maritalStatusId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Marital Status", Value = "" });

            foreach (var item in maritalStatuses)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (maritalStatusId == Guid.Empty || String.IsNullOrEmpty(maritalStatusId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", maritalStatusId);
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

        public static SelectList PaymentMethods(IEnumerable<PaymentMethodResource> paymentMethods, Guid? paymentMethodId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Payment Method", Value = "" });

            foreach (var item in paymentMethods)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (paymentMethodId == Guid.Empty || String.IsNullOrEmpty(paymentMethodId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", paymentMethodId);
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

        public static SelectList PolicyStatuses(IEnumerable<PolicyStatusResource> policyStatuses, Guid? policyStatusId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Policy Status", Value = "" });

            foreach (var item in policyStatuses)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (policyStatusId == Guid.Empty || String.IsNullOrEmpty(policyStatusId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", policyStatusId);
        }

        public static SelectList PolicyTypes(IEnumerable<PolicyTypeResource> policyTypes, Guid? policyTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Policy Type", Value = "" });

            foreach (var item in policyTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (policyTypeId == Guid.Empty || String.IsNullOrEmpty(policyTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", policyTypeId);
        }

        public static SelectList QuoteStatuses(IEnumerable<QuoteStatusResource> quoteStatuses, Guid? quoteStatusId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Quote Status", Value = "" });

            foreach (var item in quoteStatuses)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (quoteStatusId == Guid.Empty || String.IsNullOrEmpty(quoteStatusId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", quoteStatusId);
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

        public static SelectList SalesTypes(IEnumerable<SalesTypeResource> salesTypes, Guid? salesTypeId)
        {
            List<SelectListItem> items = new();
            items.Add(new SelectListItem() { Text = "Select Sales Type", Value = "" });

            foreach (var item in salesTypes)
            {
                items.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            return (salesTypeId == Guid.Empty || String.IsNullOrEmpty(salesTypeId.ToString())) ?
                                    new SelectList(items, "Value", "Text") :
                                    new SelectList(items, "Value", "Text", salesTypeId);
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
