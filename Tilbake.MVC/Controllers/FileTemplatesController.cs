using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Enums;

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
            var resources = await _fileTemplateService.GetByPortfolioIdAsync(portfolioId);
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            ViewBag.PortfolioId = portfolioId;
            ViewBag.Portfolio = portfolio.Name;
            return View(resources);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            FileTemplateSaveResource resource = new()
            {
                PortfolioId = portfolioId,
                Portfolio = portfolio.Name,
                FileTypeList = SelectLists.FileFormats(Guid.Empty)
            };

            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FileTemplateSaveResource resource)
        {
            if(ModelState.IsValid)
            {
                await _fileTemplateService.AddAsync(resource);

                return RedirectToAction(nameof(Index), new { portfolioId = resource.PortfolioId });
            }
            resource.FileTypeList = SelectLists.FileFormats(Guid.Empty);
            return View(resource);
        }

        public async Task<IActionResult> SelectTable(Guid portfolioId, Guid fileTemplateId, FileType fileType)
        {
            var fileTemplateRecord = await _fileTemplateRecordService.GetAllAsync();
            var tables = fileTemplateRecord.Select(t => new { t.TableName, t.TableLabel })
                                    .Distinct().ToList();

            SelectedTableResource resource = new()
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
            return  View(resource);
        }

        [HttpPost, ActionName("SelectTable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectTableConfirmed(SelectedTableResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            };

            if (ModelState.IsValid)
            {
                return RedirectToAction("TableFileTemplate", new
                {
                    portfolioId = resource.PortfolioId,
                    fileTemplateId = resource.FileTemplateId,
                    tableName = resource.TableName,
                    fileType = resource.FileType
                });
            }

            var filterTables = await _fileTemplateRecordService.GetAllAsync();
            var tables = filterTables.Select(t => new { t.TableName, t.TableLabel })
                                    .Distinct().ToList();

            resource.TableList = new SelectList(tables.Select(t => new
                                        {
                                            Id = t.TableName,
                                            Name = t.TableLabel
                                        }).ToList(), "Id", "Name", tables.FirstOrDefault());

            return View(resource);
        }

        public async Task<IActionResult> TableFileTemplate(Guid fileTemplateId,
                                            string tableName, FileType fileType)
        {
            var fileTemplate = await _fileTemplateService.GetByIdAsync(fileTemplateId);
            var portfolioId = fileTemplate.PortfolioId;
            var portfolio = fileTemplate.Portfolio;
            var fileTemplateRecords = await _fileTemplateRecordService.GetTableFileTemplate(fileTemplateId, tableName);

            if (tableName == "Client")
            {
                ClientGiroResource resource = new()
                {
                    PortfolioId = portfolioId,
                    Portfolio = portfolio,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplate
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldName = item.FieldName;

                    switch (fieldName)
                    {
                        case "Title":
                            resource.TitleId = item.Id;
                            resource.TitleFieldLabel = item.FieldLabel;
                            resource.TitlePosition = item.Position;
                            resource.TitleColumnLength = item.ColumnLength;
                            break;

                        case "ClientType":
                            resource.ClientTypeId = item.Id;
                            resource.ClientTypeFieldLabel = item.FieldLabel;
                            resource.ClientTypePosition = item.Position;
                            resource.ClientTypeColumnLength = item.ColumnLength;
                            break;

                        case "FirstName":
                            resource.FirstNameId = item.Id;
                            resource.FirstNameFieldLabel = item.FieldLabel;
                            resource.FirstNamePosition = item.Position;
                            resource.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            resource.LastNameId = item.Id;
                            resource.LastNameFieldLabel = item.FieldLabel;
                            resource.LastNamePosition = item.Position;
                            resource.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "BirthDate":
                            resource.BirthDateId = item.Id;
                            resource.BirthDateFieldLabel = item.FieldLabel;
                            resource.BirthDatePosition = item.Position;
                            resource.BirthDateColumnLength = item.ColumnLength;
                            break;

                        case "Gender":
                            resource.GenderId = item.Id;
                            resource.GenderFieldLabel = item.FieldLabel;
                            resource.GenderPosition = item.Position;
                            resource.GenderColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            resource.IdNumberId = item.Id;
                            resource.IdNumberFieldLabel = item.FieldLabel;
                            resource.IdNumberPosition = item.Position;
                            resource.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "MaritalStatus":
                            resource.MaritalStatusId = item.Id;
                            resource.MaritalStatusFieldLabel = item.FieldLabel;
                            resource.MaritalStatusPosition = item.Position;
                            resource.MaritalStatusColumnLength = item.ColumnLength;
                            break;

                        case "Phone":
                            resource.PhoneId = item.Id;
                            resource.PhoneFieldLabel = item.FieldLabel;
                            resource.PhonePosition = item.Position;
                            resource.PhoneColumnLength = item.ColumnLength;
                            break;

                        case "Mobile":
                            resource.MobileId = item.Id;
                            resource.MobileFieldLabel = item.FieldLabel;
                            resource.MobilePosition = item.Position;
                            resource.MobileColumnLength = item.ColumnLength;
                            break;

                        case "Nationality":
                            resource.CountryId = item.Id;
                            resource.CountryFieldLabel = item.FieldLabel;
                            resource.CountryPosition = item.Position;
                            resource.CountryColumnLength = item.ColumnLength;
                            break;

                        case "Email":
                            resource.EmailId = item.Id;
                            resource.EmailFieldLabel = item.FieldLabel;
                            resource.EmailPosition = item.Position;
                            resource.EmailColumnLength = item.ColumnLength;
                            break;

                        case "Occupation":
                            resource.OccupationId = item.Id;
                            resource.OccupationFieldLabel = item.FieldLabel;
                            resource.OccupationPosition = item.Position;
                            resource.OccupationColumnLength = item.ColumnLength;
                            break;

                        default:
                            break;
                    }
                }
                return View("ClientFileTemplate", resource);
            }
            else if (tableName == "Premium")
            {
                PremiumGiroResource resource = new()
                {
                    PortfolioId = portfolioId,
                    Portfolio = portfolio,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplate
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldName = item.FieldName;

                    switch (fieldName)
                    {
                        case "FirstName":
                            resource.FirstNameId = item.Id;
                            resource.FirstNameFieldLabel = item.FieldLabel;
                            resource.FirstNamePosition = item.Position;
                            resource.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            resource.LastNameId = item.Id;
                            resource.LastNameFieldLabel = item.FieldLabel;
                            resource.LastNamePosition = item.Position;
                            resource.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            resource.IdNumberId = item.Id;
                            resource.IdNumberFieldLabel = item.FieldLabel;
                            resource.IdNumberPosition = item.Position;
                            resource.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "PolicyNumber":
                            resource.PolicyNumberId = item.Id;
                            resource.PolicyNumberFieldLabel = item.FieldLabel;
                            resource.PolicyNumberPosition = item.Position;
                            resource.PolicyNumberColumnLength = item.ColumnLength;
                            break;

                        case "Amount":
                            resource.PremiumId = item.Id;
                            resource.PremiumFieldLabel = item.FieldLabel;
                            resource.PremiumPosition = item.Position;
                            resource.PremiumColumnLength = item.ColumnLength;
                            break;
                        default:
                            break;
                    }
                }
                return View("PremiumFileTemplate", resource);
            }
            else if (tableName == "Policy")
            {
                PolicyGiroResource resource = new()
                {
                    PortfolioId = portfolioId,
                    Portfolio = portfolio,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplate
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldname = item.FieldName;

                    switch (fieldname)
                    {
                        case "FirstName":
                            resource.FirstNameId = item.Id;
                            resource.FirstNameFieldLabel = item.FieldLabel;
                            resource.FirstNamePosition = item.Position;
                            resource.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            resource.LastNameId = item.Id;
                            resource.LastNameFieldLabel = item.FieldLabel;
                            resource.LastNamePosition = item.Position;
                            resource.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            resource.IdNumberId = item.Id;
                            resource.IdNumberFieldLabel = item.FieldLabel;
                            resource.IdNumberPosition = item.Position;
                            resource.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "PolicyNumber":
                            resource.PolicyNumberId = item.Id;
                            resource.PolicyNumberFieldLabel = item.FieldLabel;
                            resource.PolicyNumberPosition = item.Position;
                            resource.PolicyNumberColumnLength = item.ColumnLength;
                            break;

                        default:
                            break;
                    }
                }
                return View("PolicyFileTemplate", resource);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClientFileTemplate(ClientGiroResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            };

            if (ModelState.IsValid)
            {
                var tablename = resource.TableName;
                if (tablename == "Client")
                {
                    var fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.TitleId);
                    fileTemplateRecord.Position = resource.TitlePosition;
                    fileTemplateRecord.ColumnLength = resource.TitleColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.ClientTypeId);
                    fileTemplateRecord.Position = resource.ClientTypePosition;
                    fileTemplateRecord.ColumnLength = resource.ClientTypeColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.FirstNameId);
                    fileTemplateRecord.Position = resource.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = resource.FirstNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.LastNameId);
                    fileTemplateRecord.Position = resource.LastNamePosition;
                    fileTemplateRecord.ColumnLength = resource.LastNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.BirthDateId);
                    fileTemplateRecord.Position = resource.BirthDatePosition;
                    fileTemplateRecord.ColumnLength = resource.BirthDateColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.GenderId);
                    fileTemplateRecord.Position = resource.GenderPosition;
                    fileTemplateRecord.ColumnLength = resource.GenderColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.IdNumberId);
                    fileTemplateRecord.Position = resource.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = resource.IdNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.PhoneId);
                    fileTemplateRecord.Position = resource.PhonePosition;
                    fileTemplateRecord.ColumnLength = resource.PhoneColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.MobileId);
                    fileTemplateRecord.Position = resource.MobilePosition;
                    fileTemplateRecord.ColumnLength = resource.MobileColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.MaritalStatusId);
                    fileTemplateRecord.Position = resource.MaritalStatusPosition;
                    fileTemplateRecord.ColumnLength = resource.MaritalStatusColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.CountryId);
                    fileTemplateRecord.Position = resource.CountryPosition;
                    fileTemplateRecord.ColumnLength = resource.CountryColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.EmailId);
                    fileTemplateRecord.Position = resource.EmailPosition;
                    fileTemplateRecord.ColumnLength = resource.EmailColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.OccupationId);
                    fileTemplateRecord.Position = resource.OccupationPosition;
                    fileTemplateRecord.ColumnLength = resource.OccupationColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                }
                return RedirectToAction(nameof(Index), new { resource.PortfolioId });
            }
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PolicyFileTemplate(PolicyGiroResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            };

            if (ModelState.IsValid)
            {
                var tablename = resource.TableName;
                if (tablename == "Policy")
                {
                    var fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.FirstNameId);
                    fileTemplateRecord.Position = resource.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = resource.FirstNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.LastNameId);
                    fileTemplateRecord.Position = resource.LastNamePosition;
                    fileTemplateRecord.ColumnLength = resource.LastNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.IdNumberId);
                    fileTemplateRecord.Position = resource.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = resource.IdNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord).ConfigureAwait(true);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.PolicyNumberId);
                    fileTemplateRecord.Position = resource.PolicyNumberPosition;
                    fileTemplateRecord.ColumnLength = resource.PolicyNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);
                }
                return RedirectToAction(nameof(Index), new { resource.PortfolioId });

            }
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PremiumFileTemplate(PremiumGiroResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            };

            if (ModelState.IsValid)
            {
                var tablename = resource.TableName;
                if (tablename == "Premium")
                {
                    var fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.FirstNameId);
                    fileTemplateRecord.Position = resource.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = resource.FirstNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.LastNameId);
                    fileTemplateRecord.Position = resource.LastNamePosition;
                    fileTemplateRecord.ColumnLength = resource.LastNameColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.IdNumberId);
                    fileTemplateRecord.Position = resource.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = resource.IdNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.PolicyNumberId);
                    fileTemplateRecord.Position = resource.PolicyNumberPosition;
                    fileTemplateRecord.ColumnLength = resource.PolicyNumberColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);

                    fileTemplateRecord = await _fileTemplateRecordService.GetByIdAsync(resource.PremiumId);
                    fileTemplateRecord.Position = resource.PremiumPosition;
                    fileTemplateRecord.ColumnLength = resource.PremiumColumnLength;
                    await _fileTemplateRecordService.UpdateAsync(fileTemplateRecord);
                }
                return RedirectToAction(nameof(Index), new { resource.PortfolioId });

            }
            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var resource = await _fileTemplateService.GetByIdAsync(id);

            var portfolioId = resource.PortfolioId;
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            resource.PortfolioId = portfolioId;
            resource.Portfolio = portfolio.Name;
            resource.FileTypeList = SelectLists.FileFormats(Guid.Empty);

            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FileTemplateResource resource)
        {
            if (ModelState.IsValid)
            {
                await _fileTemplateService.UpdateAsync(resource);
                return RedirectToAction(nameof(Index), new { portfolioId = resource.PortfolioId });
            }
            return View(resource);
        }
    }
}
