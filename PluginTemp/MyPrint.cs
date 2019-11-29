using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginSystem;

namespace PluginTemp
{
    public class MyPrint : IPrintAble
    {
        private readonly string data;

        public MyPrint(string data)
        {
            this.data = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + data;
        }

        public string PrintData() => data;
    }
}
