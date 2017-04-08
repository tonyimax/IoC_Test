using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocTest
{
    public class PhoneHelper : ISendable
    {
        public void Send(string message)
        {
            Console.Write($"Frome Phone:{message}\n ");
        }
    }
}
