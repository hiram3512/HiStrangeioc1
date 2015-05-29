

using UnityEngine;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
namespace Test
{
    public class RequestCommand : EventCommand
    {
        [Inject]
        public ITestModel model { get; set; }
        [Inject]
        public ITestService service { get; set; }
        public override void Execute()
        {
            //因为请求数据需要消耗时间,不是立刻完成.
            Retain();
            //接收到请求命令,开始执行
            //添加监听,监听请求数据是否已经完成(因为延迟,请求数据需要时间)
            service.dispatcher.AddListener(TestEvent.RequestFinish, onComplete);
            //通知service部分开始请求服务器数据
            service.Request();
        }
        private void onComplete(IEvent evt)
        {
            //移除监听(是否请求完成的监听)
            //移除监听还要添加回调onComplete?按理说请求完成时回调一次,移除监听时又回调一次,一共两次才对,但是oncomplete方法只执行了一次.
            //估计strangeioc移除监听时回调方法不执行,添加这个参数是为了销毁这个方法?
            service.dispatcher.RemoveListener(TestEvent.RequestFinish, onComplete);

            model.data = evt.data.ToString();
            Debug.Log(evt.data.ToString());
            //请求完成后一定记得使用release()释放
            Release();
        }
    }
}