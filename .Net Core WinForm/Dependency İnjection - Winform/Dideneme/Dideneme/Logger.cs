using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dideneme
{
    public class Logger : ILogger
    {
        public void GetHello()
        {
            Console.WriteLine("Get hello DI ile çalıştı");
        }

        public void SetHello()
        {
            Console.WriteLine("Set hello DI ile çalıştı");
        }
    }
}
