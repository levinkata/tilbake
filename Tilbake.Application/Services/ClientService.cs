using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using Tilbake.Application.Extensions;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Enums;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CultureInfo culture = new("en-GB", false);

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ClientSaveResource resource)
        {
            var client = _mapper.Map<ClientSaveResource, Client>(resource);
            client.Id = Guid.NewGuid();
            client.DateAdded = DateTime.Now;
            await _unitOfWork.Clients.AddAsync(client);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Clients.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(ClientResource resource)
        {
            var client = _mapper.Map<ClientResource, Client>(resource);
            await _unitOfWork.Clients.DeleteAsync(client);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ClientResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Clients.GetAllAsync());
            result = result.OrderBy(n => n.LastName);

            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);

            return resources;
        }

        public async Task<ClientResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Clients.GetFirstOrDefaultAsync(
                                                    r => r.Id == id,
                                                    r => r.ClientType,
                                                    r => r.Country,
                                                    r => r.Gender,
                                                    r => r.MaritalStatus,
                                                    r => r.Occupation,
                                                    r => r.Title);

            var resource = _mapper.Map<Client, ClientResource>(result);

            return resource;
        }

        public async Task<ClientResource> GetByIdNumberAsync(string idNumber)
        {
            var result = await _unitOfWork.Clients.GetFirstOrDefaultAsync(
                                            c => c.IdNumber == idNumber,
                                            c => c.ClientType,
                                            c => c.Country,
                                            c => c.Gender,
                                            c => c.MaritalStatus,
                                            c => c.Occupation,
                                            c => c.Title);

            var resource = _mapper.Map<Client, ClientResource>(result);

            return resource;
        }

        public async Task<IEnumerable<ClientResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.Clients.GetAllAsync(
                                                        e => e.PortfolioClients.Any(p => p.PortfolioId == portfolioId),
                                                        e => e.OrderBy(r => r.LastName),
                                                        e => e.PortfolioClients,
                                                        c => c.ClientType,
                                                        c => c.Country,
                                                        c => c.Gender,
                                                        c => c.MaritalStatus,
                                                        c => c.Occupation,
                                                        c => c.Title);

            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);
            return resources;
        }

        public async Task<ClientResource> GetByClientIdAsync(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.Clients.GetFirstOrDefaultAsync(
                                                    c => c.PortfolioClients.Any(p => p.PortfolioId == portfolioId && p.ClientId == clientId),
                                                    c => c.PortfolioClients,
                                                    c => c.ClientType,
                                                    c => c.Country,
                                                    c => c.Gender,
                                                    c => c.MaritalStatus,
                                                    c => c.Occupation,
                                                    c => c.Title);

            var resource = _mapper.Map<Client, ClientResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(ClientResource resource)
        {
            var client = _mapper.Map<ClientResource, Client>(resource);
            await _unitOfWork.Clients.UpdateAsync(resource.Id, client);
            
            var clientId = client.Id;
            var clientCarriers = await _unitOfWork.ClientCarriers.GetAllAsync(
                                                    r => r.ClientId == clientId);

            if (clientCarriers != null)
            {
                await _unitOfWork.ClientCarriers.DeleteRangeAsync(clientCarriers);
            }

            return await _unitOfWork.SaveAsync();
        }

        public async Task<ClientResource> GetByPolicyIdAsync(Guid policyId)
        {
            var result = await _unitOfWork.Clients.GetFirstOrDefaultAsync(
                                        c => c.PortfolioClients.Any(p => p.Policies.Any(r => r.Id == policyId)));

            var resource = _mapper.Map<Client, ClientResource>(result);
            return resource;
        }

        public async Task<int> ImportBulkAsync(UpLoadFileResource resource)
        {
            try
            {
                string FirstNamePos = null;
                string LastNamePos = null;
                string IdNumberPos = null;
                string BirthDatePos = null;
                string TitlePos = null;
                string GenderPos = null;
                string OccupationPos = null;
                string CountryPos = null;
                string MaritalStatusPos = null;
                string EmailPos = null;
                string MobilePos = null;
                string PhonePos = null;

                NumberStyles numberStyle = NumberStyles.Integer;
                string dateFormat = "dd/MM/yyyy";
                string nullDate = "01/01/1900";
                string tableName = "Client";

                var resources = await _unitOfWork.ClientBulks.GetAllAsync(r => r.PortfolioId == resource.PortfolioId);
                if (resources != null)
                {
                    var clientBulks = _mapper.Map<IEnumerable<ClientBulkResource>, IEnumerable<ClientBulk>>(resources);
                    await _unitOfWork.ClientBulks.DeleteRangeAsync(clientBulks);
                    await _unitOfWork.SaveAsync();
                }

                var fileTemplateRecords = await _unitOfWork.FileTemplateRecords.GetAllAsync(
                                                        e => e.FileTemplateId == resource.FileTemplateId && e.TableName == tableName,
                                                        e => e.OrderBy(n => n.FieldName),
                                                        e => e.FileTemplate);

                foreach (var row in fileTemplateRecords)
                {
                    switch (row.FieldName)
                    {
                        case "IdNumber":
                            IdNumberPos = row.Position;
                            break;
                        case "FirstName":
                            FirstNamePos = row.Position;
                            break;
                        case "LastName":
                            LastNamePos = row.Position;
                            break;
                        case "BirthDate":
                            BirthDatePos = row.Position;
                            break;
                        case "Title":
                            TitlePos = row.Position;
                            break;
                        case "Gender":
                            GenderPos = row.Position;
                            break;
                        case "Occupation":
                            OccupationPos = row.Position;
                            break;
                        case "Land":
                            CountryPos = row.Position;
                            break;
                        case "Carrier":
                            MaritalStatusPos = row.Position;
                            break;
                        case "Email":
                            EmailPos = row.Position;
                            break;
                        case "Mobile":
                            MobilePos = row.Position;
                            break;
                        case "Phone":
                            PhonePos = row.Position;
                            break;
                        case "default":
                            break;
                    }
                }

                List<ClientBulk> clientDTOs = new();

                using (MemoryStream ms = new())
                {
                    await resource.UpLoadFile.CopyToAsync(ms);

                    try
                    {
                        if (resource.FileType == FileType.Excel)
                        {
                            using ExcelPackage package = new(ms);

                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            int rowCount = worksheet.Dimension.Rows;

                            for (int row = resource.StartRow; row <= rowCount; row++)
                            {
                                ClientBulk clientDTO = new();

                                if (worksheet.Cells[IdNumberPos + row].Value != null && IdNumberPos != null)
                                {
                                    var idnumber = worksheet.Cells[IdNumberPos + row].Value.ToString().Trim();
                                    clientDTO.IdNumber = idnumber;
                                    clientDTO.IsExists = await ClientExists(idnumber);
                                }
                                else
                                    break;

                                if (worksheet.Cells[LastNamePos + row].Value != null && LastNamePos != null)
                                    clientDTO.LastName = SentenceCase.ToProperCase(worksheet.Cells[LastNamePos + row].Value.ToString().Trim());
                                else
                                    clientDTO.LastName = null;

                                if (worksheet.Cells[FirstNamePos + row].Value != null && FirstNamePos != null)
                                    clientDTO.FirstName = SentenceCase.ToProperCase(worksheet.Cells[FirstNamePos + row].Value.ToString().Trim());
                                else
                                    clientDTO.FirstName = null;

                                DateTime dt = DateTime.ParseExact(nullDate, dateFormat, CultureInfo.CurrentCulture);

                                if (worksheet.Cells[BirthDatePos + row].Value != null && BirthDatePos != null)
                                {
                                    var birthdate = worksheet.Cells[BirthDatePos + row].Value.ToString().Trim();

                                    if (Double.TryParse(birthdate, out double doublevalue))
                                        dt = DateTime.FromOADate(doublevalue);
                                    else if (DateTime.TryParse(birthdate, out DateTime datevalue))
                                        dt = Convert.ToDateTime(datevalue, CultureInfo.CurrentCulture);
                                }
                                clientDTO.BirthDate = dt;

                                if (worksheet.Cells[GenderPos + row].Value != null && GenderPos != null)
                                {
                                    var gender = worksheet.Cells[GenderPos + row].Value.ToString().Trim();
                                    clientDTO.GenderId = (gender.ToLower(culture) == "m" || gender.ToLower(culture) == "male") ? Guid.Parse(Constants.Male) : Guid.Parse(Constants.Female);
                                }
                                else
                                    clientDTO.GenderId = Guid.Parse(Constants.Male);

                                if (worksheet.Cells[MaritalStatusPos + row].Value != null && MaritalStatusPos != null)
                                {
                                    var maritalStatus = worksheet.Cells[MaritalStatusPos + row].Value.ToString().Trim();
                                    clientDTO.MaritalStatusId = (maritalStatus != null) ? await GetMaritalStatusId(maritalStatus) :
                                                                                    Guid.Parse(Constants.MaritalStatusId);
                                }
                                else
                                    clientDTO.MaritalStatusId = Guid.Parse(Constants.MaritalStatusId);

                                if (worksheet.Cells[OccupationPos + row].Value != null && OccupationPos != null)
                                {
                                    var occupation = worksheet.Cells[OccupationPos + row].Value.ToString().Trim();
                                    clientDTO.OccupationId = (occupation != null) ? await GetOccupationId(occupation).ConfigureAwait(true) :
                                                                                    Guid.Parse(Constants.OccupationId);
                                }
                                else
                                    clientDTO.OccupationId = Guid.Parse(Constants.OccupationId);

                                if (worksheet.Cells[TitlePos + row].Value != null && TitlePos != null)
                                {
                                    var title = worksheet.Cells[TitlePos + row].Value.ToString().Trim();
                                    clientDTO.TitleId = (title != null) ? await GetTitleId(title).ConfigureAwait(true) :
                                                                        Guid.Parse(Constants.TitleId);
                                }
                                else
                                    clientDTO.TitleId = Guid.Parse(Constants.TitleId);

                                if (worksheet.Cells[CountryPos + row].Value != null && CountryPos != null)
                                {
                                    var land = worksheet.Cells[CountryPos + row].Value.ToString().Trim();
                                    clientDTO.CountryId = (land != null) ? await GetCountryId(land).ConfigureAwait(true) :
                                                                            Guid.Parse(Constants.CountryId);
                                }
                                else
                                    clientDTO.CountryId = Guid.Parse(Constants.CountryId);

                                if (worksheet.Cells[EmailPos + row].Value != null && EmailPos != null)
                                    clientDTO.Email = worksheet.Cells[EmailPos + row].Value.ToString().Trim();
                                else
                                    clientDTO.Email = Constants.Email;

                                if (worksheet.Cells[MobilePos + row].Value != null && MobilePos != null)
                                    clientDTO.Mobile = worksheet.Cells[MobilePos + row].Value.ToString().Trim();
                                else
                                    clientDTO.Mobile = null;

                                if (worksheet.Cells[PhonePos + row].Value != null && PhonePos != null)
                                    clientDTO.Phone = worksheet.Cells[PhonePos + row].Value.ToString().Trim();
                                else
                                    clientDTO.Phone = null;

                                clientDTO.PortfolioId = resource.PortfolioId;
                                clientDTOs.Add(clientDTO);
                            }
                        }
                        else if (resource.FileType == FileType.CSV)
                        {
                            if (resource.Delimiter == null)
                            {
                                resource.Delimiter = "";
                            }

                            char[] lineDelimiter = resource.Delimiter.ToCharArray(); // Get Delimiter

                            using StreamReader sr = new(resource.UpLoadFile.OpenReadStream());
                            string line = string.Empty;

                            //  Skip rows to where valid data row starts
                            if (resource.StartRow > 0)
                                for (int i = 0; i < resource.StartRow - 1; i++)
                                    sr.ReadLine();

                            while ((line = sr.ReadLine()) != null)
                            {
                                ClientBulk clientDTO = new();

                                string[] cols = line.Split(lineDelimiter);

                                if (IdNumberPos == null)
                                {
                                    break;
                                }
                                else
                                {
                                    if (cols[int.Parse(IdNumberPos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                    {
                                        var idnumber = cols[int.Parse(IdNumberPos, numberStyle, CultureInfo.CurrentCulture)];
                                        clientDTO.IdNumber = idnumber;
                                        clientDTO.IsExists = await ClientExists(idnumber).ConfigureAwait(true);
                                    }
                                    else
                                        break;
                                }

                                if (LastNamePos == null)
                                {
                                    clientDTO.LastName = null;
                                }
                                else
                                {
                                    if (cols[int.Parse(LastNamePos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                        clientDTO.LastName = SentenceCase.ToProperCase(cols[int.Parse(LastNamePos, numberStyle, CultureInfo.CurrentCulture)]);
                                    else
                                        clientDTO.LastName = null;
                                }

                                if (FirstNamePos == null)
                                {
                                    clientDTO.FirstName = null;
                                }
                                else
                                {
                                    if (cols[int.Parse(FirstNamePos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                        clientDTO.FirstName = SentenceCase.ToProperCase(cols[int.Parse(FirstNamePos, numberStyle, CultureInfo.CurrentCulture)]);
                                    else
                                        clientDTO.FirstName = null;
                                }

                                if (BirthDatePos == null)
                                {
                                    clientDTO.BirthDate = DateTime.ParseExact(nullDate, dateFormat, CultureInfo.CurrentCulture);
                                }
                                else
                                {
                                    if (cols[int.Parse(BirthDatePos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                    {
                                        var birthdate = cols[int.Parse(BirthDatePos, numberStyle, CultureInfo.CurrentCulture)];
                                        DateTime dt = Convert.ToDateTime(birthdate, CultureInfo.CurrentCulture);
                                        clientDTO.BirthDate = dt;
                                    }
                                    else
                                        clientDTO.BirthDate = DateTime.ParseExact(nullDate, dateFormat, CultureInfo.CurrentCulture);
                                }

                                if (GenderPos == null)
                                {
                                    clientDTO.GenderId = Guid.Parse(Constants.Male);
                                }
                                else
                                {
                                    if (cols[int.Parse(GenderPos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                    {
                                        var gender = cols[int.Parse(GenderPos, numberStyle, CultureInfo.CurrentCulture)];
                                        clientDTO.GenderId = (gender.ToLower(culture) == "m" || gender.ToLower(culture) == "male") ? Guid.Parse(Constants.Male) : Guid.Parse(Constants.Female);
                                    }
                                    else
                                        clientDTO.GenderId = Guid.Parse(Constants.Male);
                                }

                                if (OccupationPos == null)
                                {
                                    clientDTO.OccupationId = Guid.Parse(Constants.OccupationId);
                                }
                                else
                                {
                                    if (cols[int.Parse(OccupationPos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                    {
                                        var occupation = cols[int.Parse(OccupationPos, numberStyle, CultureInfo.CurrentCulture)];
                                        clientDTO.OccupationId = (occupation != null) ? await GetOccupationId(occupation).ConfigureAwait(true) :
                                                                                       Guid.Parse(Constants.TitleId);
                                    }
                                    else
                                        clientDTO.OccupationId = Guid.Parse(Constants.OccupationId);
                                }

                                if (TitlePos == null)
                                {
                                    clientDTO.TitleId = Guid.Parse(Constants.TitleId);
                                }
                                else
                                {
                                    if (cols[int.Parse(TitlePos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                    {
                                        var title = cols[int.Parse(TitlePos, numberStyle, CultureInfo.CurrentCulture)];
                                        clientDTO.TitleId = (title != null) ? await GetTitleId(title).ConfigureAwait(true) :
                                                                            Guid.Parse(Constants.TitleId);
                                    }
                                    else
                                        clientDTO.TitleId = Guid.Parse(Constants.TitleId);
                                }

                                if (CountryPos == null)
                                {
                                    clientDTO.CountryId = Guid.Parse(Constants.CountryId);
                                }
                                else
                                {
                                    if (cols[int.Parse(CountryPos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                    {
                                        var country = cols[int.Parse(CountryPos, numberStyle, CultureInfo.CurrentCulture)];
                                        clientDTO.CountryId = (country != null) ? await GetCountryId(country) :
                                                                                Guid.Parse(Constants.CountryId);
                                    }
                                    else
                                        clientDTO.CountryId = Guid.Parse(Constants.CountryId);
                                }

                                if (MaritalStatusPos == null)
                                {
                                    clientDTO.MaritalStatusId = Guid.Parse(Constants.MaritalStatusId);
                                }
                                else
                                {
                                    if (cols[int.Parse(MaritalStatusPos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                    {
                                        var maritalStatus = cols[int.Parse(MaritalStatusPos, numberStyle, CultureInfo.CurrentCulture)];
                                        clientDTO.CountryId = (maritalStatus != null) ? await GetMaritalStatusId(maritalStatus) :
                                                                                Guid.Parse(Constants.MaritalStatusId);
                                    }
                                    else
                                        clientDTO.MaritalStatusId = Guid.Parse(Constants.MaritalStatusId);
                                }

                                if (EmailPos == null)
                                {
                                    clientDTO.Email = Constants.Email; ;
                                }
                                else
                                {
                                    if (cols[int.Parse(EmailPos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                        clientDTO.Email = cols[int.Parse(EmailPos, numberStyle, CultureInfo.CurrentCulture)];
                                    else
                                        clientDTO.Email = Constants.Email; ;
                                }

                                if (MobilePos == null)
                                {
                                    clientDTO.Mobile = null;
                                }
                                else
                                {
                                    if (cols[int.Parse(MobilePos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                        clientDTO.Mobile = cols[int.Parse(MobilePos, numberStyle, CultureInfo.CurrentCulture)];
                                    else
                                        clientDTO.Mobile = null;
                                }

                                if (PhonePos == null)
                                {
                                    clientDTO.Phone = null;
                                }
                                else
                                {
                                    if (cols[int.Parse(PhonePos, numberStyle, CultureInfo.CurrentCulture)] != null)
                                        clientDTO.Phone = cols[int.Parse(PhonePos, numberStyle, CultureInfo.CurrentCulture)];
                                    else
                                        clientDTO.Phone = null;
                                }

                                clientDTO.PortfolioId = resource.PortfolioId;
                                clientDTOs.Add(clientDTO);
                            }
                        }
                        else if (resource.FileType == FileType.FixedLengthDelimited)
                        {
                            int FirstNameLen = 0;
                            int LastNameLen = 0;
                            int IDNumberLen = 0;
                            int BirthDateLen = 0;
                            int TitleLen = 0;
                            int GenderLen = 0;
                            int OccupationLen = 0;
                            int CountryLen = 0;
                            int MaritalStatusLen = 0;
                            int EmailLen = 0;
                            int MobileLen = 0;
                            int PhoneLen = 0;

                            foreach (var row in fileTemplateRecords)
                            {
                                switch (row.FieldName)
                                {
                                    case "IDNumber":
                                        IDNumberLen = row.ColumnLength;
                                        break;
                                    case "FirstName":
                                        FirstNameLen = row.ColumnLength;
                                        break;
                                    case "LastName":
                                        LastNameLen = row.ColumnLength;
                                        break;
                                    case "BirthDate":
                                        BirthDateLen = row.ColumnLength;
                                        break;
                                    case "Title":
                                        TitleLen = row.ColumnLength;
                                        break;
                                    case "Gender":
                                        GenderLen = row.ColumnLength;
                                        break;
                                    case "Occupation":
                                        OccupationLen = row.ColumnLength;
                                        break;
                                    case "Country":
                                        CountryLen = row.ColumnLength;
                                        break;
                                    case "MaritalStatus":
                                        MaritalStatusLen = row.ColumnLength;
                                        break;
                                    case "Email":
                                        EmailLen = row.ColumnLength;
                                        break;
                                    case "Mobile":
                                        MobileLen = row.ColumnLength;
                                        break;
                                    case "Phone":
                                        PhoneLen = row.ColumnLength;
                                        break;
                                    case "default":
                                        break;
                                }
                            }

                            using StreamReader sr = new(resource.UpLoadFile.OpenReadStream());
                            string line = string.Empty;

                            //  Skip rows to where valid data row starts
                            if (resource.StartRow > 0)
                                for (int i = 0; i < resource.StartRow - 1; i++)
                                    sr.ReadLine();

                            while ((line = sr.ReadLine()) != null)
                            {
                                ClientBulk clientDTO = new();

                                if (line.Substring(int.Parse(IdNumberPos, numberStyle, CultureInfo.CurrentCulture), IDNumberLen) != null && IdNumberPos != null)
                                {
                                    var idnumber = line.Substring(int.Parse(IdNumberPos, numberStyle, CultureInfo.CurrentCulture), IDNumberLen);
                                    clientDTO.IdNumber = idnumber;
                                    clientDTO.IsExists = await ClientExists(idnumber);
                                }

                                else
                                    break;

                                if (line.Substring(int.Parse(LastNamePos, numberStyle, CultureInfo.CurrentCulture), LastNameLen) != null && LastNamePos != null)
                                    clientDTO.LastName = SentenceCase.ToProperCase(line.Substring(int.Parse(LastNamePos, numberStyle, CultureInfo.CurrentCulture), LastNameLen));
                                else
                                    clientDTO.LastName = null;

                                if (line.Substring(int.Parse(FirstNamePos, numberStyle, CultureInfo.CurrentCulture), FirstNameLen) != null && FirstNamePos != null)
                                    clientDTO.FirstName = SentenceCase.ToProperCase(line.Substring(int.Parse(FirstNamePos, numberStyle, CultureInfo.CurrentCulture), FirstNameLen));
                                else
                                    clientDTO.FirstName = null;

                                if (line.Substring(int.Parse(BirthDatePos, numberStyle, CultureInfo.CurrentCulture), BirthDateLen) != null && BirthDatePos != null)
                                {
                                    var birthdate = line.Substring(int.Parse(BirthDatePos, numberStyle, CultureInfo.CurrentCulture), BirthDateLen);
                                    DateTime dt = Convert.ToDateTime(birthdate, CultureInfo.CurrentCulture);
                                    clientDTO.BirthDate = dt;
                                }
                                else
                                    clientDTO.BirthDate = DateTime.ParseExact(nullDate, dateFormat, CultureInfo.CurrentCulture);

                                if (line.Substring(int.Parse(GenderPos, numberStyle, CultureInfo.CurrentCulture), GenderLen) != null && GenderPos != null)
                                {
                                    var gender = line.Substring(int.Parse(GenderPos, numberStyle, CultureInfo.CurrentCulture), GenderLen);
                                    clientDTO.GenderId = (gender.ToLower(culture) == "m" || gender.ToLower(culture) == "male") ? Guid.Parse(Constants.Male) : Guid.Parse(Constants.Female);
                                }
                                else
                                    clientDTO.GenderId = Guid.Parse(Constants.Male);

                                if (line.Substring(int.Parse(OccupationPos, numberStyle, CultureInfo.CurrentCulture), OccupationLen) != null && OccupationPos != null)
                                {
                                    var occupation = line.Substring(int.Parse(OccupationPos, numberStyle, CultureInfo.CurrentCulture), OccupationLen);
                                    clientDTO.OccupationId = (occupation != null) ? await GetOccupationId(occupation).ConfigureAwait(true) :
                                                                                    Guid.Parse(Constants.OccupationId);
                                }
                                else
                                    clientDTO.OccupationId = Guid.Parse(Constants.OccupationId);

                                if (line.Substring(int.Parse(TitlePos, numberStyle, CultureInfo.CurrentCulture), TitleLen) != null && TitlePos != null)
                                {
                                    var title = line.Substring(int.Parse(TitlePos, numberStyle, CultureInfo.CurrentCulture), TitleLen);
                                    clientDTO.TitleId = (title != null) ? await GetTitleId(title).ConfigureAwait(true) :
                                                                        Guid.Parse(Constants.TitleId);
                                }
                                else
                                    clientDTO.TitleId = Guid.Parse(Constants.TitleId);

                                if (line.Substring(int.Parse(CountryPos, numberStyle, CultureInfo.CurrentCulture), CountryLen) != null && CountryPos != null)
                                {
                                    var country = line.Substring(int.Parse(CountryPos, numberStyle, CultureInfo.CurrentCulture), CountryLen);
                                    clientDTO.CountryId = (country != null) ? await GetCountryId(country).ConfigureAwait(true) :
                                                                            Guid.Parse(Constants.CountryId);
                                }
                                else
                                    clientDTO.CountryId = Guid.Parse(Constants.CountryId);

                                if (line.Substring(int.Parse(EmailPos, numberStyle, CultureInfo.CurrentCulture), EmailLen) != null && EmailPos != null)
                                    clientDTO.Email = line.Substring(int.Parse(EmailPos, numberStyle, CultureInfo.CurrentCulture), EmailLen);
                                else
                                    clientDTO.Email = null;

                                if (line.Substring(int.Parse(MaritalStatusPos, numberStyle, CultureInfo.CurrentCulture), MaritalStatusLen) != null && MaritalStatusPos != null)
                                {
                                    var maritalStatus = line.Substring(int.Parse(MaritalStatusPos, numberStyle, CultureInfo.CurrentCulture), MaritalStatusLen);
                                    clientDTO.CountryId = (maritalStatus != null) ? await GetMaritalStatusId(maritalStatus).ConfigureAwait(true) :
                                                                            Guid.Parse(Constants.MaritalStatusId);
                                }
                                else
                                    clientDTO.MaritalStatusId = Guid.Parse(Constants.MaritalStatusId);

                                if (line.Substring(int.Parse(MobilePos, numberStyle, CultureInfo.CurrentCulture), MobileLen) != null && MobilePos != null)
                                    clientDTO.Mobile = line.Substring(int.Parse(MobilePos, numberStyle, CultureInfo.CurrentCulture), MobileLen);
                                else
                                    clientDTO.Mobile = null;

                                if (line.Substring(int.Parse(PhonePos, numberStyle, CultureInfo.CurrentCulture), PhoneLen) != null && PhonePos != null)
                                    clientDTO.Phone = line.Substring(int.Parse(PhonePos, numberStyle, CultureInfo.CurrentCulture), PhoneLen);
                                else
                                    clientDTO.Phone = null;

                                clientDTO.PortfolioId = resource.PortfolioId;
                                clientDTOs.Add(clientDTO);
                            }
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        return ex.HResult;
                    }

                    if (clientDTOs.Count > 0)
                    {
                        if (clientDTOs.GroupBy(n => n.IdNumber).Any(c => c.Count() > 1))
                        {
                            //  Return view with error message
                            ms.Flush();

                            //  Find a way to return custom error for duplicatte ID Numbers
                            return 909;

                            //ModelState.AddModelError(string.Empty, $"Input data contains duplicate ID Numbers.");
                            //return await Task.Run(() => View(model)).ConfigureAwait(true);
                        }
                        else
                        {
                            await _unitOfWork.ClientBulks.AddRangeAsync(clientDTOs);
                        }
                    }
                    else
                    {
                        //  Capture

                    }
                    ms.Flush();
                }
                return await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> AddBulkAsync(List<ClientBulkSaveResource> resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            try
            {
                var clientBulks = _mapper.Map<IEnumerable<ClientBulkSaveResource>, IEnumerable<ClientBulk>>(resources);
                await _unitOfWork.ClientBulks.AddRangeAsync(clientBulks);
                return await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteBulkAsync(List<ClientBulkResource> resources)
        {
            var clientBulks = _mapper.Map<IEnumerable<ClientBulkResource>, IEnumerable<ClientBulk>>(resources);
            await _unitOfWork.ClientBulks.DeleteRangeAsync(clientBulks);
            return await _unitOfWork.SaveAsync();
        }

        private async Task<Guid> GetCountryId(string name)
        {
            var title = await _unitOfWork.Titles.GetFirstOrDefaultAsync(
                                                r => r.Name == name);
            return title.Id;
        }

        private async Task<Guid> GetMaritalStatusId(string name)
        {
            var maritalStatus = await _unitOfWork.MaritalStatuses.GetFirstOrDefaultAsync(
                                                r => r.Name == name);
            return maritalStatus.Id;
        }

        private async Task<Guid> GetOccupationId(string name)
        {
            var occupation = await _unitOfWork.Occupations.GetFirstOrDefaultAsync(
                                                r => r.Name == name);
            return occupation.Id;
        }

        private async Task<Guid> GetTitleId(string name)
        {
            var country = await _unitOfWork.Countries.GetFirstOrDefaultAsync(
                                                r => r.Name == name);
            return country.Id;
        }

        public async Task<bool> ClientExists(string IdNumber)
        {
            var client = await _unitOfWork.Clients.GetFirstOrDefaultAsync(e => e.IdNumber == IdNumber);
            return (client != null);
        }

        public async Task<IEnumerable<ClientBulkResource>> GetBulkByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.ClientBulks.GetAllAsync(
                                                        e => e.PortfolioId == portfolioId,
                                                        e => e.OrderBy(r => r.LastName));

            var resources = _mapper.Map<IEnumerable<ClientBulk>, IEnumerable<ClientBulkResource>>(result);
            return resources;
        }
    }
}