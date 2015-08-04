using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    // Интерфейс ETL процедуры 
    interface IEtlInterface
    {
        List<IEtlModule> ModuleList { get; set; }
    }

    // Интерфейс ETL модуля
    interface IEtlModule
    {
        string Name { get; set; }
        List<object> Parameters { get; set; }
    }

}
