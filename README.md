# Dynamic object instantiation with C#

## Background information
In this solution you will find an example on how to use the System.Activator class to create object types dynamically based on "dynamic" string values.
I use it in a solution where a message broker is used for transport of messages and microservices running in Docker containers are responsible for processing these messages in the right way.

## The idea
Put the message dispatcher in project 1, and the message handlers in a seperate project 2. The message dispatcher needs to be able to 
instantiate objects dynamically based on the messageType read from the message headers. In this example only logic is programmed to solve the dynamic object creation. You will not find any code on how to interact with message broker etc.

## Tests
Run the tests in the Tests-project for an idea on how the solution works.

### Test: TestMessageA & TestMessageA
Both these test's show the behavior of the message dispatcher in case it can find a specific message handler for these two messageTypes.
In both these cases an NullReferenceException will not be thrown and the right message handler will be instantiated.
```CSHARP
DemoMessageDispatcher.cs
IMessageHandler myMessageHandler;
try
{
  // Try to use specific MessageHandler based on incomming msgType
  var type = $"MessageHandlers.HandlersPerMsgType.{msgType}Handler, MessageHandlers";
  myMessageHandler = Activator.CreateInstance(Type.GetType(type)) as IMessageHandler;
  if (myMessageHandler == null) throw new NullReferenceException();
}           
```

### Test: TestUnknownMessage
This test is showing the behavior in case no specific message handler can be found. In this case the message dispatcher instantiates the default handler and processes the message in a "default" way.
In this case a NullReferenceException will be thrown, the code in the catch-block will instantiate a default handler.
```CSHARP
DemoMessageDispatcher.cs
catch
{
  // Use default MessageHandler
  myMessageHandler = new DefaultHandler();
}
```
