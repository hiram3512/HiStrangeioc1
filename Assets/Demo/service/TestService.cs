
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using strange.extensions.context.api;
namespace Test
{
    public class TestService : ITestService
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        //借助testroot父物体的monobehaviour来执行StartCoroutine方法
        public GameObject contextView { get; set; }
        public void Request()
        {
            contextView.GetComponent<MonoBehaviour>().StartCoroutine(Wait());
        }
        [Inject]
        public IEventDispatcher dispatcher { get; set; }

        //模拟网络延迟,1秒后收到数据
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1);
            dispatcher.Dispatch(TestEvent.RequestFinish, "get data success, and your point is 100");
        }
    }
}