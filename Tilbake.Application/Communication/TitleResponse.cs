using Tilbake.Core.Models;

namespace Tilbake.Application.Communication
{
    public class TitleResponse : BaseResponse<Title>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Title">Saved Title.</param>
        /// <returns>Response.</returns>
        public TitleResponse(Title Title) : base(Title)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TitleResponse(string message) : base(message)
        { 

        }        
    }
}