namespace MessageHandlers.HandlersPerMsgType
{
    public class DefaultHandler : IMessageHandler
    {
        private string _message;

        public string GetMessage()
        {
            return _message;
        }

        public void ProcessMessage()
        {
            _message = _message + "_PROCESSED_BY_DEFAULT_HANDLER";
        }

        public void SetMessage(string message)
        {
            _message = message;
        }
    }
}