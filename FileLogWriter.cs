using System;
using System.IO;

namespace Homework14
{
    class FileLogWriter : AbstractLogWriter
    {
        private static FileLogWriter _fileLogWriter;
        private static StreamWriter _writer;

        private FileLogWriter() { }

        public override void LogWriting(string message)
        {
            _writer.WriteLine(message);
            _writer.Flush();
        }

        public static FileLogWriter GetInstance(string logFile = "log.txt")
        {
            FileStream fs = File.Open(logFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            _writer = new StreamWriter(fs);
            _writer.BaseStream.Seek(0, SeekOrigin.End);

            return _fileLogWriter ??= new FileLogWriter();
        }

        public static void SetPath(string path)
        {
            FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

            _writer?.Close();
            _writer = new StreamWriter(fs);
            _writer.BaseStream.Seek(0, SeekOrigin.End);
        }

        public override void Dispose()
        {
            _writer?.Dispose();
        }
    }
}
