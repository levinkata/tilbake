using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class MotorResource
    {
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public Guid QuoteItemId { get; set; }
        public Guid PolicyRiskId { get; set; }

        [Display(Name = "Registration Number")]
        public string RegNumber { get; set; }

        [Display(Name = "Body Type")]
        public Guid BodyTypeId { get; set; }

        [Display(Name = "Model")]
        public Guid MotorModelId { get; set; }

        [Display(Name = "Year")]
        public int RegYear { get; set; }

        [Display(Name = "Driver Type")]
        public Guid DriverTypeId { get; set; }

        [Display(Name = "Engine Number")]
        public string EngineNumber { get; set; }

        [Display(Name = "Chassis Number")]
        public string ChassisNumber { get; set; }

        [Display(Name = "Engine Capacity")]
        public string EngineCapacity { get; set; }

        [Display(Name = "Colour")]
        public string Colour { get; set; }

        [Display(Name = "Motor Use")]
        public Guid MotorUseId { get; set; }

        [Display(Name = "Grey Import?")]
        public bool GreyImport { get; set; }

        [Display(Name = "Security Fitting?")]
        public bool SecurityFitting { get; set; }

        [Display(Name = "Tracking Device?")]
        public bool TrackingDevice { get; set; }

        [Display(Name = "Immobiliser?")]
        public bool Immobiliser { get; set; }

        [Display(Name = "Alarm?")]
        public bool Alarm { get; set; }

        [Display(Name = "Make")]
        public Guid MotorMakeId { get; set; }
        
        //  Descriptions

        [Display(Name = "Body Type")]
        public string BodyType { get; set; }

        [Display(Name = "Driver Type")]
        public string DriverType { get; set; }

        [Display(Name = "Make")]
        public string MotorMake { get; set; }

        [Display(Name = "Model")]
        public string MotorModel { get; set; }

        //  SelectLists

        public SelectList BodyTypeList { get; set; }
        public SelectList DriverTypeList { get; set; }
        public SelectList MotorMakeList { get; set; }
        public SelectList MotorModelList { get; set; }
        public SelectList MotorUseList { get; set; }
    }
}
