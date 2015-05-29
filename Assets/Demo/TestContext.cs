using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;
namespace Test
{
    public class TestContext : MVCSContext
    {
        public TestContext(MonoBehaviour view)
            : base(view)
        {
        }
        protected override void mapBindings()
        {
            injectionBinder.Bind<ITestModel>().To<TestModel>();
            injectionBinder.Bind<ITestService>().To<TestService>();
            mediationBinder.Bind<TestView>().To<TestMediator>();
            commandBinder.Bind(TestEvent.Request).To<RequestCommand>();
            commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
        }
    }
}