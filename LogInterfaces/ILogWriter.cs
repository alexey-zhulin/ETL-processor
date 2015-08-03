using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface ILogWriter
    {
        // Максимальный размер очереди лога до сброса в файл
        void SetMaxLogAge(int maxLogAge);
        // Максимальное время между сбросами очереди лога в файл
        void SetQueueSize(int queueSize);
        // Директория для файлов с логами
        void SetLogDir(string logDir);
        // Суффикс имени файла с логами
        void SetLogFileName(string logFile);
        // Процедура создания записи в логе
        void WriteToLog(string message, LogType logType);
    }

    public enum LogType
    {
        Info, Warning, Error
    }
}
