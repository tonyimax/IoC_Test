﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocTest
{
    public class SMSHelper : ISendable
    {
        public void Send(string message)
        {
            Console.WriteLine("Frome SMS: " + message);
        }
    }
}
