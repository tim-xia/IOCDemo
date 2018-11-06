using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace IOCDemo
{
    public interface ICallSomebody
    {

    }
    public interface IPhoneUnity
    {
        void CallForSomebody();
    }

    public class UnityApplePhone : IPhoneUnity
    {
        public void CallForSomebody()
        {
            Console.WriteLine("使用" + this.GetType().Name + "打电话（自动注入）");
        }
    }
    public class UnityAndriodPhone : IPhoneUnity
    {
        public void CallForSomebody()
        {
            Console.WriteLine("使用" + this.GetType().Name + "打电话(自动注入)");
        }
    }

    public class CallSomebody5:ICallSomebody
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        [Dependency]
        public IPhoneUnity Phone { get; set; }

        /// <summary>
        /// 构造方法注入
        /// </summary>
        /// <param name="phone"></param>
        [InjectionConstructor]
        public CallSomebody5(IPhoneUnity phone)
        {
            this.Phone = phone;
        }

        /// <summary>
        /// 方法注入
        /// </summary>
        /// <param name="phone"></param>
        [InjectionMethod]
        public void MethodInject(IPhoneUnity phone)
        {
            this.Phone = phone;
        }

        /// <summary>
        /// 调用
        /// </summary>
        public void Call()
        {
            Phone.CallForSomebody();
        }
    }
}
