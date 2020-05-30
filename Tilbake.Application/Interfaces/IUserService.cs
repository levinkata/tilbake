using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
