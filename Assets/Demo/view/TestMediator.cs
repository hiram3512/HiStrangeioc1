using strange.extensions.mediation.impl;
using UnityEngine;
namespace Test
{
    public class TestMediator : EventMediator
    {
        [Inject]
        //通过[Inject],并且testview与testmediator的绑定,view被赋值为testview
        public TestView view { get; set; }
        public override void OnRegister()
        {
            //unity初始运行时,strangeioc发出ContextEvent.START指令,通过指令与startcommand的绑定,执行startcommand逻辑生成新的GameObject
            //当新的GameObject生成后,因为 mediationBinder.Bind<TestView>().To<TestMediator>();的绑定,testmediator的onregister逻辑也会被出发.
            //现在当GameObject生成后给它添加一个监听,监听是否有点击发生,当有点击发生时,执行onclick方法.
            view.dispatcher.AddListener(TestEvent.Click, OnClick);
            //监听当获取到数据时,更新显示
            view.dispatcher.AddListener(TestEvent.Update, OnUpdate);
        }
        public override void OnRemove()
        {
            //view被删除时,清理对应的mediator,哪怕在unity编辑器中删除view,也会清理mediator
            view.dispatcher.RemoveListener(TestEvent.Click, OnClick);
            dispatcher.RemoveListener(TestEvent.Update, OnUpdate);
            Debug.Log("Mediator OnRemove");
        }
        void OnClick()
        {
            dispatcher.Dispatch(TestEvent.Request);
        }
        void OnUpdate()
        {
            //view.updateScore(score);
        }
    }
}