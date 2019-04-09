namespace MessageHandlers.HandlersPerMsgType
{
    public interface IMessageHandler
    {
        void SetMessage(string m);
        void ProcessMessage();
        string GetMessage();
    }
}