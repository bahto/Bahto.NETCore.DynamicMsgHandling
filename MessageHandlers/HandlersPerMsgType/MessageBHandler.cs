namespace MessageHandlers.HandlersPerMsgType
{
    internal class MessageBHandler : IMessageHandler
    {
        private string message;

        public string GetMessage()
        {
            return message;
        }

        public void ProcessMessage()
        {
            message = message + "_PROCESSED_BY_HANDLER_B";
        }

        public void SetMessage(string message)
        {
            this.message = message;
        }
    }
}