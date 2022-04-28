namespace TicTac.Services
{
    public class TicTacAppService : ITicTacAppService
    {
        private ITicTacDispatcher _ticTacDispatcher;
        
        public TicTacAppService()
        { }

        public TicTacAppService(ITicTacDispatcher ticTacDispatcher)
        {
            _ticTacDispatcher = ticTacDispatcher;
        }

        public string GetItemCode(ITicTacDispatcher ticTacDispatcher)
        {
            _ticTacDispatcher = ticTacDispatcher;
            return _ticTacDispatcher.GetTicTacItemCode();
        }
    }
}
