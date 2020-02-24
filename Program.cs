using System;
using System.Collections.Generic;

namespace Homework14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractLogWriter> list = new List<AbstractLogWriter>
            {
                ConsoleLogWriter.GetInstance(), FileLogWriter.GetInstance()
            };

            using var mlw = MultipleLogWriter.GetInstance(list);

            {
                mlw.LogError("Error message");
                mlw.LogInfo("Info message");
                mlw.LogWarning("Warning message");

                FileLogWriter.SetPath("log.txt");
                mlw.LogInfo("test");
            }


            Console.ReadKey();
        }

        static void Do(int a, string b)
        {

        }

        static int Do2(int a, string c)
        {
            return a;
        }
    }
}
