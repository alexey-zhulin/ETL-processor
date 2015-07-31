using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LogWriterConfig
{
    public class LogWriterConfigSection : ConfigurationSection
    {
        private LogWriterConfigSection instance;
        private string spath;
        
        private static ConfigurationProperty _logDir; // Директория для файлов лога
        private static ConfigurationProperty _logFileName; // Суффикс для файлов лога
        private static ConfigurationProperty _maxLogAge; // Минимальное кол-во секунд для сброса очереди лога в файл
        private static ConfigurationProperty _queueSize; // Максимальный размер очереди лога перед сбросом в файл
        private static ConfigurationProperty _externalLogLib; // Файл для подключения внешней библиотеки логирования
        
        static LogWriterConfigSection()
        {
            _logDir = new ConfigurationProperty(
                "logDir",
                typeof(string),
                null,
                ConfigurationPropertyOptions.None
            );
            _logFileName = new ConfigurationProperty(
                "logFileName",
                typeof(string),
                null,
                ConfigurationPropertyOptions.None
            );
            _maxLogAge = new ConfigurationProperty(
                "maxLogAge",
                typeof(int),
                null,
                ConfigurationPropertyOptions.None
            );
            _queueSize = new ConfigurationProperty(
                "queueSize",
                typeof(int),
                null,
                ConfigurationPropertyOptions.None
            );
            _externalLogLib = new ConfigurationProperty(
                "externalLogLib",
                typeof(string),
                null,
                ConfigurationPropertyOptions.None
            );
        }

        ///<summary>
        ///Get this configuration set from the application's default config file
        ///</summary>
        public LogWriterConfigSection Open()
        {
            System.Reflection.Assembly assy =
                    System.Reflection.Assembly.GetEntryAssembly();
            return Open(assy.Location);
        }

        ///<summary>
        ///Get this configuration set from a specific config file
        ///</summary>
        public LogWriterConfigSection Open(string path)
        {
            if ((object)instance == null)
            {
                if (path.EndsWith(".config",
                            StringComparison.InvariantCultureIgnoreCase))
                    spath = path.Remove(path.Length - 7);
                else
                    spath = path;
                Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
                if (config.Sections["LogWriterConfigSection"] == null)
                {
                    instance = new LogWriterConfigSection();
                    config.Sections.Add("LogWriterConfigSection", instance);
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                    instance =
                        (LogWriterConfigSection)config.Sections["LogWriterConfigSection"];
            }
            return instance;
        }

        ///<summary>
        ///Save the current property values to the config file
        ///</summary>
        public void Save()
        {
            // The Configuration has to be opened anew each time we want to 
            // update the file contents.Otherwise, the update of other custom 
            // configuration sections will cause an exception to occur when we 
            // try to save our modifications, stating that another app has 
            // modified the file since we opened it.
            Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
            LogWriterConfigSection section =
                    (LogWriterConfigSection)config.Sections["LogWriterConfigSection"];
            //
            // TODO: Add code to copy all properties from "this" to "section"
            //
            section.logDir = this.logDir;
            section.logFileName = this.logFileName;
            section.maxLogAge = this.maxLogAge;
            section.queueSize = this.queueSize;
            section.externalLogLib = this.externalLogLib;
            config.Save(ConfigurationSaveMode.Modified);
        }

        [ConfigurationProperty("logDir", IsRequired = false)]
        public string logDir
        {
            get { return (string)base[_logDir]; }
            set { base[_logDir] = value; }
        }

        [ConfigurationProperty("logFileName", IsRequired = false)]
        public string logFileName
        {
            get { return (string)base[_logFileName]; }
            set { base[_logFileName] = value; }
        }

        [ConfigurationProperty("maxLogAge", IsRequired = false)]
        public int maxLogAge
        {
            get { return (int)base[_maxLogAge]; }
            set { base[_maxLogAge] = value; }
        }

        [ConfigurationProperty("queueSize", IsRequired = false)]
        public int queueSize
        {
            get { return (int)base[_queueSize]; }
            set { base[_queueSize] = value; }
        }

        [ConfigurationProperty("externalLogLib", IsRequired = false)]
        public string externalLogLib
        {
            get { return (string)base[_externalLogLib]; }
            set { base[_externalLogLib] = value; }
        }

    }
}
