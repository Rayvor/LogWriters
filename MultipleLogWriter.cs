using System;
using System.Collections.Generic;

namespace Homework14
{
    class MultipleLogWriter : AbstractLogWriter, IDisposable
    {
        private static MultipleLogWriter _multipleLogWriter;
        private static List<AbstractLogWriter> _list;
        private MultipleLogWriter() { }
        public override void LogWriting(string message)
        {
            _list.ForEach((a) => a.LogWriting(message));
        }

        public static MultipleLogWriter GetInstance(List<AbstractLogWriter> list)
        {
            _list = list;
            return _multipleLogWriter ??= new MultipleLogWriter();
        }

        public override void Dispose()
        {
            foreach (var writer in _list)
            {
                writer?.Dispose();
            }
        }
    }
}
