using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
namespace Test
{
    public class StartCommand : EventCommand
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        //因为testroot继承于ContextView,我们通过 [Inject(ContextKeys.CONTEXT_VIEW)]这句逻辑
        //便可以得到contextView=testroot;
        public GameObject contextView { get; set; }
        public override void Execute()
        {
            GameObject test = new GameObject("test");
            test.AddComponent<TestView>();
            test.transform.SetParent(contextView.transform);
        }
    }
}