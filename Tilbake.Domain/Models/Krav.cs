using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Domain.Models
{
    public class Krav
    {
        [Display(Name = "Claim Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KravNumber { get; set; }
        public Guid PolitikkRiskID { get; set; }

        [Display(Name = "Claimant")]
        public string Claimant { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Report Date")]
        public DateTime ReportDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Incident Date")]
        public DateTime IncidentDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Register Date")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Insured Reserves"), Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal ReserveInsured { get; set; }

        [Display(Name = "Third Party Reserves"), Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal ReserveThirdParty { get; set; }

        [Display(Name = "Insured Revised Reserves"), Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal ReserveInsuredRevised { get; set; }

        [Display(Name = "Third Party Revised Reserves"), Column(TypeName = "decimal(15,2)")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal ReserveThirdPartyRevised { get; set; }

        [Display(Name = "Excess"), Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Excess { get; set; }

        [Display(Name = "Recover From Third Party")]
        public bool RecoverFromThirdParty { get; set; }

        [Display(Name = "Incident")]
        public Guid IncidentID { get; set; }

        [Display(Name = "Region")]
        public Guid RegionID { get; set; }

        [Display(Name = "Claim Status")]
        public Guid KravStatusID { get; set; }

        [Display(Name = "Incident Details"), StringLength(100)]
        public string IncidentDetail { get; set; }

        [Display(Name = "Comment"), StringLength(100)]
        public string Comment { get; set; }

        public virtual PolitikkRisk PolitikkRisk { get; private set; }
        public virtual Region Region { get; private set; }
        public virtual Incident Incident { get; private set; }
        public virtual KravStatus KravStatus { get; private set; }
    }
}
