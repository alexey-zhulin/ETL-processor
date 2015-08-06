using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{

    // Базовый интерфейс ETL модуля
    public interface IEtlModule
    {
        #region Properties
        // Наименование модуля
        string Name { get; set; }
        // Порядок исполнения в ETL процедуре
        int Order { get; set; }
        // Входные данные для обработки
        List<object> InputData { get; set; }
        // Выходные данные после обработки
        List<object> OutputData { get; set; }
        // Объект для логирования процесса обработки
        ILogWriter LogWriter { get; set; }
        #endregion

        #region Methods
        // Процедура получения входных данных для дальнейшей фильтрации ползователем
        // или алгоритмом для дальнейшего заполнения InputData
        // Например, получения списка файлов в определенной директории или получение списка таблиц с данными
        List<object> GetUnfilteredInputData();
        // Процедура исполнения модуля
        void Run();
        #endregion
    }

    // Интерфейс ETL модуля для работы с входными данными файловой системы
    public interface IEtlModuleFile : IEtlModule
    {
        #region Properties
        // Базовая директория для сбора файлов как источника входных данных
        string BaseDirectory { get; set; }
        // Собирать ли файлы в поддиректориях
        bool UseSubdirectories { get; set; }
        // Маска для фильтрации файлов
        string FileMask { get; set; }
        #endregion
    }

}
