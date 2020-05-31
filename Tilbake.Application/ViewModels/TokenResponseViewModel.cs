using Newtonsoft.Json;

namespace Tilbake.Application.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class TokenResponseViewModel
    {
        #region Constructor
        public TokenResponseViewModel()
        {

        }
        #endregion

        #region Properties
        public string Token { get; set; }
        public int Expiration { get; set; }
        #endregion
    }
}
