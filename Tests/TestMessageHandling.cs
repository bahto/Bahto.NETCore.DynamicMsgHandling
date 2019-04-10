using MessageDispatcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestMessageHandling
    {
        [TestMethod]
        public void TestMessageA()
        {
            var demo1 = new MessageDispatcher.MessageDispatcher("MessageA", "BodyOfMsgA");
            StringAssert.Contains(demo1.ResultMsg(), "_PROCESSED_BY_HANDLER_A");
        }

        [TestMethod]
        public void TestMessageB()
        {
            var demo1 = new MessageDispatcher.MessageDispatcher("MessageB", "BodyOfMsgB");
            StringAssert.Contains(demo1.ResultMsg(), "_PROCESSED_BY_HANDLER_B");
        }

        [TestMethod]
        public void TestUnknownMessage()
        {
            var demo1 = new MessageDispatcher.MessageDispatcher("UnknownMsgType", "UnknownMsgBody");
            StringAssert.Contains(demo1.ResultMsg(), "_PROCESSED_BY_DEFAULT_HANDLER");
        }
    }
}