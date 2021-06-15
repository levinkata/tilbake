using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Projections;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Queries
{
    public static class BankQuery
    {
        public static async Task GetBanksWithoutBranchesAsync(this DbSet<Bank> bankDbSet)
        {
            await Task.Run(() => bankDbSet.Select(BankProjection.BankWithoutBranches)).ConfigureAwait(true);
        } 

        public static async Task GetBanksWithBranchesAsync(this DbSet<Bank> bankDbSet)
        {
            await Task.Run(() => bankDbSet.Select(BankProjection.BankWithBranches)).ConfigureAwait(true);
        } 

        public static async Task GetBankByIdWithoutBranchesAsync(this DbSet<Bank> bankDbSet, Guid Id)
        {
            await Task.Run(() => bankDbSet.Where(m => m.Id == Id).Select(BankProjection.BankWithoutBranches).FirstOrDefaultAsync()).ConfigureAwait(true);
        }         
    }
}