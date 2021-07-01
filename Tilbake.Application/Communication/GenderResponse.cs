using Tilbake.Domain.Models;

namespace Tilbake.Application.Communication
{
    public class GenderResponse : BaseResponse<Gender>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Gender">Saved Gender.</param>
        /// <returns>Response.</returns>
        public GenderResponse(Gender Gender) : base(Gender)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public GenderResponse(string message) : base(message)
        { 

        }        
    }
}