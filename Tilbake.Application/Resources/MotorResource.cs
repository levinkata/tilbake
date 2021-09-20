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
        public Guid QuoteId { get; set; }
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

        [Display(Name = "Odometer Reading")]
        public int OdometerReading { get; set; }

        [Display(Name = "Colour")]
        public string Colour { get; set; }

        [Display(Name = "Motor Use")]
        public Guid MotorUseId { get; set; }

        [Display(Name = "Grey Import?")]
        public bool IsImport { get; set; }

        [Display(Name = "Security Fitting?")]
        public bool IsSecurityFitting { get; set; }

        [Display(Name = "Tracking Device?")]
        public bool IsTrackingDevice { get; set; }

        [Display(Name = "Immobiliser?")]
        public bool IsImmobiliser { get; set; }

        [Display(Name = " Factory Fitted Immobiliser?")]
        public bool IsImmobiliserFactoryFitted { get; set; }

        [Display(Name = "Alarm?")]
        public bool IsAlarm { get; set; }

        [Display(Name = "GearLock?")]
        public bool IsGearLock { get; set; }

        [Display(Name = "Days Out of Country")]
        public int DaysOutOfCountry { get; set; }

        [Display(Name = "Financial Interest")]
        public string FinancialInterest { get; set; }

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
        public SelectList DateRangeList { get; set; }
    }
}
