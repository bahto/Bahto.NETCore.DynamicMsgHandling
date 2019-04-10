using System;
using MessageHandlers.HandlersPerMsgType;

namespace MessageDispatcher
{
    public class MessageDispatcher
    {
        private readonly string _msgProcessed;

        public MessageDispatcher(string msgType, string msgBody)
        {
            IMessageHandler myMessageHandler;
            try
            {
                // Try to use specific MessageHandler based on incomming msgType
                var type = $"MessageHandlers.HandlersPerMsgType.{msgType}Handler, MessageHandlers";
                myMessageHandler = Activator.CreateInstance(Type.GetType(type)) as IMessageHandler;
                if (myMessageHandler == null) throw new NullReferenceException();
            }
            catch
            {
                // Use default MessageHandler
                myMessageHandler = new DefaultHandler();
            }

            myMessageHandler.SetMessage(msgBody);
            myMessageHandler.ProcessMessage();
            _msgProcessed = myMessageHandler.GetMessage();
        }

        public string ResultMsg()
        {
            return _msgProcessed;
        }
    }
}