using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class PortfolioRatingMotorViewModel
    {
        public Guid PortfolioId { get; set; }
        public Guid InsurerId { get; set; }
        public string PortfolioName {  get; set; }

        public List<RatingMotor> RatingMotors { get; } = new List<RatingMotor>();

        //  SelectLists
        public SelectList InsurerList {  get; set; }
    }
}
