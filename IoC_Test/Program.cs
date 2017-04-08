using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IocTest
{
    class Program
    {
        public abstract class SendToolFactory
        {
            public static ISendable GetInstance()
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(GetAssembly()); // 加载程序集
                    object obj = assembly.CreateInstance(GetObjectType()); // 创建类的实例 
                    return obj as ISendable;
                }
                catch
                {
                    return null;
                }
            }

            static string GetAssembly()
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["AssemblyString"]);
            }

            static string GetObjectType()
            {
                var k = ConfigurationManager.AppSettings["TypeString"];
                return k;
            }
        }
        static void Main(string[] args)
        {
            string message = "新年快乐！过节费5000.";
            //GreetMessageService service = new GreetMessageService();
            //GreetMessageService service = new GreetMessageService(SendToolType.Email);
            ISendable emailsend = new EmailHelper();
            //GreetMessageService service = new GreetMessageService(emailsend);
            ISendable greetTool = SendToolFactory.GetInstance();
            GreetMessageService service = new GreetMessageService(greetTool);
            service.Greet(message);

            //service = new GreetMessageService(SendToolType.Telephone);
            //ISendable phonesend = new PhoneHelper();
            //service = new GreetMessageService(phonesend);
            //service.Greet(message);

            //ISendable sms_send = new SMSHelper();
            //service = new GreetMessageService(sms_send);
            //service.Greet(message);

            //ISendable webcharsend = new WebCharHelper();
            //service = new GreetMessageService(webcharsend);
            //service.Greet(message);
        }
    }
}
