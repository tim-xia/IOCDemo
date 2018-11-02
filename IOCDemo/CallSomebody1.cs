using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo
{
    /*原始做法
     *
     */
    public class CallSomebody1
    {
        public IOSPhone1 Phone { get; set; }

        public void Call()
        {
            Phone.CallSomebody();
        }

    }
    public class AndroidPhone1
    {
        public void CallForSomebody()
        {
            Console.WriteLine("使用"+this.GetType().Name+"打电话" );
        }
    }
    public class IOSPhone1
    {
        public void CallSomebody()
        {
            Console.WriteLine("使用" + this.GetType().Name + "打电话");
        }
    }
}
