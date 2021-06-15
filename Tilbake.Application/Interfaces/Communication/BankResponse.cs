using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces.Communication
{
    public class BankResponse : BaseResponse<Bank>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="bank">Saved bank.</param>
        /// <returns>Response.</returns>
        public BankResponse(Bank bank) : base(bank)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BankResponse(string message) : base(message)
        { 

        }        
    }
}