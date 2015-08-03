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
        int MaxLogAge { get; set; }
        // Максимальное время между сбросами очереди лога в файл
        int QueueSize { get; set; }
        // Директория для файлов с логами
        string LogDir { get; set; }
        // Суффикс имени файла с логами
        string LogFileName { get; set; }
        // Процедура создания записи в логе
        void WriteToLog(string message, LogType logType);
    }

    public enum LogType
    {
        Info, Warning, Error
    }
}
