using Tilbake.Core.Models;

namespace Tilbake.Application.Communication
{
    public class MaritalStatusResponse : BaseResponse<MaritalStatus>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="MaritalStatus">Saved MaritalStatus.</param>
        /// <returns>Response.</returns>
        public MaritalStatusResponse(MaritalStatus MaritalStatus) : base(MaritalStatus)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public MaritalStatusResponse(string message) : base(message)
        { 

        }        
    }
}