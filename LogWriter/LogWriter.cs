using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CommonInterfaces;

namespace LogWriterNameSpace
{
    public class LogWriter : ILogWriter
    {
        private static Queue<Log> _logQueue;
        private static string _logDir;
        private static string _logFile;
        private static int _maxLogAge = 0;
        private static int _queueSize = 0;
        private static DateTime _lastFlushed = DateTime.Now;

        private static string PathAddBackslash(string path)
        {
            string separator1 = Path.DirectorySeparatorChar.ToString();
            string separator2 = Path.AltDirectorySeparatorChar.ToString();
            path = path.Trim();
            if (path.EndsWith(separator1) || path.EndsWith(separator2))
                return path;

            if (path.Contains(separator2))
                return path + separator2;

            return path + separator1;
        }


        private static void InitLogDir()
        {
            if (string.IsNullOrEmpty(_logDir)) _logDir = Directory.GetCurrentDirectory();
            if (!Directory.Exists(_logDir)) Directory.CreateDirectory(_logDir);
            _logDir = PathAddBackslash(Path.GetFullPath(_logDir));
        }

        public LogWriter()
        {
                // Параметры логирования
                // 1. Директория с логами
                InitLogDir();
                // 2. Суффикс файла лога с расширением
                if (string.IsNullOrEmpty(_logFile)) _logFile = "log.txt";
            // Инициализируем очередь
                _logQueue = new Queue<Log>();
        }

        public void SetLogDir(string logDir) { _logDir = logDir; InitLogDir(); }

        public void SetLogFileName(string logFile) { _logFile = logFile; }

        public void SetMaxLogAge(int maxLogAge) { _maxLogAge = maxLogAge; }

        public void SetQueueSize(int queueSize) { _queueSize = queueSize; }

        public void WriteToLog(string message, LogType logType)
        {
            lock (_logQueue)
            {
                Log logEntry = new Log(message, logType);
                _logQueue.Enqueue(logEntry);

                if (_logQueue.Count >= _queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }
            }
        }

        private void FlushLog()
        {
            while (_logQueue.Count > 0)
            {
                Log entry = _logQueue.Dequeue();
                string logPath = _logDir + entry.LogDate + "_" + _logFile;

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
            TimeSpan logAge = DateTime.Now - _lastFlushed;
            if (logAge.TotalSeconds >= _maxLogAge)
            {
                _lastFlushed = DateTime.Now;
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

}
