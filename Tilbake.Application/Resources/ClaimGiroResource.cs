using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Enums;

namespace Tilbake.Application.Resources
{
    public class ClaimGiroResource
    {
        public Guid PortfolioId { get; set; }
        public Guid FileTemplateId { get; set; }
        public string TableName { get; set; }
        public FileType FileType { get; set; }

        public Guid ClaimNumberId { get; set; }

        [Display(Name = "ClaimNumber")]
        public string ClaimNumberFieldLabel { get; set; }
        public string ClaimNumberPosition { get; set; }
        public int ClaimNumberColumnLength { get; set; }
        public bool ClaimNumberIsKey { get; set; }
        public Guid ReportDateId { get; set; }

        [Display(Name = "Report Date")]
        public string ReportDateFieldLabel { get; set; }
        public string ReportDatePosition { get; set; }
        public int ReportDateColumnLength { get; set; }
        public bool ReportDateIsKey { get; set; }
        public Guid IncidentDateId { get; set; }

        [Display(Name = "Incident Date")]
        public string IncidentDateFieldLabel { get; set; }
        public string IncidentDatePosition { get; set; }
        public int IncidentDateColumnLength { get; set; }
        public bool IncidentDateIsKey { get; set; }
        public Guid RegisterDateId { get; set; }

        [Display(Name = "Register Date")]
        public string RegisterDateFieldLabel { get; set; }
        public string RegisterDatePosition { get; set; }
        public int RegisterDateColumnLength { get; set; }
        public bool RegisterDateIsKey { get; set; }

        public Guid ReserveInsuredId { get; set; }

        [Display(Name = "Reserve Insured")]
        public string ReserveInsuredFieldLabel { get; set; }
        public string ReserveInsuredPosition { get; set; }
        public int ReserveInsuredColumnLength { get; set; }
        public bool ReserveInsuredIsKey { get; set; }

        public Guid ReserveThirdPartyId { get; set; }

        [Display(Name = "Reserve ThirdParty")]
        public string ReserveThirdPartyFieldLabel { get; set; }
        public string ReserveThirdPartyPosition { get; set; }
        public int ReserveThirdPartyColumnLength { get; set; }
        public bool ReserveThirdPartyIsKey { get; set; }

        public Guid ExcessId { get; set; }

        [Display(Name = "Excess")]
        public string ExcessFieldLabel { get; set; }
        public string ExcessPosition { get; set; }
        public int ExcessColumnLength { get; set; }
        public bool ExcessIsKey { get; set; }

        public Guid RecoverFromThirdPartyId { get; set; }

        [Display(Name = "Recover From ThirdParty")]
        public string RecoverFromThirdPartyFieldLabel { get; set; }
        public string RecoverFromThirdPartyPosition { get; set; }
        public int RecoverFromThirdPartyColumnLength { get; set; }
        public bool RecoverFromThirdPartyIsKey { get; set; }

        //  Descriptions
        public string Portfolio { get; set; }
        public string FileTemplate { get; set; }
    }
}
