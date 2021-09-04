using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class ConsoleLogger : ILogger
    {
        public void PublishLogging(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
