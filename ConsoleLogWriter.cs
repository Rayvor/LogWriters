using System;

namespace Homework14
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        private static ConsoleLogWriter _consoleLogWriter;

        public override void LogWriting(string message)
        {
            Console.WriteLine(message);
        }

        private ConsoleLogWriter()
        {
            
        }

        public static ConsoleLogWriter GetInstance()
        {
            return _consoleLogWriter ??= new ConsoleLogWriter();
        }
    }
}
