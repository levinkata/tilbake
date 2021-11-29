using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Enums;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class FileTemplatesController : BaseController
    {
        public FileTemplatesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var result = await _unitOfWork.FileTemplates.GetByPortfolioId(portfolioId);
            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);
            var model = _mapper.Map<IEnumerable<FileTemplate>, IEnumerable<FileTemplateViewModel>>(result);
            ViewBag.PortfolioId = portfolioId;
            ViewBag.Portfolio = portfolio.Name;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);

            FileTemplateViewModel model = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                FileTypeList = MVCHelperExtensions.EnumToSelectList<FileType>(null)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FileTemplateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var fileTemplate = _mapper.Map<FileTemplateViewModel, FileTemplate>(model);
                fileTemplate.Id = Guid.NewGuid();
                fileTemplate.DateAdded = DateTime.Now;
                await _unitOfWork.FileTemplates.AddAsync(fileTemplate);

                var fileTemplateId = fileTemplate.Id;

                PopulateFileTemplateRecords(fileTemplateId);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { portfolioId = model.PortfolioId });
            }
            model.FileTypeList = MVCHelperExtensions.EnumToSelectList<FileType>(model.FileType.ToString());
            return View(model);
        }

        public async Task<IActionResult> SelectTable(Guid portfolioId, Guid fileTemplateId, FileType fileType)
        {
            var fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetAll();
            var tables = fileTemplateRecord.Select(t => new { Id = t.TableName, Name = t.TableLabel })
                                    .Distinct().ToList();

            SelectedTableViewModel model = new()
            {
                PortfolioId = portfolioId,
                FileTemplateId = fileTemplateId,
                FileType = fileType,
                TableList = new SelectList(tables, "Id", "Name", tables.FirstOrDefault())
            };
            return  View(model);
        }

        [HttpPost, ActionName("SelectTable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectTableConfirmed(SelectedTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("TableFileTemplate", new
                {
                    portfolioId = model.PortfolioId,
                    fileTemplateId = model.FileTemplateId,
                    tableName = model.TableName,
                    fileType = model.FileType
                });
            }

            var fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetAll();
            var tables = fileTemplateRecord.Select(t => new { Id = t.TableName, Name = t.TableLabel })
                                    .Distinct().ToList();

            model.TableList = new SelectList(tables, "Id", "Name", tables.FirstOrDefault());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> TableFileTemplate(Guid fileTemplateId,
                                            string tableName, FileType fileType)
        {
            var fileTemplate = await _unitOfWork.FileTemplates.GetById(fileTemplateId);

            var portfolioId = fileTemplate.PortfolioId;
            var portfolioName = fileTemplate.Portfolio.Name;
            var fileTemplateRecords = await _unitOfWork.FileTemplateRecords.GetTableFileTemplate(fileTemplateId, tableName);

            if (tableName == "Client")
            {
                ClientGiroViewModel model = new()
                {
                    PortfolioId = portfolioId,
                    PortfolioName = portfolioName,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplate.Name
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldName = item.FieldName;

                    switch (fieldName)
                    {
                        case "Title":
                            model.TitleId = item.Id;
                            model.TitleFieldLabel = item.FieldLabel;
                            model.TitlePosition = item.Position;
                            model.TitleColumnLength = item.ColumnLength;
                            break;

                        case "ClientType":
                            model.ClientTypeId = item.Id;
                            model.ClientTypeFieldLabel = item.FieldLabel;
                            model.ClientTypePosition = item.Position;
                            model.ClientTypeColumnLength = item.ColumnLength;
                            break;

                        case "FirstName":
                            model.FirstNameId = item.Id;
                            model.FirstNameFieldLabel = item.FieldLabel;
                            model.FirstNamePosition = item.Position;
                            model.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            model.LastNameId = item.Id;
                            model.LastNameFieldLabel = item.FieldLabel;
                            model.LastNamePosition = item.Position;
                            model.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "BirthDate":
                            model.BirthDateId = item.Id;
                            model.BirthDateFieldLabel = item.FieldLabel;
                            model.BirthDatePosition = item.Position;
                            model.BirthDateColumnLength = item.ColumnLength;
                            break;

                        case "Gender":
                            model.GenderId = item.Id;
                            model.GenderFieldLabel = item.FieldLabel;
                            model.GenderPosition = item.Position;
                            model.GenderColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            model.IdNumberId = item.Id;
                            model.IdNumberFieldLabel = item.FieldLabel;
                            model.IdNumberPosition = item.Position;
                            model.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "MaritalStatus":
                            model.MaritalStatusId = item.Id;
                            model.MaritalStatusFieldLabel = item.FieldLabel;
                            model.MaritalStatusPosition = item.Position;
                            model.MaritalStatusColumnLength = item.ColumnLength;
                            break;

                        case "Phone":
                            model.PhoneId = item.Id;
                            model.PhoneFieldLabel = item.FieldLabel;
                            model.PhonePosition = item.Position;
                            model.PhoneColumnLength = item.ColumnLength;
                            break;

                        case "Country":
                            model.CountryId = item.Id;
                            model.CountryFieldLabel = item.FieldLabel;
                            model.CountryPosition = item.Position;
                            model.CountryColumnLength = item.ColumnLength;
                            break;

                        case "Occupation":
                            model.OccupationId = item.Id;
                            model.OccupationFieldLabel = item.FieldLabel;
                            model.OccupationPosition = item.Position;
                            model.OccupationColumnLength = item.ColumnLength;
                            break;

                        default:
                            break;
                    }
                }
                return View("ClientFileTemplate", model);
            }
            else if (tableName == "Premium")
            {
                PremiumGiroViewModel model = new()
                {
                    PortfolioId = portfolioId,
                    PortfolioName = portfolioName,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplate.Name
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldName = item.FieldName;

                    switch (fieldName)
                    {
                        case "FirstName":
                            model.FirstNameId = item.Id;
                            model.FirstNameFieldLabel = item.FieldLabel;
                            model.FirstNamePosition = item.Position;
                            model.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            model.LastNameId = item.Id;
                            model.LastNameFieldLabel = item.FieldLabel;
                            model.LastNamePosition = item.Position;
                            model.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            model.IdNumberId = item.Id;
                            model.IdNumberFieldLabel = item.FieldLabel;
                            model.IdNumberPosition = item.Position;
                            model.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "PolicyNumber":
                            model.PolicyNumberId = item.Id;
                            model.PolicyNumberFieldLabel = item.FieldLabel;
                            model.PolicyNumberPosition = item.Position;
                            model.PolicyNumberColumnLength = item.ColumnLength;
                            break;

                        case "Amount":
                            model.PremiumId = item.Id;
                            model.PremiumFieldLabel = item.FieldLabel;
                            model.PremiumPosition = item.Position;
                            model.PremiumColumnLength = item.ColumnLength;
                            break;
                        default:
                            break;
                    }
                }
                return View("PremiumFileTemplate", model);
            }
            else if (tableName == "Policy")
            {
                PolicyGiroViewModel model = new()
                {
                    PortfolioId = portfolioId,
                    PortfolioName = portfolioName,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplate.Name
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldname = item.FieldName;

                    switch (fieldname)
                    {
                        case "FirstName":
                            model.FirstNameId = item.Id;
                            model.FirstNameFieldLabel = item.FieldLabel;
                            model.FirstNamePosition = item.Position;
                            model.FirstNameColumnLength = item.ColumnLength;
                            break;

                        case "LastName":
                            model.LastNameId = item.Id;
                            model.LastNameFieldLabel = item.FieldLabel;
                            model.LastNamePosition = item.Position;
                            model.LastNameColumnLength = item.ColumnLength;
                            break;

                        case "IdNumber":
                            model.IdNumberId = item.Id;
                            model.IdNumberFieldLabel = item.FieldLabel;
                            model.IdNumberPosition = item.Position;
                            model.IdNumberColumnLength = item.ColumnLength;
                            break;

                        case "PolicyNumber":
                            model.PolicyNumberId = item.Id;
                            model.PolicyNumberFieldLabel = item.FieldLabel;
                            model.PolicyNumberPosition = item.Position;
                            model.PolicyNumberColumnLength = item.ColumnLength;
                            break;

                        default:
                            break;
                    }
                }
                return View("PolicyFileTemplate", model);
            }
            else if (tableName == "Claim")
            {
                ClaimGiroViewModel model = new()
                {
                    PortfolioId = portfolioId,
                    PortfolioName = portfolioName,
                    FileTemplateId = fileTemplateId,
                    FileType = fileType,
                    TableName = tableName,
                    FileTemplate = fileTemplateRecords.FirstOrDefault().FileTemplate.Name
                };

                foreach (var item in fileTemplateRecords)
                {
                    var fieldname = item.FieldName;

                    switch (fieldname)
                    {
                        case "ClaimNumber":
                            model.ClaimNumberId = item.Id;
                            model.ClaimNumberFieldLabel = item.FieldLabel;
                            model.ClaimNumberPosition = item.Position;
                            model.ClaimNumberColumnLength = item.ColumnLength;
                            break;

                        case "ReportDate":
                            model.ReportDateId = item.Id;
                            model.ReportDateFieldLabel = item.FieldLabel;
                            model.ReportDatePosition = item.Position;
                            model.ReportDateColumnLength = item.ColumnLength;
                            break;

                        case "IncidentDate":
                            model.IncidentDateId = item.Id;
                            model.IncidentDateFieldLabel = item.FieldLabel;
                            model.IncidentDatePosition = item.Position;
                            model.IncidentDateColumnLength = item.ColumnLength;
                            break;

                        case "RegisterDate":
                            model.RegisterDateId = item.Id;
                            model.RegisterDateFieldLabel = item.FieldLabel;
                            model.RegisterDatePosition = item.Position;
                            model.RegisterDateColumnLength = item.ColumnLength;
                            break;

                        case "ReserveInsured":
                            model.ReserveInsuredId = item.Id;
                            model.ReserveInsuredFieldLabel = item.FieldLabel;
                            model.ReserveInsuredPosition = item.Position;
                            model.ReserveInsuredColumnLength = item.ColumnLength;
                            break;

                        case "ReserveThirdParty":
                            model.ReserveThirdPartyId = item.Id;
                            model.ReserveThirdPartyFieldLabel = item.FieldLabel;
                            model.ReserveThirdPartyPosition = item.Position;
                            model.ReserveThirdPartyColumnLength = item.ColumnLength;
                            break;

                        case "Excess":
                            model.ExcessId = item.Id;
                            model.ExcessFieldLabel = item.FieldLabel;
                            model.ExcessPosition = item.Position;
                            model.ExcessColumnLength = item.ColumnLength;
                            break;

                        case "RecoverFromThirdParty":
                            model.RecoverFromThirdPartyId = item.Id;
                            model.RecoverFromThirdPartyFieldLabel = item.FieldLabel;
                            model.RecoverFromThirdPartyPosition = item.Position;
                            model.RecoverFromThirdPartyColumnLength = item.ColumnLength;
                            break;

                        default:
                            break;
                    }
                }
                return View("ClaimFileTemplate", model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClientFileTemplate(ClientGiroViewModel model)
        {

            if (ModelState.IsValid)
            {
                var tablename = model.TableName;
                if (tablename == "Client")
                {
                    var fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.TitleId);
                    fileTemplateRecord.Position = model.TitlePosition;
                    fileTemplateRecord.ColumnLength = model.TitleColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.ClientTypeId);
                    fileTemplateRecord.Position = model.ClientTypePosition;
                    fileTemplateRecord.ColumnLength = model.ClientTypeColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.FirstNameId);
                    fileTemplateRecord.Position = model.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = model.FirstNameColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.LastNameId);
                    fileTemplateRecord.Position = model.LastNamePosition;
                    fileTemplateRecord.ColumnLength = model.LastNameColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.BirthDateId);
                    fileTemplateRecord.Position = model.BirthDatePosition;
                    fileTemplateRecord.ColumnLength = model.BirthDateColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.GenderId);
                    fileTemplateRecord.Position = model.GenderPosition;
                    fileTemplateRecord.ColumnLength = model.GenderColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.IdNumberId);
                    fileTemplateRecord.Position = model.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = model.IdNumberColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.PhoneId);
                    fileTemplateRecord.Position = model.PhonePosition;
                    fileTemplateRecord.ColumnLength = model.PhoneColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.MaritalStatusId);
                    fileTemplateRecord.Position = model.MaritalStatusPosition;
                    fileTemplateRecord.ColumnLength = model.MaritalStatusColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.CountryId);
                    fileTemplateRecord.Position = model.CountryPosition;
                    fileTemplateRecord.ColumnLength = model.CountryColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.OccupationId);
                    fileTemplateRecord.Position = model.OccupationPosition;
                    fileTemplateRecord.ColumnLength = model.OccupationColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                }
                return RedirectToAction(nameof(Index), new { model.PortfolioId });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PolicyFileTemplate(PolicyGiroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tablename = model.TableName;
                if (tablename == "Policy")
                {
                    var fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.FirstNameId);
                    fileTemplateRecord.Position = model.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = model.FirstNameColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.LastNameId);
                    fileTemplateRecord.Position = model.LastNamePosition;
                    fileTemplateRecord.ColumnLength = model.LastNameColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.IdNumberId);
                    fileTemplateRecord.Position = model.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = model.IdNumberColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.PolicyNumberId);
                    fileTemplateRecord.Position = model.PolicyNumberPosition;
                    fileTemplateRecord.ColumnLength = model.PolicyNumberColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);
                }
                return RedirectToAction(nameof(Index), new { model.PortfolioId });

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PremiumFileTemplate(PremiumGiroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tablename = model.TableName;
                if (tablename == "Premium")
                {
                    var fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.FirstNameId);
                    fileTemplateRecord.Position = model.FirstNamePosition;
                    fileTemplateRecord.ColumnLength = model.FirstNameColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.LastNameId);
                    fileTemplateRecord.Position = model.LastNamePosition;
                    fileTemplateRecord.ColumnLength = model.LastNameColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.IdNumberId);
                    fileTemplateRecord.Position = model.IdNumberPosition;
                    fileTemplateRecord.ColumnLength = model.IdNumberColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.PolicyNumberId);
                    fileTemplateRecord.Position = model.PolicyNumberPosition;
                    fileTemplateRecord.ColumnLength = model.PolicyNumberColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.PremiumId);
                    fileTemplateRecord.Position = model.PremiumPosition;
                    fileTemplateRecord.ColumnLength = model.PremiumColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);
                }
                return RedirectToAction(nameof(Index), new { model.PortfolioId });

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ClaimFileTemplate(ClaimGiroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tablename = model.TableName;
                if (tablename == "Claim")
                {
                    var fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.ClaimNumberId);
                    fileTemplateRecord.Position = model.ClaimNumberPosition;
                    fileTemplateRecord.ColumnLength = model.ClaimNumberColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.ReportDateId);
                    fileTemplateRecord.Position = model.ReportDatePosition;
                    fileTemplateRecord.ColumnLength = model.ReportDateColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.IncidentDateId);
                    fileTemplateRecord.Position = model.IncidentDatePosition;
                    fileTemplateRecord.ColumnLength = model.IncidentDateColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.RegisterDateId);
                    fileTemplateRecord.Position = model.RegisterDatePosition;
                    fileTemplateRecord.ColumnLength = model.RegisterDateColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.ReserveInsuredId);
                    fileTemplateRecord.Position = model.ReserveInsuredPosition;
                    fileTemplateRecord.ColumnLength = model.ReserveInsuredColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.ReserveThirdPartyId);
                    fileTemplateRecord.Position = model.ReserveThirdPartyPosition;
                    fileTemplateRecord.ColumnLength = model.ReserveThirdPartyColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.ExcessId);
                    fileTemplateRecord.Position = model.ExcessPosition;
                    fileTemplateRecord.ColumnLength = model.ExcessColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);

                    fileTemplateRecord = await _unitOfWork.FileTemplateRecords.GetById(model.RecoverFromThirdPartyId);
                    fileTemplateRecord.Position = model.RecoverFromThirdPartyPosition;
                    fileTemplateRecord.ColumnLength = model.RecoverFromThirdPartyColumnLength;
                    await _unitOfWork.FileTemplateRecords.Update(fileTemplateRecord);
                }
                return RedirectToAction(nameof(Index), new { model.PortfolioId });

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.FileTemplates.GetById(id);

            var portfolioId = result.Portfolio.Id;
            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);
            var model = _mapper.Map<FileTemplate, FileTemplateViewModel>(result);

            model.PortfolioId = portfolioId;
            model.PortfolioName = portfolio.Name;
            model.FileTypeList = MVCHelperExtensions.EnumToSelectList<FileType>(null);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FileTemplateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fileTemplate = _mapper.Map<FileTemplateViewModel, FileTemplate>(model);
                _unitOfWork.FileTemplates.Update(model.Id, fileTemplate);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { portfolioId = model.PortfolioId });
            }
            return View(model);
        }

        public void PopulateFileTemplateRecords(Guid fileTemplateId)
        {
            var fileTemplateRecords = new List<FileTemplateRecord>
            {
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Title",FieldLabel="Title",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="ClientType",FieldLabel="Client Type",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="FirstName",FieldLabel="First Name",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="LastName",FieldLabel="Last Name",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="BirthDate",FieldLabel="Birth Date",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Gender",FieldLabel="Gender",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="IdNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Phone",FieldLabel="Phone",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Country",FieldLabel="Country",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="MaritalStatus",FieldLabel="Marital Status",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Occupation",FieldLabel="Occupation",Position=null,ColumnLength=0,IsKey=false},

                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Policy",TableLabel="Policy",FieldName="IdNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Policy",TableLabel="Policy",FieldName="FirstName",FieldLabel="First Name",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Policy",TableLabel="Policy",FieldName="LastName",FieldLabel="Last Name",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Policy",TableLabel="Policy",FieldName="PolicyNumber",FieldLabel="Policy Number",Position=null,ColumnLength=0,IsKey=false},

                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="IdNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="PolicyNumber",FieldLabel="Policy Number",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="FirstName",FieldLabel="First Name",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="LastName",FieldLabel="Last Name",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="Amount",FieldLabel="Premium",Position=null,ColumnLength=0,IsKey=false},

                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="ClaimNumber",FieldLabel="Claim Number",Position=null,ColumnLength=0,IsKey=true},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="ReportDate",FieldLabel="Report Date",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="IncidentDate",FieldLabel="Incident Date",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="RegisterDate",FieldLabel="Register Date",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="ReserveInsured",FieldLabel="Reserve Insured",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="ReserveThirdParty",FieldLabel="Reserve Third Party",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="Excess",FieldLabel="Excess",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim", FieldName="RecoverFromThirdParty",FieldLabel="Recover From Third Party",Position=null,ColumnLength=0,IsKey=false}
            };

            _unitOfWork.FileTemplateRecords.AddRange(fileTemplateRecords);
        }
    }
}
