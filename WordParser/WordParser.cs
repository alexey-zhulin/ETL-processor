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
        private LogWriter _logWriter;
        public ParserResult parserResult { get { return _parserResult; } }

        public WordParser()
        {
            _parserResult = new ParserResult();
            // Создадим экземпляр для логирования
            _logWriter = LogWriter.Instance;
        }

        public void ParseFile()
        {
            _logWriter.WriteToLog("Start file processing (fileName = " + fileName + ")", LogType.Info);
            // Проверим на корректность имени файла
            if (string.IsNullOrEmpty(fileName)) 
            {
                //throw new ArgumentException("'fileName' cannot be null or empty.", "fileName");
                _logWriter.WriteToLog("'fileName' cannot be null or empty.", LogType.Error);
            }
            if (!File.Exists(fileName)) 
            {
                //throw new Exception("'" + fileName + "' does not exists");
                _logWriter.WriteToLog("'" + fileName + "' does not exists", LogType.Error);
            }
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
                            string errInfo = "message: " + e.Message + " (row = " + row +  "; col = " + col + ")";
                            _logWriter.WriteToLog(errInfo, LogType.Error);
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
