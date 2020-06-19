
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tilbake.Domain.Enums;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Data.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new TilbakeDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TilbakeDbContext>>());

            if (context.Portfolios.Any())
            {
                return;     //  DB has been seeded
            }
            
            string dateformat = "dd/MM/yyyy";
            // NumberStyles style = NumberStyles.AllowDecimalPoint;

            var portfolios = new List<Portfolio>
                {
                   new Portfolio { Name="Personal Lines",Description="Put some description about the purpose of the portfolio"},
                   new Portfolio { Name="Commercial Lines",Description="Put some description about the purpose of the portfolio"},
                   new Portfolio { Name="Bancassurance",Description="Put some description about the purpose of the portfolio"}
                };
            
            portfolios.ForEach(async s => await context.Portfolios.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var occupations = new List<Occupation>
                {
                   new Occupation { Name="Accountant"},
                   new Occupation { Name="Broker"},
                   new Occupation { Name="Civil Servant"},
                   new Occupation { Name="Counsellor"},
                   new Occupation { Name="Consultant"},
                   new Occupation { Name="Dentist"},
                   new Occupation { Name="Doctor"},
                   new Occupation { Name="Economist"},
                   new Occupation { Name="Engineer"},
                   new Occupation { Name="Health Worker"},
                   new Occupation { Name="Lawyer"},
                   new Occupation { Name="Officer"},
                   new Occupation { Name="Pharmacist"},
                   new Occupation { Name="Teacher"},
                   new Occupation { Name="Underwriter"}
                };

            occupations.ForEach(async s => await context.Occupations.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var lands = new List<Land>
                {
                    new Land { Name="Botswana"},
                    new Land { Name="Lesotho"},
                    new Land { Name="eSwatini"},
                    new Land { Name="Malawi"},
                    new Land { Name="Mozambique"},
                    new Land { Name="Namibia"},
                    new Land { Name="South Africa"},
                    new Land { Name="Zambia"},
                    new Land { Name="Zimbabwe"}
                };

            lands.ForEach(async s => await context.Lands.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var cities = new List<City>
                {
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Gaborone"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Francistown"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Lobatse"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Kanye"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Maun"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Phalapye"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Mahalapye"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Selebi Phikwe"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Nata"},
                   new City { LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,Name="Kasane"}
                };

            cities.ForEach(async s => await context.Cities.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var insurers = new List<Insurer>
                {
                   new Insurer { Name="Botswana Insurance Company" },
                   new Insurer { Name="Hollard Insurance Company" },
                   new Insurer { Name="Old Mutual Insurance Company" },
                   new Insurer { Name="Government Loan Insured Fund" },
                   new Insurer { Name="Regent Insurance Company" },
                   new Insurer { Name="Zurich Insurance Company" }
                };
            insurers.ForEach(async s => await context.Insurers.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var titles = new List<Title>
                {
                   new Title { Name="Advocate"},
                   new Title { Name="Dr"},
                   new Title { Name="Messrs"},
                   new Title { Name="Miss"},
                   new Title { Name="Mr"},
                   new Title { Name="Mrs"},
                   new Title { Name="Ms"},
                   new Title { Name="Prof"}
                };

            titles.ForEach(async s => await context.Titles.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();


            var klients = new List<Klient>
                {
                    new Klient { KlientType=KlientType.Individual.ToString(),TitleID=titles.SingleOrDefault(m => m.Name =="Mr").Id,KlientNumber=int.Parse("1",CultureInfo.CurrentCulture),Phone="3966700",
                             FirstName="Island",LastName="Molobe",BirthDate=DateTime.ParseExact("12/04/1968",dateformat,CultureInfo.CurrentCulture),Gender=Gender.Male.ToString(),IDNumber="718614601",Mobile="79999993",Fax="3959992",
                             OccupationID=occupations.SingleOrDefault(m => m.Name =="Civil Servant").ID,LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,
                             Carrier=Carrier.Email.ToString(),Email="molobe@gmail.com"},
                    new Klient { KlientType=KlientType.Individual.ToString(),TitleID=titles.SingleOrDefault(m => m.Name =="Mr").Id,KlientNumber=int.Parse("2",CultureInfo.CurrentCulture),Phone="3966701",
                             FirstName="Khumoetsile",LastName="Letsweletse",BirthDate=DateTime.ParseExact("25/12/1968",dateformat,CultureInfo.CurrentCulture),Gender=Gender.Male.ToString(),IDNumber="214412205",Mobile="79999992",Fax="3959991",
                             OccupationID=occupations.SingleOrDefault(m => m.Name =="Engineer").ID,LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,
                             Carrier=Carrier.Email.ToString(),Email="letsweletse@gmail.com"},
                    new Klient { KlientType=KlientType.Individual.ToString(),TitleID=titles.SingleOrDefault(m => m.Name =="Ms").Id,KlientNumber=int.Parse("3",CultureInfo.CurrentCulture),Phone="3966702",
                             FirstName="Rosemary",LastName="Rammei",BirthDate=DateTime.ParseExact("02/01/1972",dateformat,CultureInfo.CurrentCulture),Gender=Gender.Female.ToString(),IDNumber="108221609",Mobile="79999991",Fax="3959990",
                             OccupationID=occupations.SingleOrDefault(m => m.Name =="Teacher").ID,LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,
                             Carrier=Carrier.Email.ToString(),Email="rammei@gmail.com"},
                    new Klient { KlientType=KlientType.Individual.ToString(),TitleID=titles.SingleOrDefault(m => m.Name =="Mr").Id,KlientNumber=int.Parse("4",CultureInfo.CurrentCulture),Phone="3966703",
                             FirstName="Reuben",LastName="Erastus",BirthDate=DateTime.ParseExact("30/06/1953",dateformat,CultureInfo.CurrentCulture),Gender=Gender.Male.ToString(),IDNumber="848515605",Mobile="79999990",Fax="3959999",
                             OccupationID=occupations.SingleOrDefault(m => m.Name =="Health Worker").ID,LandID=lands.SingleOrDefault(m => m.Name =="Botswana").ID,
                            Carrier=Carrier.Email.ToString(),Email="ersatus@gmail.com"}
                };

            klients.ForEach(async s => await context.Klients.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var klientnumbergenerators = new List<KlientNumberGenerator>
            {
                new KlientNumberGenerator { KlientNumber=int.Parse("1",CultureInfo.CurrentCulture)},
                new KlientNumberGenerator { KlientNumber=int.Parse("2",CultureInfo.CurrentCulture)},
                new KlientNumberGenerator { KlientNumber=int.Parse("3",CultureInfo.CurrentCulture)},
                new KlientNumberGenerator { KlientNumber=int.Parse("4",CultureInfo.CurrentCulture)}
            };
            klientnumbergenerators.ForEach(async s => await context.KlientNumberGenerators.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var banks = new List<Bank>
                {
                   new Bank { Name="Absa Bank Botswana Limited" },
                   new Bank { Name="First National Bank Botswana Limited" },
                   new Bank { Name="Stanbic Bank Botswana Limited" },
                   new Bank { Name="Standard Chartered Bank Botswana Limited" }
                };

            banks.ForEach(async s => await context.Banks.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var bankbranches = new List<BankBranch>
                {
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Palapye",BIC="065067",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Tsabong",BIC="292167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Lobatse",BIC="281767",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Game City ",BIC="293567",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Palapye",BIC="283167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Maun",BIC="661967",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Broadhurst",BIC="281267",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Private Klients",BIC="283767",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Head Office",BIC="060467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Barclays House",BIC="290267",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Serowe Mahalapye Palapye",BIC="291467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Carbo centre",BIC="290767",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Selibe Phikwe",BIC="285067",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Kasane",BIC="292067",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Main Branch",BIC="281467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Corporate",BIC="282267",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Treasury",BIC="282167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Bofex",BIC="290667",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Ramotswa ",BIC="292767",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Gaborone Industrial",BIC="662367",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Gaborone Industrial",BIC="290367",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Gaborone Sun Prestige",BIC="293467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Kanye",BIC="281967",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Mogoditshane ",BIC="292967",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="CBD",BIC="065167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Airport Junction",BIC="662567",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Francistown",BIC="281867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Broadhurst",BIC="060367",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Blue Jacket",BIC="064867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Game City",BIC="662867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Francistown",BIC="661767",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Jwaneng",BIC="283067",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Industrial",BIC="061967",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Letlhakane",BIC="285567",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Mahalapye",BIC="282467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="customer Service",BIC="660167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Francistown",BIC="291767",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Gaborone Mall",BIC="282867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Orapa",BIC="290967",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Gaborone Mall",BIC="290167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Head Office",BIC="297867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Molepolole ",BIC="065467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Selebi Phikwe",BIC="661667",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Game City ",BIC="284567",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Jwaneng",BIC="660967",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Gaborone West",BIC="060167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Maun",BIC="064767",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Prestige Mall",BIC="294467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Selebi Phikwe",BIC="291667",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Lobatse",BIC="660867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Maun",BIC="282367",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Industrial",BIC="281667",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Orapa",BIC="661867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Moshupa",BIC="292867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Hemamo Centre",BIC="662767",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Wesbank",BIC="281567",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Phakalane ",BIC="290467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Molepolole",BIC="285667",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Airport Junction",BIC="288267",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Jwaneng ",BIC="291067",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Francistown",BIC="064067",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Head Office",BIC="282067",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Palapye",BIC="661567",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Stannic",BIC="060567",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Ghantsi",BIC="291167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Gaborone Savings",BIC="296467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Serowe",BIC="285367",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Tlokweng",BIC="292667",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="Riverwalk Plaza",BIC="285267",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Broadhurst",BIC="662467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Maun",BIC="291967",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Gaborone Mall",BIC="662167",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Fairground",BIC="064967",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Standard House",BIC="662267",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Merafhe",BIC="290567",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "First National Bank Botswana Limited").ID,Name="FNB Private Clients",BIC="285467",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Absa Bank Botswana Limited").ID,Name="Lobatse",BIC="290867",SwiftCode=""},
                    new BankBranch {BankID=banks.SingleOrDefault(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Mahalapye",BIC="661367",SwiftCode=""},
                };
            bankbranches.ForEach(async s => await context.BankBranches.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var documentcategories = new List<DocumentCategory>
                {
                   new DocumentCategory { Name="Drivers' Licence"},
                   new DocumentCategory { Name="Registration Book"},
                   new DocumentCategory { Name="ID Document"},
                   new DocumentCategory { Name="Quotation"},
                   new DocumentCategory { Name="Police Report"}
                };
            documentcategories.ForEach(async s => await context.DocumentCategories.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var bodytypes = new List<BodyType>
                 {
                   new BodyType { Name="Convertible"},
                   new BodyType { Name="Coupe"},
                   new BodyType { Name="Crossover"},
                   new BodyType { Name="Electric"},
                   new BodyType { Name="Hatchback"},
                   new BodyType { Name="Hybrid"},
                   new BodyType { Name="PickUp Truck"},
                   new BodyType { Name="Sedan"},
                   new BodyType { Name="Sport"},
                   new BodyType { Name="SUV"},
                   new BodyType { Name="Van"},
                   new BodyType { Name="Wagon"}
                 };
            bodytypes.ForEach(async s => await context.BodyTypes.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var motormakes = new List<MotorMake>
                {
                    new MotorMake { Name="Acura"},
                    new MotorMake { Name="Aston Martin"},
                    new MotorMake { Name="Audi"},
                    new MotorMake { Name="BMW"},
                    new MotorMake { Name="Buick"},
                    new MotorMake { Name="Cadillac"},
                    new MotorMake { Name="Chevrolet"},
                    new MotorMake { Name="Chrysler"},
                    new MotorMake { Name="Dodge"},
                    new MotorMake { Name="Ferarri"},
                    new MotorMake { Name="Ford"},
                    new MotorMake { Name="GMC"},
                    new MotorMake { Name="Honda"},
                    new MotorMake { Name="Hummer"},
                    new MotorMake { Name="Hyundai"},
                    new MotorMake { Name="Infiniti"},
                    new MotorMake { Name="Isuzu"},
                    new MotorMake { Name="Jaguar"},
                    new MotorMake { Name="Jeep"},
                    new MotorMake { Name="Kia"},
                    new MotorMake { Name="Land Rover"},
                    new MotorMake { Name="Lexus"},
                    new MotorMake { Name="Lincoln"},
                    new MotorMake { Name="Lotus"},
                    new MotorMake { Name="Maserati"},
                    new MotorMake { Name="Mazda"},
                    new MotorMake { Name="Mercedes-Benz"},
                    new MotorMake { Name="Mercury"},
                    new MotorMake { Name="MINI"},
                    new MotorMake { Name="Mitsubishi"},
                    new MotorMake { Name="Nissan"},
                    new MotorMake { Name="Pontaic"},
                    new MotorMake { Name="Porsche"},
                    new MotorMake { Name="Rolls-Royce"},
                    new MotorMake { Name="Saab"},
                    new MotorMake { Name="Saturn"},
                    new MotorMake { Name="Scion"},
                    new MotorMake { Name="Smart"},
                    new MotorMake { Name="Subaru"},
                    new MotorMake { Name="Suzuki"},
                    new MotorMake { Name="Toyota"},
                    new MotorMake { Name="Volkswagon"},
                    new MotorMake { Name="Volvo"}
                };
            motormakes.ForEach(async s => await context.MotorMakes.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var motormodels = new List<MotorModel>
                {
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Acura").ID,Name="MDX"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Acura").ID,Name="RDX"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Acura").ID,Name="RL"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Acura").ID,Name="TL"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Acura").ID,Name="TSX"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Aston Martin").ID,Name="DB9"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="A3"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="A4"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="A5"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="A6"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="A8"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="Q7"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="R8"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="RS 4"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="S4"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="S5"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="S6"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="S8"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Audi").ID,Name="TT"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="128"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="135"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="328"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="335"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="528"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="535"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="550"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="650"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="750"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="760"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="Alpina B7"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="M3"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="M5"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="M6"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="X3"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="X5"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="X6"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="Z4"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="BMW").ID,Name="Z4 M"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Buick").ID,Name="Enclave"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Buick").ID,Name="LaCrosse"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Buick").ID,Name="Lucerne"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Cadillac").ID,Name="CTS"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Cadillac").ID,Name="DTS"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Cadillac").ID,Name="Escalade"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Cadillac").ID,Name="Escalade ESV"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Cadillac").ID,Name="Escalade EXT"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Cadillac").ID,Name="SRX"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Cadillac").ID,Name="STS"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Cadillac").ID,Name="XLR"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Avalanche"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Aveo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Cobalt"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Colorado Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Colorado Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Colorado Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Corvette"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Equinox"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Express 1500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Express 1500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Express 2500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Express 2500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Express 3500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Express 3500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="HHR"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Impala"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Malibu"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Malibu (Classic)"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 1500 Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 1500 Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 1500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 2500 HD Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 2500 HD Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 2500 HD Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 3500 HD Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 3500 HD Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Silverado 3500 HD Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Suburban 1500"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Suburban 2500"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Tahoe"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="TrailBlazer"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Traverse"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Uplander Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chevrolet").ID,Name="Uplander Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chrysler").ID,Name="10 68|300"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chrysler").ID,Name="Crossfire"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chrysler").ID,Name="Pacifica"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chrysler").ID,Name="PT Cruiser"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chrysler").ID,Name="Sebring"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chrysler").ID,Name="spen"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Chrysler").ID,Name="Town & Land"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Avenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Caliber"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Caravan Grand Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Caravan Grand Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Challenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Charger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Dakota Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Dakota Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Durango"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Journey"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Magnum"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Nitro"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 1500 Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 1500 Mega Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 1500 Quad Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 1500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 2500 Mega Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 2500 Quad Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 2500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 3500 Mega Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 3500 Quad Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Ram 3500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Sprinter 2500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Sprinter 2500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Sprinter 3500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Dodge").ID,Name="Viper"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ferarri").ID,Name="430 Scuderia"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ferarri").ID,Name="599 GTB Fiorano"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ferarri").ID,Name="612 Scaglietti"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ferarri").ID,Name="F430"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="E150 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="E150 Super Duty Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="E250 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="E350 Super Duty Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="E350 Super Duty Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Edge"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Escape"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Expedition"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Expedition EL"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Explorer"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Explorer Sport Trac"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F150 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F150 Super Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F150 SuperCrew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F250 Super Duty Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F250 Super Duty Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F250 Super Duty Super Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F350 Super Duty Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F350 Super Duty Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F350 Super Duty Super Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="F450 Super Duty Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Flex"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Focus"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Fusion"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Mustang"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Ranger Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Ranger Super Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Taurus"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Ford").ID,Name="Taurus X"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Acadia"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Canyon Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Canyon Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Canyon Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Envoy"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Savana 1500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Savana 1500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Savana 2500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Savana 2500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Savana 3500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Savana 3500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 1500 Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 1500 Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 1500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 2500 HD Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 2500 HD Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 2500 HD Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 3500 HD Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 3500 HD Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Sierra 3500 HD Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Yukon"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Yukon XL 1500"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="GMC").ID,Name="Yukon XL 2500"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="Accord"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="Civic"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="CR-V"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="Element"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="Fit"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="Odyssey"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="Pilot"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="Ridgeline"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Honda").ID,Name="S2000"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hummer").ID,Name="H2"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hummer").ID,Name="H3"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Accent"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Azera"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Elantra"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Entourage"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Genesis"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Santa Fe"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Sonata"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Tiburon"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Tucson"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Hyundai").ID,Name="Veracruz"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="EX35"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="FX35"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="FX45"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="FX50"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="G35"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="G37"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="M35"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="M45"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Infiniti").ID,Name="QX56"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Isuzu").ID,Name="Ascender"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Isuzu").ID,Name="i-290 Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Isuzu").ID,Name="i-370 Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Isuzu").ID,Name="i-370 Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jaguar").ID,Name="S-Type"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jaguar").ID,Name="XF"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jaguar").ID,Name="XJ Series"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jaguar").ID,Name="XK Series"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jaguar").ID,Name="X-Type"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jeep").ID,Name="Commander"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jeep").ID,Name="Compass"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jeep").ID,Name="Grand Cherokee"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jeep").ID,Name="Liberty"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jeep").ID,Name="Patriot"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Jeep").ID,Name="Wrangler"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Amanti"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Borrego"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Optima"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Rio"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Rondo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Sedona"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Sorento"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Spectra"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Kia").ID,Name="Sportage"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Land Rover").ID,Name="LR2"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Land Rover").ID,Name="LR3"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Land Rover").ID,Name="Range Rover"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Land Rover").ID,Name="Range Rover Sport"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="ES 350"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="GS 350"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="GS 450h"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="GS 460"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="GX 470"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="IS 250"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="IS 350"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="IS F"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="LS 460"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="LS 600h"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="LX 570"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="RX 350"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="RX 400h"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lexus").ID,Name="SC 430"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lincoln").ID,Name="Mark LT"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lincoln").ID,Name="MKS"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lincoln").ID,Name="MKX"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lincoln").ID,Name="MKZ"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lincoln").ID,Name="Navigator"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lincoln").ID,Name="Navigator L"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lincoln").ID,Name="Town Car"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lotus").ID,Name="Elise"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Lotus").ID,Name="Exige S"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Maserati").ID,Name="GranTurismo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Maserati").ID,Name="Quattroporte"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="B-Series Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="B-Series Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="CX-7"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="CX-9"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="MAZDA3"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="MAZDA5"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="MAZDA6"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="Miata MX-5"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="RX-8"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mazda").ID,Name="Tribute"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="C-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="CL-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="CLK-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="CLS-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="E-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="G-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="GL-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="ML-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="R-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="S-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="SL-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="SLK-Class"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercedes-Benz").ID,Name="SLR McLaren"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercury").ID,Name="Grand Marquis"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercury").ID,Name="Mariner"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercury").ID,Name="Milan"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercury").ID,Name="Mountaineer"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mercury").ID,Name="Sable"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="MINI").ID,Name="Cooper"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mitsubishi").ID,Name="Eclipse"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mitsubishi").ID,Name="Endeavor"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mitsubishi").ID,Name="Galant"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mitsubishi").ID,Name="Lancer"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mitsubishi").ID,Name="Outlander"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mitsubishi").ID,Name="Raider Double Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Mitsubishi").ID,Name="Raider Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="350Z"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Altima"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Armada"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Frontier Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Frontier King Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="GT-R"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Maxima"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Murano"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Pathfinder"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Quest"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Rogue"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Sentra"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Titan Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Titan King Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Versa"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Nissan").ID,Name="Xterra"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Pontaic").ID,Name="G5"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Pontaic").ID,Name="G6"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Pontaic").ID,Name="G8"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Pontaic").ID,Name="Grand Prix"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Pontaic").ID,Name="Solstice"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Pontaic").ID,Name="Torrent"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Pontaic").ID,Name="Vibe"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Porsche").ID,Name="911"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Porsche").ID,Name="Boxster"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Porsche").ID,Name="Cayenne"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Porsche").ID,Name="Cayman"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Rolls-Royce").ID,Name="Phantom"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Saab").ID,Name="9-7X"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Saturn").ID,Name="Astra"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Saturn").ID,Name="Aura"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Saturn").ID,Name="Outlook"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Saturn").ID,Name="SKY"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Saturn").ID,Name="VUE"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Scion").ID,Name="tC"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Scion").ID,Name="xB"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Scion").ID,Name="xD"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Smart").ID,Name="fortwo"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Subaru").ID,Name="Forester"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Subaru").ID,Name="Impreza"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Subaru").ID,Name="Legacy"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Subaru").ID,Name="Outback"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Subaru").ID,Name="Tribeca"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Suzuki").ID,Name="Forenza"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Suzuki").ID,Name="Grand Vitara"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Suzuki").ID,Name="Reno"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Suzuki").ID,Name="SX4"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Suzuki").ID,Name="XL7"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="4Runner"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Avalon"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Camry"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Corolla"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="FJ Cruiser"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Highlander"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Land Cruiser"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Matrix"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Prius"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="RAV4"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Sequoia"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Sienna"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Solara"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Tacoma Access Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Tacoma Double Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Tacoma Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Tundra CrewMax"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Tundra Double Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Tundra Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Toyota").ID,Name="Yaris"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="CC"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="Eos"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="GLI"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="GTI"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="Jetta"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="New Beetle"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="Passat"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="R32"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="Rabbit"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="Routan"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="Tiguan"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="Touareg"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volkswagon").ID,Name="Touareg 2"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="C30"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="C70"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="S40"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="S60"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="S80"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="V50"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="V70"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="XC70"},
                    new MotorModel { MotorMakeID=motormakes.SingleOrDefault(m => m.Name =="Volvo").ID,Name="XC90"}
                };
            motormodels.ForEach(async s => await context.MotorModels.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var residencetypes = new List<ResidenceType>
                {
                   new ResidenceType { Name="Owner"},
                   new ResidenceType { Name="Tenant"}
                };

            residencetypes.ForEach(async s => await context.ResidenceTypes.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var rooftypes = new List<RoofType>
                {
                   new RoofType { Name="Asphalt"},
                   new RoofType { Name="Metal"},
                   new RoofType { Name="Thatch"},
                   new RoofType { Name="Bitumen"},
                   new RoofType { Name="Wood"}
                };

            rooftypes.ForEach(async s => await context.RoofTypes.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var walltypes = new List<WallType>
                {
                   new WallType { Name="Brick and Mortar"},
                   new WallType { Name="Metal"},
                   new WallType { Name="Prefabricated"},
                   new WallType { Name="Wood"}
                };

            walltypes.ForEach(async s => await context.WallTypes.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var quotestatuses = new List<QuoteStatus>
                {
                   new QuoteStatus { Name="Unsaved"},
                   new QuoteStatus { Name="Waiting for Client Response"},
                   new QuoteStatus { Name="Accepted via Broker"},
                   new QuoteStatus { Name="Accepted Electronically"},
                   new QuoteStatus { Name="In Progress"},
                   new QuoteStatus { Name="Client Rejected"}
                };

            quotestatuses.ForEach(async s => await context.QuoteStatuses.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var invoicestatuses = new List<InvoiceStatus>
                {
                   new InvoiceStatus { Name="Created"},
                   new InvoiceStatus { Name="Partially Paid"},
                   new InvoiceStatus { Name="Paid"},
                   new InvoiceStatus { Name="Over Paid"},
                   new InvoiceStatus { Name="Cancelled"},
                   new InvoiceStatus { Name="Sent to Client"},
                   new InvoiceStatus { Name="Written Off"}
                };

            invoicestatuses.ForEach(async s => await context.InvoiceStatuses.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var covertypes = new List<CoverType>
                {
                   new CoverType { Name="Additional Living Expense"},
                   new CoverType { Name="Third Party Fire and Theft"},
                   new CoverType { Name="Damage to Property"},
                   new CoverType { Name="Other Structures"},
                   new CoverType { Name="Comprehensive Personal Liability"},
                   new CoverType { Name="Comprehensive"},
                   new CoverType { Name="Third Party Only"},
                   new CoverType { Name="Personal Property"},
                   new CoverType { Name="Medical Expense"}
                };
            covertypes.ForEach(async s => await context.CoverTypes.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var incidents = new List<Incident>
                {
                   new Incident { Name="Single Vehicle"},
                   new Incident { Name="Hit By Third Party"},
                   new Incident { Name="Hit Animal"},
                   new Incident { Name="Fire"},
                   new Incident { Name="Theft"}
                };
            incidents.ForEach(async s => await context.Incidents.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var regions = new List<Region>
                {
                   new Region { Name="Greater Gaborone"},
                   new Region { Name="Metropolitan"},
                   new Region { Name="Landside"}
                };
            regions.ForEach(async s => await context.Regions.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();            

            var drivertypes = new List<DriverType>
                {
                   new DriverType { Name="Any Insured Driver"},
                   new DriverType { Name="Insured and any Family Member"},
                   new DriverType { Name="Insured Only"}
                };
            drivertypes.ForEach(async s => await context.DriverTypes.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();

            var motoruses = new List<MotorUse>
                {
                   new MotorUse { Name="Business"},
                   new MotorUse { Name="Private"},
                   new MotorUse { Name="Business and Private"}
                };
            motoruses.ForEach(async s => await context.MotorUses.AddAsync(s).ConfigureAwait(true));
            context.SaveChanges();            
        }
    }

}