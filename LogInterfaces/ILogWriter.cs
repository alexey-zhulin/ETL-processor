using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface ILogWriter
    {
        // Процедура установки максимального размера очереди лога до сброса в файл
        void SetMaxLogAge(int maxLogAge);
        // Процедура установки максимального времени между сбросами очереди лога в файл
        void SetQueueSize(int queueSize);
        // Процедура установки директории для файлов с логами
        void SetLogDir(string logDir);
        // Процедура установки суффикса имени файла с логами
        void SetLogFileName(string logFile);
        // Процедура создания записи в логе
        void WriteToLog(string message, LogType logType);
    }

    public enum LogType
    {
        Info, Warning, Error
    }
}
