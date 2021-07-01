using Tilbake.Domain.Models;

namespace Tilbake.Application.Communication
{
    public class ClientTypeResponse : BaseResponse<ClientType>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="ClientType">Saved ClientType.</param>
        /// <returns>Response.</returns>
        public ClientTypeResponse(ClientType ClientType) : base(ClientType)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ClientTypeResponse(string message) : base(message)
        { 

        }        
    }
}