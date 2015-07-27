using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;

namespace LogWriterNameSpace
{
    public class LogWriter
    {
        private static LogWriter instance;
        private static Queue<Log> logQueue;
        private static string logDir;
        private static string logFile;
        private static int maxLogAge;
        private static int queueSize;
        private static DateTime LastFlushed = DateTime.Now;

        private LogWriter() { }
        
        public static LogWriter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogWriter();
                    logQueue = new Queue<Log>();
                }
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Параметры логирования
                // 1. Директория с логами
                logDir = ConfigurationManager.AppSettings.Get("logDir");
                if (string.IsNullOrEmpty(logDir)) logDir = Directory.GetCurrentDirectory() + "\\";
                if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
                logDir = Path.GetFullPath(logDir) + "\\";
                // 2. Суффикс файла лога с расширением
                logFile = ConfigurationManager.AppSettings.Get("logFile");
                if (string.IsNullOrEmpty(logFile)) logFile = "log.txt";
                if (!int.TryParse(ConfigurationManager.AppSettings.Get("logFile"), out maxLogAge))
                {
                    maxLogAge = 0;
                }
                if (!int.TryParse(ConfigurationManager.AppSettings.Get("queueSize"), out queueSize))
                {
                    queueSize = 0;
                }

                return instance;
            }
        }

        public void WriteToLog(string message, LogType logType)
        {
            lock (logQueue)
            {
                Log logEntry = new Log(message, logType);
                logQueue.Enqueue(logEntry);

                if (logQueue.Count >= queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }
            }
        }

        private void FlushLog()
        {
            if (instance == null) return;
            while (logQueue.Count > 0)
            {
                Log entry = logQueue.Dequeue();
                string logPath = logDir + entry.LogDate + "_" + logFile;

                using (FileStream fs = File.Open(logPath, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter log = new StreamWriter(fs))
                    {
                        log.WriteLine(string.Format("{0}\t{1}", entry.LogTime, entry.Message));
                    }
                }
            }
        }

        private bool DoPeriodicFlush()
        {
            TimeSpan logAge = DateTime.Now - LastFlushed;
            if (logAge.TotalSeconds >= maxLogAge)
            {
                LastFlushed = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        ~LogWriter()
        {
            FlushLog();
        }
    }

    public class Log
    {
        public string Message { get; set; }
        public string LogTime { get; set; }
        public string LogDate { get; set; }

        public Log(string message, LogType logType)
        {
            string logTypeStr;
            switch (logType)
            {
                case LogType.Info:
                    logTypeStr = "[info]";
                    break;
                case LogType.Warning:
                    logTypeStr = "[warning]";
                    break;
                case LogType.Error:
                    logTypeStr = "[error]";
                    break;
                default:
                    logTypeStr = "[unknown]";
                    break;
            }
            Message = logTypeStr + "\t" + message;
            LogDate = DateTime.Now.ToString("yyyy-MM-dd");
            LogTime = DateTime.Now.ToString("HH:mm:ss.fff tt");
        }
    }

    public enum LogType
    {
        Info, Warning, Error
    }
}
