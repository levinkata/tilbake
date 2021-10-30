using System;
using System.Linq.Expressions;
using Tilbake.Core.Models;

namespace Tilbake.Application.Projections
{
    public class BankProjection
    {
        public static Expression<Func<Bank, dynamic>> BankWithoutBranches
        {
            get
            {
                return m => new
                {
                    m.Name
                };
            }
        }

        public static Expression<Func<Bank, dynamic>> BankWithBranches
        {
            get
            {
                return m => new
                {
                    m.Name,
                    m.BankBranches
                };
            }
        }          
    }
}