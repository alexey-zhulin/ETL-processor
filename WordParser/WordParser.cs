using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using LogWriterNameSpace;

namespace WordTools
{
    // Класс библиотеки парсера Word файла
    public class WordParser
    {
        public String fileName;
        private ParserResult _parserResult;
        public ParserResult parserResult { get { return _parserResult; } }

        public WordParser()
        {
            _parserResult = new ParserResult();
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
            foreach (Word.Paragraph par in docs.Paragraphs) 
            {
                var range = par.Range;
                _parserResult.Header = _parserResult.Header + range.Text;
            }
            // Создадим экземпляр для логирования
            LogWriter logWriter = LogWriter.Instance;
            // Соберем данные всех таблиц
            foreach (Word.Table tb in docs.Tables)
            {
                for (int row = 1; row <= tb.Rows.Count; row++)
                {
                    List<String> colList = new List<String>();
                    for (int col = 1; col <= tb.Columns.Count; col++)
                    //for (int col = 1; col <= tb.Rows[row].Cells.Count; col++)
                    {
                        try
                        {
                            var cell = tb.Cell(row, col);
                            colList.Add(cell.Range.Text);
                        }
                        catch (Exception e)
                        {
                            string errInfo = "fileName = " + fileName + "; row = " + row +  "; col = " + col + "; message: " + e.Message;
                            logWriter.WriteToLog(errInfo, LogType.Error);
                        }
                    }
                    _parserResult.Table.Add(colList);
                }
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
            Header = "";
        }
    }
}
