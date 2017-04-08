using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocTest
{
    //public enum SendToolType
    //{
    //    Email,
    //    Telephone,
    //}
    public class GreetMessageService
    {
        //EmailHelper greetTool;
          ISendable greetTool;

        //public GreetMessageService(SendToolType sendToolType)
        //{
        //    //greetTool = new EmailHelper();
        //    if (sendToolType == SendToolType.Email)
        //    {
        //        greetTool = new EmailHelper();
        //    }
        //    else if (sendToolType == SendToolType.Telephone)
        //    {
        //        greetTool = new PhoneHelper();
        //    }
        //}

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
