using Tilbake.Domain.Models;

namespace Tilbake.Application.Communication
{
    public class OccupationResponse : BaseResponse<Occupation>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Occupation">Saved Occupation.</param>
        /// <returns>Response.</returns>
        public OccupationResponse(Occupation Occupation) : base(Occupation)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public OccupationResponse(string message) : base(message)
        { 

        }        
    }
}