using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces.Communication
{
    public class TitleResponse : BaseResponse<Title>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="title">Saved title.</param>
        /// <returns>Response.</returns>
        public TitleResponse(Title title) : base(title)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TitleResponse(string message) : base(message)
        { }
    }
}
