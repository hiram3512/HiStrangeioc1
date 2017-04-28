using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
namespace Test
{
    public class TestView : View
    {
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        //通过[Inject],我们可以得到dispatcher=strangeioc的事件分发器
        //如果没有[Inject],dispatcher的值==null
        public IEventDispatcher dispatcher { get; set; }
        void OnGUI()
        {
            if (GUI.Button(new Rect(0, 0, 100, 40), "click"))
            {
                //分发器发出点击事件(点击命令)
                dispatcher.Dispatch(TestEvent.Click);
            }
        }
    }
}
