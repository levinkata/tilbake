using System.Collections.Generic;
using System.Text.Json;

namespace Tilbake.Application.Resources
{
    public class ErrorResource
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
