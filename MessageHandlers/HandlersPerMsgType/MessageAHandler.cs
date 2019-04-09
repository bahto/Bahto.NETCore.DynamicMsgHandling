namespace MessageHandlers.HandlersPerMsgType
{
    internal class MessageAHandler : IMessageHandler
    {
        private string message;

        public string GetMessage()
        {
            return message;
        }

        public void ProcessMessage()
        {
            message = message + "_PROCESSED_BY_HANDLER_A";
        }

        public void SetMessage(string message)
        {
            this.message = message;
        }
    }
}