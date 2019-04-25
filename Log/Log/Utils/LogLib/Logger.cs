using System;
using System.IO;

namespace Utils.LogLib
{
    public class Logger
    {
        private static Logger instance;
        private string logFilePath;
        private Logger()
        {
            this.logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test-log.log");
            if (!File.Exists(this.logFilePath))
            {
                File.Create(this.logFilePath).Dispose();
            }
        }
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
        public string ReadLog()
        {
            return File.ReadAllText(this.logFilePath);
        }
        public void Debug(string message)
        {
            message = $"Test logger [DEBUG] {DateTime.Now}: {message}";
            File.AppendAllText(this.logFilePath, message);
        }
    }
}
