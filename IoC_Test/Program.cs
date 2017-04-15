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
            ISendable emailsend = new EmailHelper();
            ISendable greetTool = SendToolFactory.GetInstance();
            GreetMessageService service = new GreetMessageService(greetTool);
            service.Greet(message);
        }
    }
}
