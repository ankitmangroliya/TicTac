using System.Collections.Generic;
using System.Linq;
using TicTac.WebAPI.Models;

namespace TicTac.WebAPI.Services
{
    public class TicTacService : ITicTacService
    {
        private readonly IEnumerable<ITicTacDispatcher> _ticTacDispatcher;

        public TicTacService(IEnumerable<ITicTacDispatcher> ticTacDispatcher)
        {
            _ticTacDispatcher = ticTacDispatcher;
        }

        public List<string> Post(RequestModel requestModel)
        {
            var listOfNumbers = new List<string>();

            for (int i = 1; i <= requestModel.number; i++)
            {
                PrintResult(i, ref listOfNumbers);
            }

            return listOfNumbers.ToList();
        }

        private void PrintResult(int number, ref List<string> listOfNumbers)
        {
            string TicTacItemCode = string.Empty;

            foreach(var dispatcher in _ticTacDispatcher)
            {
                string itemCode = dispatcher.GetTicTacItemCode(number);

                if (!string.IsNullOrWhiteSpace(itemCode))
                    TicTacItemCode = itemCode;
            }

            if (string.IsNullOrWhiteSpace(TicTacItemCode))
                listOfNumbers.Add(number.ToString());
            else
                listOfNumbers.Add(TicTacItemCode);

        }
        
    }
}
