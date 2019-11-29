using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrintAble printSystem = LoadItem<IPrintAble>(Path.GetFullPath("../../../PluginTemp/bin/Debug/PluginTemp.dll"), "MyPrint", "This Class In PluginTemp");

            Console.WriteLine(printSystem.PrintData());
        }

        public static T LoadItem<T>(string fileName, string name, params object[] initData)
        {
            Type interfaceType = typeof(T);

            foreach (var type in System.Reflection.Assembly.LoadFile(fileName).GetTypes())
            {
                if (interfaceType.IsAssignableFrom(type) && interfaceType != type && type.Name == name)
                {
                    T instance = (T)Activator.CreateInstance(type, initData);

                    return instance;
                }
            }
            return default;
        }
    }

    public interface IPrintAble
    {
        string PrintData();
    }
}
