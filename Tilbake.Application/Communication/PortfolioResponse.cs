using Tilbake.Core.Models;

namespace Tilbake.Application.Communication
{
    public class PortfolioResponse : BaseResponse<Portfolio>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Portfolio">Saved Portfolio.</param>
        /// <returns>Response.</returns>
        public PortfolioResponse(Portfolio Portfolio) : base(Portfolio)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PortfolioResponse(string message) : base(message)
        { 

        }        
    }
}