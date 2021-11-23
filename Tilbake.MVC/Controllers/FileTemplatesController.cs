using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;
using Tilbake.Core.Enums;

namespace Tilbake.MVC.Controllers
{
    public class FileTemplatesController : Controller
    {
        private readonly IFileTemplateService _fileTemplateService;
        private readonly IFileTemplateRecordService _fileTemplateRecordService;
        private readonly IPortfolioService _portfolioService;

        public FileTemplatesController(IFileTemplateService fileTemplateService,
                                        IFileTemplateRecordService fileTemplateRecordService,
                                        IPortfolioService portfolioService)
        {
            _fileTemplateService = fileTemplateService;
            _fileTemplateRecordService = fileTemplateRecordService;
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var ViewModels = await _fileTemplateService.GetByPortfolioIdAsync(portfolioId);
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            ViewBag.PortfolioId = portfolioId;
            ViewBag.Portfolio = portfolio.Name;
            return View(ViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            FileTemplateViewModel ViewModel = new()
            {
                PortfolioId = portfolioId,
                Portfolio = portfolio.Name,
                FileTypeList = SelectLists.FileFormats(Guid.Empty)
            };

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FileTemplateViewModel ViewModel)
        {
            if(ModelState.IsValid)
            {
                _fileTemplateService.AddAsync(ViewModel);

                return RedirectToAction(nameof(Index), new { portfolioId = ViewModel.PortfolioId });
            }
            ViewModel.FileTypeList = SelectLists.FileFormats(Guid.Empty);
            return View(ViewModel);
        }

        public async Task<IActionResult> SelectTable(Guid portfolioId, Guid fileTemplateId, FileType fileType)
        {
            var fileTemplateRecord = await _fileTemplateRecordService.GetAllAsync();
            var tables = fileTemplateRecord.Select(t => new { t.TableName, t.TableLabel })
                                    .Distinct().ToList();

            SelectedTableViewModel ViewModel = new()
            {
                PortfolioId = portfolioId,
                FileTemplateId = fileTemplateId,
                FileType = fileType,
                TableList = new SelectList(tables.Select(t => new
                                {
                                    Id = t.TableName,
                                    Name = t.TableLabel
                                }).ToList(), "Id", "Name", tables.FirstOrDefault())
            };
            return  View(ViewModel);
        }

        [HttpPost, ActionName("SelectTable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectTableConfirmed(SelectedTableViewModel ViewModel)
        {
            if (ViewModel == null)
            {
                throw new ArgumentNullException(nameof(ViewModel));
            };

            if (ModelState.IsValid)
            {
                return RedirectToAction("TableFileTemplate", new
                {
                    portfolioId = ViewModel.PortfolioId,
                    fileTemplateId = ViewModel.FileTemplateId,
                    tableName = ViewModel.TableName,
                    fileType = ViewModel.FileType
                });
            }

            var filterTables = await _fileTemplateRecordService.GetAllAsync();
            var tables = filterTables.Select(t => new { t.TableName, t.TableLabel })
                                    .Distinct().ToList();

            ViewModel.TableList = new SelectList(tables.Select(t => new
                                        {
                                            Id = t.TableName,
                                            Name = t.TableLabel
                                        }).ToList(), "Id", "Name", tables.FirstOrDefault());

            return View(ViewModel);
        }

        public async Task<IActionResult> TableFileTemplate(Guid fileTemplateId,
                                            string tableName, FileType fileType)
        {
            var fileTemplate = await _fileTemplateService.GetByIdAsync(fileTemplateId);
            var portfolioId = fileTemplate.PortfolioId;
            var portfolioName = fileTemplate.PortfolioName;
            var fileTemplateRecords = await _fileTemplateRecordService.GetTableFileTemplate(fileTemplateId, tableName);

            if (tableName == "Client")
            {
                ClientGiroViewModel ViewModel = new()
                {
                    PortfolioId = portfolioId,
                    PortfolioName = portfolioName,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplateName
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldName = item.FieldName;

                    switch (fieldName)
                    {
                        case "Title":
                            ViewModel.TitleId = item.Id;
                            ViewModel.TitleFieldLabel = item.FieldLabel;
                            ViewModel.TitlePosition = item.Position;
                            ViewModel.TitleColumnLength = item.ColumnLength;
                            break;

                        case "ClientType":
                            ViewModel.ClientTypeId = item.Id;
                            ViewModel.ClientTypeFieldLabel = item.FieldLabel;
                            ViewModel.ClientTypePosition = item.Position;
                            ViewModel.ClientTypeColumnLength = item.ColumnLength;
                            break;

                        case "FirstName":
                            ViewModel.FirstNameId = item.Id;
                            ViewModel.FirstNameFieldLabel = item.FieldLabel;
                            ViewModel.FirstNamePosition = item.Position;
                            ViewModel.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            ViewModel.LastNameId = item.Id;
                            ViewModel.LastNameFieldLabel = item.FieldLabel;
                            ViewModel.LastNamePosition = item.Position;
                            ViewModel.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "BirthDate":
                            ViewModel.BirthDateId = item.Id;
                            ViewModel.BirthDateFieldLabel = item.FieldLabel;
                            ViewModel.BirthDatePosition = item.Position;
                            ViewModel.BirthDateColumnLength = item.ColumnLength;
                            break;

                        case "Gender":
                            ViewModel.GenderId = item.Id;
                            ViewModel.GenderFieldLabel = item.FieldLabel;
                            ViewModel.GenderPosition = item.Position;
                            ViewModel.GenderColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            ViewModel.IdNumberId = item.Id;
                            ViewModel.IdNumberFieldLabel = item.FieldLabel;
                            ViewModel.IdNumberPosition = item.Position;
                            ViewModel.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "MaritalStatus":
                            ViewModel.MaritalStatusId = item.Id;
                            ViewModel.MaritalStatusFieldLabel = item.FieldLabel;
                            ViewModel.MaritalStatusPosition = item.Position;
                            ViewModel.MaritalStatusColumnLength = item.ColumnLength;
                            break;

                        case "Phone":
                            ViewModel.PhoneId = item.Id;
                            ViewModel.PhoneFieldLabel = item.FieldLabel;
                            ViewModel.PhonePosition = item.Position;
                            ViewModel.PhoneColumnLength = item.ColumnLength;
                            break;

                        case "Country":
                            ViewModel.CountryId = item.Id;
                            ViewModel.CountryFieldLabel = item.FieldLabel;
                            ViewModel.CountryPosition = item.Position;
                            ViewModel.CountryColumnLength = item.ColumnLength;
                            break;

                        case "Occupation":
                            ViewModel.OccupationId = item.Id;
                            ViewModel.OccupationFieldLabel = item.FieldLabel;
                            ViewModel.OccupationPosition = item.Position;
                            ViewModel.OccupationColumnLength = item.ColumnLength;
                            break;

                        default:
                            break;
                    }
                }
                return View("ClientFileTemplate", ViewModel);
            }
            else if (tableName == "Premium")
            {
                PremiumGiroViewModel ViewModel = new()
                {
                    PortfolioId = portfolioId,
                    PortfolioName = portfolioName,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplateName
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldName = item.FieldName;

                    switch (fieldName)
                    {
                        case "FirstName":
                            ViewModel.FirstNameId = item.Id;
                            ViewModel.FirstNameFieldLabel = item.FieldLabel;
                            ViewModel.FirstNamePosition = item.Position;
                            ViewModel.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            ViewModel.LastNameId = item.Id;
                            ViewModel.LastNameFieldLabel = item.FieldLabel;
                            ViewModel.LastNamePosition = item.Position;
                            ViewModel.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            ViewModel.IdNumberId = item.Id;
                            ViewModel.IdNumberFieldLabel = item.FieldLabel;
                            ViewModel.IdNumberPosition = item.Position;
                            ViewModel.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "PolicyNumber":
                            ViewModel.PolicyNumberId = item.Id;
                            ViewModel.PolicyNumberFieldLabel = item.FieldLabel;
                            ViewModel.PolicyNumberPosition = item.Position;
                            ViewModel.PolicyNumberColumnLength = item.ColumnLength;
                            break;

                        case "Amount":
                            ViewModel.PremiumId = item.Id;
                            ViewModel.PremiumFieldLabel = item.FieldLabel;
                            ViewModel.PremiumPosition = item.Position;
                            ViewModel.PremiumColumnLength = item.ColumnLength;
                            break;
                        default:
                            break;
                    }
                }
                return View("PremiumFileTemplate", ViewModel);
            }
            else if (tableName == "Policy")
            {
                PolicyGiroViewModel ViewModel = new()
                {
                    PortfolioId = portfolioId,
                    PortfolioName = portfolioName,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplateName
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldname = item.FieldName;

                    switch (fieldname)
                    {
                        case "FirstName":
                            ViewModel.FirstNameId = item.Id;
                            ViewModel.FirstNameFieldLabel = item.FieldLabel;
                            ViewModel.FirstNamePosition = item.Position;
                            ViewModel.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            ViewModel.LastNameId = item.Id;
                            ViewModel.LastNameFieldLabel = item.FieldLabel;
                            ViewModel.LastNamePosition = item.Position;
                            ViewModel.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            ViewModel.IdNumberId = item.Id;
                            ViewModel.IdNumberFieldLabel = item.FieldLabel;
                            ViewModel.IdNumberPosition = item.Position;
                            ViewModel.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "PolicyNumber":
                            ViewModel.PolicyNumberId = item.Id;
                            ViewModel.PolicyNumberFieldLabel = item.FieldLabel;
                            ViewModel.PolicyNumberPosition = item.Position;
                            ViewModel.PolicyNumberColumnLength = item.ColumnLength;
                            break;

                        default:
                            break;
                    }
                }
                return View("PolicyFileTemplate", ViewModel);
            }
            else if (tableName == "Claim")
            {
                ClaimGiroViewModel ViewModel = new()
                {
                    PortfolioId = portfolioId,
                    PortfolioName = portfolioName,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplateName
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldname = item.FieldName;

                    switch (fieldname)
                    {
                        case "ClaimNumber":
                            ViewModel.ClaimNumberId = item.Id;
                            ViewModel.ClaimNumberFieldLabel = item.FieldLabel;
                            ViewModel.ClaimNumberPosition = item.Position;
                            ViewModel.ClaimNumberColumnLength = item.ColumnLength;
                            break;

                        case "ReportDate":
                            ViewModel.ReportDateId = item.Id;
                            ViewModel.ReportDateFieldLabel = item.FieldLabel;
                            ViewModel.ReportDatePosition = item.Position;
                            ViewModel.ReportDateColumnLength = item.ColumnLength;
                            break;

                        case "IncidentDate":
                            ViewModel.IncidentDateId = item.Id;
                            ViewModel.IncidentDateFieldLabel = item.FieldLabel;
                            ViewModel.IncidentDatePosition = item.Position;
                            ViewModel.IncidentDateColumnLength = item.ColumnLength;
                            break;

                        case "RegisterDate":
                            ViewModel.RegisterDateId = item.Id;
                            ViewModel.RegisterDateFieldLabel = item.FieldLabel;
                            ViewModel.RegisterDatePosition = item.Position;
                            ViewModel.RegisterDateColumnLength = item.ColumnLength;
                            break;

                        case "ReserveInsured":
                            ViewModel.ReserveInsuredId = item.Id;
                            ViewModel.ReserveInsuredFieldLabel = item.FieldLabel;
                            ViewModel.ReserveInsuredPosition = item.Position;
                            ViewModel.ReserveInsuredColumnLength = item.ColumnLength;
                            break;

                        case "ReserveThirdParty":
                            ViewModel.ReserveThirdPartyId = item.Id;
                            ViewModel.ReserveThirdPartyFieldLabel = item.FieldLabel;
                            ViewModel.ReserveThirdPartyPosition = item.Position;
                            ViewModel.ReserveThirdPartyColumnLength = item.ColumnLength;
                            break;

                        case "Excess":
                            ViewModel.ExcessId = item.Id;
                            ViewModel.ExcessFieldLabel = item.FieldLabel;
                            ViewModel.ExcessPosition = item.Position;
                            ViewModel.ExcessColumnLength = item.ColumnLength;
                            break;

                        case "RecoverFromThirdParty":
                            ViewModel.RecoverFromThirdPartyId = item.Id;
                            ViewModel.RecoverFromThirdPartyFieldLabel = item.FieldLabel;
                            ViewModel.RecoverFromThirdPartyPosition = item.Position;
                            ViewModel.RecoverFromThirdPartyColumnLength = item.ColumnLength;
                            break;

                        default:
                            break;
                    }
                }
                return View("ClaimFileTemplate", ViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClientFileTemplate(ClientGiroViewModel ViewModel)
        {
            if (ViewModel == null)
            {
                throw new ArgumentNullException(nameof(ViewModel));
            };

            if (ModelState.IsValid)
            {
                var tablename = ViewModel.TableName;
                if (tablename == "Client")
                {
                    var fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.TitleId);
                    fileTemplateRecord.Position = ViewModel.TitlePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.TitleColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.ClientTypeId);
                    fileTemplateRecord.Position = ViewModel.ClientTypePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.ClientTypeColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.FirstNameId);
                    fileTemplateRecord.Position = ViewModel.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.FirstNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.LastNameId);
                    fileTemplateRecord.Position = ViewModel.LastNamePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.LastNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.BirthDateId);
                    fileTemplateRecord.Position = ViewModel.BirthDatePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.BirthDateColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.GenderId);
                    fileTemplateRecord.Position = ViewModel.GenderPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.GenderColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.IdNumberId);
                    fileTemplateRecord.Position = ViewModel.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.IdNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.PhoneId);
                    fileTemplateRecord.Position = ViewModel.PhonePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.PhoneColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.MaritalStatusId);
                    fileTemplateRecord.Position = ViewModel.MaritalStatusPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.MaritalStatusColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.CountryId);
                    fileTemplateRecord.Position = ViewModel.CountryPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.CountryColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.OccupationId);
                    fileTemplateRecord.Position = ViewModel.OccupationPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.OccupationColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                }
                return RedirectToAction(nameof(Index), new { ViewModel.PortfolioId });
            }
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PolicyFileTemplate(PolicyGiroViewModel ViewModel)
        {
            if (ViewModel == null)
            {
                throw new ArgumentNullException(nameof(ViewModel));
            };

            if (ModelState.IsValid)
            {
                var tablename = ViewModel.TableName;
                if (tablename == "Policy")
                {
                    var fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.FirstNameId);
                    fileTemplateRecord.Position = ViewModel.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.FirstNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.LastNameId);
                    fileTemplateRecord.Position = ViewModel.LastNamePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.LastNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.IdNumberId);
                    fileTemplateRecord.Position = ViewModel.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.IdNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.PolicyNumberId);
                    fileTemplateRecord.Position = ViewModel.PolicyNumberPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.PolicyNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);
                }
                return RedirectToAction(nameof(Index), new { ViewModel.PortfolioId });

            }
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PremiumFileTemplate(PremiumGiroViewModel ViewModel)
        {
            if (ViewModel == null)
            {
                throw new ArgumentNullException(nameof(ViewModel));
            };

            if (ModelState.IsValid)
            {
                var tablename = ViewModel.TableName;
                if (tablename == "Premium")
                {
                    var fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.FirstNameId);
                    fileTemplateRecord.Position = ViewModel.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.FirstNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.LastNameId);
                    fileTemplateRecord.Position = ViewModel.LastNamePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.LastNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.IdNumberId);
                    fileTemplateRecord.Position = ViewModel.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.IdNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.PolicyNumberId);
                    fileTemplateRecord.Position = ViewModel.PolicyNumberPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.PolicyNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.PremiumId);
                    fileTemplateRecord.Position = ViewModel.PremiumPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.PremiumColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);
                }
                return RedirectToAction(nameof(Index), new { ViewModel.PortfolioId });

            }
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ClaimFileTemplate(ClaimGiroViewModel ViewModel)
        {
            if (ViewModel == null)
            {
                throw new ArgumentNullException(nameof(ViewModel));
            };

            if (ModelState.IsValid)
            {
                var tablename = ViewModel.TableName;
                if (tablename == "Claim")
                {
                    var fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.ClaimNumberId);
                    fileTemplateRecord.Position = ViewModel.ClaimNumberPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.ClaimNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.ReportDateId);
                    fileTemplateRecord.Position = ViewModel.ReportDatePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.ReportDateColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.IncidentDateId);
                    fileTemplateRecord.Position = ViewModel.IncidentDatePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.IncidentDateColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.RegisterDateId);
                    fileTemplateRecord.Position = ViewModel.RegisterDatePosition;
                    fileTemplateRecord.ColumnLength = ViewModel.RegisterDateColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.ReserveInsuredId);
                    fileTemplateRecord.Position = ViewModel.ReserveInsuredPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.ReserveInsuredColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.ReserveThirdPartyId);
                    fileTemplateRecord.Position = ViewModel.ReserveThirdPartyPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.ReserveThirdPartyColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.ExcessId);
                    fileTemplateRecord.Position = ViewModel.ExcessPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.ExcessColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(ViewModel.RecoverFromThirdPartyId);
                    fileTemplateRecord.Position = ViewModel.RecoverFromThirdPartyPosition;
                    fileTemplateRecord.ColumnLength = ViewModel.RecoverFromThirdPartyColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);
                }
                return RedirectToAction(nameof(Index), new { ViewModel.PortfolioId });

            }
            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var ViewModel = await _fileTemplateService.GetByIdAsync(id);

            var portfolioId = ViewModel.PortfolioId;
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            ViewModel.PortfolioId = portfolioId;
            ViewModel.PortfolioName = portfolio.Name;
            ViewModel.FileTypeList = SelectLists.FileFormats(Guid.Empty);

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FileTemplateViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _fileTemplateService.UpdateAsync(ViewModel);
                return RedirectToAction(nameof(Index), new { portfolioId = ViewModel.PortfolioId });
            }
            return View(ViewModel);
        }
    }
}
