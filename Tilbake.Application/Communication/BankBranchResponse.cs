using Tilbake.Domain.Models;

namespace Tilbake.Application.Communication
{
    public class BankBranchResponse : BaseResponse<BankBranch>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="bankBranch">Saved bankBranch.</param>
        /// <returns>Response.</returns>
        public BankBranchResponse(BankBranch bankBranch) : base(bankBranch)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BankBranchResponse(string message) : base(message)
        { 

        }        
    }
}