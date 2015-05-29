

using strange.extensions.dispatcher.eventdispatcher.api;
namespace Test
{
    public interface ITestService
    {
        void Request();
        IEventDispatcher dispatcher { get; set; }
    }
}