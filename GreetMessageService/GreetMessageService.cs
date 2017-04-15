using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocTest
{
    public class GreetMessageService
    {
          ISendable greetTool;

        public GreetMessageService(ISendable sendtool)
        {
            greetTool = sendtool;
        }
        public void Greet(string message)
        {
            greetTool.Send(message);
        }
    }
}
