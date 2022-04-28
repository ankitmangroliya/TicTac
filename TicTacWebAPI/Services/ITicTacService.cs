using System.Collections.Generic;
using TicTac.WebAPI.Models;

namespace TicTac.WebAPI.Services
{
    public interface ITicTacService
    {
        List<string> Post(RequestModel requestModel);
    }
}
