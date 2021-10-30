﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            AspnetUserPortfolios = new HashSet<AspnetUserPortfolio>();
            Eftfiles = new HashSet<Eftfile>();
            FileTemplates = new HashSet<FileTemplate>();
            PortfolioAdministrationFees = new HashSet<PortfolioAdministrationFee>();
            PortfolioClients = new HashSet<PortfolioClient>();
            PortfolioExcessBuyBacks = new HashSet<PortfolioExcessBuyBack>();
            PortfolioPolicyFees = new HashSet<PortfolioPolicyFee>();
            PortfolioRatingMotorDiscounts = new HashSet<PortfolioRatingMotorDiscount>();
            PortfolioRatingMotorExcesses = new HashSet<PortfolioRatingMotorExcess>();
            PortfolioRatingMotorPremia = new HashSet<PortfolioRatingMotorPremium>();
            PortfolioRatingMotors = new HashSet<PortfolioRatingMotor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsScheme { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<AspnetUserPortfolio> AspnetUserPortfolios { get; set; }
        public virtual ICollection<Eftfile> Eftfiles { get; set; }
        public virtual ICollection<FileTemplate> FileTemplates { get; set; }
        public virtual ICollection<PortfolioAdministrationFee> PortfolioAdministrationFees { get; set; }
        public virtual ICollection<PortfolioClient> PortfolioClients { get; set; }
        public virtual ICollection<PortfolioExcessBuyBack> PortfolioExcessBuyBacks { get; set; }
        public virtual ICollection<PortfolioPolicyFee> PortfolioPolicyFees { get; set; }
        public virtual ICollection<PortfolioRatingMotorDiscount> PortfolioRatingMotorDiscounts { get; set; }
        public virtual ICollection<PortfolioRatingMotorExcess> PortfolioRatingMotorExcesses { get; set; }
        public virtual ICollection<PortfolioRatingMotorPremium> PortfolioRatingMotorPremia { get; set; }
        public virtual ICollection<PortfolioRatingMotor> PortfolioRatingMotors { get; set; }
    }
}