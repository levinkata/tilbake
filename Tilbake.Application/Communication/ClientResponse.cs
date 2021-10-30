using Tilbake.Core.Models;

namespace Tilbake.Application.Communication
{
    public class ClientResponse : BaseResponse<Client>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Client">Saved Client.</param>
        /// <returns>Response.</returns>
        public ClientResponse(Client Client) : base(Client)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ClientResponse(string message) : base(message)
        { 

        }        
    }
}