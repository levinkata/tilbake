using Tilbake.Core.Models;

namespace Tilbake.Application.Communication
{
    public class CountryResponse : BaseResponse<Country>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Country">Saved Country.</param>
        /// <returns>Response.</returns>
        public CountryResponse(Country Country) : base(Country)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CountryResponse(string message) : base(message)
        { 

        }        
    }
}