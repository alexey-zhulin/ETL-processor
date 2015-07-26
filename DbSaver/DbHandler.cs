using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTools
{
    public class DbHandler
    {
        public string ServerName;
        public string Schema = "dbo";
        public string Database;
        public string UserName;
        public string Pwd;
        public bool DomainAuth;
        public string TableName;
        public List<FieldSructure> FieldList;

        public DbHandler()
        {
            FieldList = new List<FieldSructure>();
        }

        // Функция получения строки подключения
        private string GetConnectionString()
        {
            if (DomainAuth)
            {
                return "server=" + ServerName + "; Integrated Security=true; database=" + Database + "; connection timeout=30";
            }
            else
            {
                return "user id=" + UserName + ";password=" + Pwd + "; server=" + ServerName + "; Trusted_Connection=false; database=" + Database + "; connection timeout=30";
            };
        }

        // Функция возвращает существует ли таблица
        private bool TableExists()
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                string queryText = "Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = @Schema And  TABLE_NAME = @TableName";
                using (SqlCommand command = new SqlCommand(queryText, con))
                {
                    command.Parameters.Add("Schema", SqlDbType.VarChar).Value = Schema;
                    command.Parameters.Add("TableName", SqlDbType.VarChar).Value = TableName;
                    SqlDataReader cursor = command.ExecuteReader();
                    if (!cursor.Read()) return true;
                    else return false;

                }
            }
        }

        // Функция полоучения скрипта создания таблицы
        private string GetScriptForTbl()
        {
            string queryText = "";
            // Проверим существует ли такая таблица. По результатам очистим или создадим таблицу
            if (TableExists())
            {
                queryText = "drop table [" + Schema + "].[" + TableName + "] \n";
            }
            queryText = queryText + "create table [" + Schema + "].[" + TableName + "] ( \n" +
                        "[key] integer identity, \n";
            foreach (FieldSructure field in FieldList)
            {
                queryText = queryText + " [" + field.FieldName + "] " + field.FieldType + " " + (field.NullInfo ?? "") + " \n";
            }
            queryText = queryText + "constraint PK_" + TableName + " primary key (key) \n" +
                        ")";
            return queryText;
        }

        // Процедура создания таблицы
        public void CreateTable()
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(GetScriptForTbl(), con))
                    command.ExecuteNonQuery();
            }
        }
    }

    public class FieldSructure
    {
        public string FieldName;
        public string FieldType;
        public string NullInfo;
    }
}
