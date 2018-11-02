using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo
{
    public interface IPhone
    {
        void CallForSomebody();
    }

    public class AndroidPhone2:IPhone
    {
        public void CallForSomebody()
        {
            Console.WriteLine("使用" + this.GetType().Name + "打电话");
        }
    }
    public class IOSPhone2:IPhone
    {
        public void CallForSomebody()
        {
            Console.WriteLine("使用" + this.GetType().Name + "打电话");
        }
    }
    public class CallSomebody2
    {
        public IPhone Phone { get; set; }

        public void Call()
        {
            Phone.CallForSomebody();
        }
    }
}
