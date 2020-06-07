using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Odbc;
using IExDBF = IExportDBF.Interfaces;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Просатрнство имён, в нём создан класс с методами
/// для чтения и записи dbf файла
/// </summary>
namespace ExportDBF.Classes
{
    /// <summary>
    /// Базовый класс с основными методами
    /// </summary>
    public class DBFFile : IExDBF.IExportDBF
    {
        /// <summary>
        /// Создание соединения для dbf
        /// </summary>
        private static readonly OdbcConnection Conn = new OdbcConnection(@"Driver={Microsoft dBASE Driver (*.dbf)};
                                                                           SourceType=DBF;Exclusive=No;
                                                                           Collate=Machine;NULL=NO;DELETED=NO;
                                                                           BACKGROUNDFETCH=NO;");
        /// <summary>
        /// Метод для выполнения комманд
        /// </summary>
        /// <param name="Command">Строка - команда sql</param>
        /// <returns>Возврщает DataTable</returns>
        private DataTable Execute(string Command)
        {
            DataTable dt = null;

            try
            {
                Conn.Open();
                dt = new DataTable();
                OdbcCommand oCmd = Conn.CreateCommand();
                oCmd.CommandText = Command;
                dt.Load(oCmd.ExecuteReader());
                Conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return dt;
        }

        /// <summary>
        /// Запись в dbf файл
        /// </summary>
        /// <param name="SQLQuery">Строка - команда sql</param>
        public void SetDBF(string SQLQuery)
        {
            Execute(SQLQuery);
        }

        /// <summary>
        /// Чтение из DBF файла
        /// </summary>
        /// <param name="SQLQuery">Строка - команда sql</param>
        /// <returns>Возврщает DataTable</returns>
        public DataTable GetDBF(string SQLQuery)
        {
            return Execute(SQLQuery);
        }

        /// <summary>
        /// Создаёт DBF таблицу
        /// </summary>
        /// <param name="name">Имя будущей таблицы</param>
        /// <param name="Fields">Наименования столбцов и их тип</param>
        /// <returns>Возвращает DataTable</returns>
        public void CreateDBF(string name, string[] Fields)
        {
            //Проверяем существование файла, если он существует, то удаляем и записываем новый
            if (File.Exists($"{name}.dbf")) { File.Delete($"{name}.dbf"); };

            //объявляем команду создания новой таблички dbf
            Execute($@"CREATE TABLE [{name}] ({String.Join(", ", Fields)})");
        }
    }

    /// <summary>
    /// Класс наследник с расширенными методами
    /// </summary>
    public class DBFFileDG : DBFFile, IExDBF.IExportDBFDataGrid
    {
        /// <summary>
        /// Получение информации о именах столбцов и их типах
        /// </summary>
        /// <param name="dataGridView">Получаем объект таблицы</param>
        /// <returns>
        /// Возвращает список, индексы:
        /// 0 - просто список имён
        /// 1 - список имён с конкатенацией типа
        /// </returns>
        public List<string[]> GetFieldInfo(DataGridView dataGridView)
        {
            // Количество столбцов
            int ColCount = dataGridView.ColumnCount;

            List<string[]> FieldInfo = new List<string[]>();

            string[] Fields = new string[ColCount];
            string[] FieldsT = new string[ColCount];

            for (int i = 0; i < ColCount; i++)
            {
                string CurFieldType = ((dataGridView.Columns[i].ValueType).ToString()).Replace("System.", "");

                if ((CurFieldType == "Int16") | (CurFieldType == "Int32") | (CurFieldType == "Int64")) { CurFieldType = "int"; };
                if (CurFieldType == "String") { CurFieldType = "varchar(254)"; };
                if (CurFieldType == "Text") { CurFieldType = "varchar(254)"; };
                if (CurFieldType == "Decimal") { CurFieldType = "Double"; };
                if (CurFieldType == "DateTime") { CurFieldType = "TimeStamp"; };

                FieldsT[i] = (dataGridView.Columns[i].HeaderText.ToString() + " " + CurFieldType);
                Fields[i] = (dataGridView.Columns[i].HeaderText.ToString());

                if (Fields[i].Length > 10) { Fields[i] = Fields[i].Substring(0, 10); };
            }

            FieldInfo.Add(Fields);
            FieldInfo.Add(FieldsT);

            return FieldInfo;
        }

        /// <summary>
        /// Собирает значения и производит их слияние
        /// </summary>
        /// <param name="dataGridView">Получаем объект таблицы</param>
        /// <returns>Возвращает список</returns>
        public string[] GetValuesConcat(DataGridView dataGridView)
        {
            // Количество столбцов
            int ColCount = dataGridView.ColumnCount;
            // Количество значений
            int RowCount = dataGridView.RowCount;

            // Массив строк со значениями
            string[] RowsVal = new string[RowCount];

            int ri = 0;

            //Производим парсинг данных для приведения к нужному виду
            foreach (DataGridViewRow CurCellsVal in dataGridView.Rows)
            {
                string[] ColsVal = new string[ColCount];
                for (int i = 0; i < ColCount; i++)
                {
                    if ((CurCellsVal.Cells[i].ValueType.ToString()).Replace("System.", "") == "String" |
                        (CurCellsVal.Cells[i].ValueType.ToString()).Replace("System.", "") == "DateTime" |
                        (CurCellsVal.Cells[i].ValueType.ToString()).Replace("System.", "") == "Text" |
                        (CurCellsVal.Cells[i].ValueType.ToString()).Replace("System.", "") == "Decimal")
                    { ColsVal[i] = "'" + CurCellsVal.Cells[i].Value.ToString() + "'"; }
                    if ((CurCellsVal.Cells[i].ValueType.ToString()).Replace("System.", "") == "Int16" |
                        (CurCellsVal.Cells[i].ValueType.ToString()).Replace("System.", "") == "Int32" |
                        (CurCellsVal.Cells[i].ValueType.ToString()).Replace("System.", "") == "Int64")
                    { ColsVal[i] = CurCellsVal.Cells[i].Value.ToString(); }

                }

                RowsVal[ri] = $"({String.Join(", ", ColsVal)})";
                ColsVal = null;
                ri++;
            }

            return RowsVal;
        }
    }

}
