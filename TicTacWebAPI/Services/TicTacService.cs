using System.Collections.Generic;
using System.Linq;
using TicTac.Services;
using TicTac.WebAPI.Models;

namespace TicTac.WebAPI.Services
{
    public class TicTacService : ITicTacService
    {
        private readonly ITicTacAppService _ticTacAppService;

        public TicTacService(ITicTacAppService ticTacAppService)
        {
            _ticTacAppService = ticTacAppService;
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
            switch (SelecteMethod(number))
            {
                case 1:
                    listOfNumbers.Add(_ticTacAppService.GetItemCode(new TicDispatcher()));
                    break;
                case 2:
                    listOfNumbers.Add(_ticTacAppService.GetItemCode(new TacDispatcher()));
                    break;
                case 3:
                    listOfNumbers.Add(_ticTacAppService.GetItemCode(new TicTacDispatcher()));
                    break;
                default:
                    listOfNumbers.Add(number.ToString());
                    break;
            }
        }

        private int SelecteMethod(int number)
        {
            int selectedMethod = 0;

            if (number % 3 == 0 && number % 5 != 0)
                selectedMethod = 1;

            if (number % 3 != 0 && number % 5 == 0)
                selectedMethod = 2;

            if (number % 3 == 0 && number % 5 == 0)
                selectedMethod = 3;

            return selectedMethod;
        }
    }
}
