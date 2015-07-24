using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace WordParser
{
    // Класс библиотеки парсера Word файла
    public class ParserLib
    {
        public String fileName;
        private ParserResult _parserResult;
        public ParserResult parserResult { get { return _parserResult; } }
        private bool _hasErrors;
        public bool hasErrors { get { return _hasErrors; } }
        private String _errorInfo;
        public String errorInfo { get { return _errorInfo; } }

        public ParserLib()
        {
            _parserResult = new ParserResult();
            _hasErrors = false;
            _errorInfo = "";
        }

        public void ParseFile()
        {
            // Проверим на корректность имени файла
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("'fileName' cannot be null or empty.", "fileName");
            if (!File.Exists(fileName))
                throw new Exception("'" + fileName + "' does not exists");
            // Откроем файл в MS Word
            var word = new Word.Application();
            object miss = System.Reflection.Missing.Value;
            object readOnly = true;
            var docs = word.Documents.Open(fileName, ref miss, ref readOnly,
                                           ref miss, ref miss, ref miss, ref miss,
                                           ref miss, ref miss, ref miss, ref miss,
                                           ref miss, ref miss, ref miss, ref miss,
                                           ref miss);
            foreach (Word.Table tb in docs.Tables)
            {
                // insert code here to get text from cells in first column
                // and insert into datatable.
            }

            ((Word._Document)docs).Close();
            ((Word._Application)word).Quit();
        }
    }

    // Класс результирующей структуры, которую возвращает ParserLib
    public class ParserResult
    {
        public String Header;
        public List<List<String>> Table;

        public ParserResult()
        {
            Table = new List<List<string>>();
        }
    }
}
