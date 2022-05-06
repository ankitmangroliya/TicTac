using System;
using TicTac.WebAPI.Helper;

namespace TicTac.WebAPI.Services
{
    public class TacDispatcher : ITicTacDispatcher
    {
        public string GetTicTacItemCode(int number)
        {
            if (number % 5 == 0)
            {
                return (DateTime.Today.DayOfWeek == DayOfWeek.Friday) ? ConstantProperties.Wak : ConstantProperties.Tac;
            }

            return string.Empty;
        }
    }
}
