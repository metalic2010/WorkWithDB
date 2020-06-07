using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExportDBF.Classes;
using LogHelper.Classes;
using ChildJob.Classes;
using System.Threading;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// Создаём экземпляр класса DBFFile
        /// </summary>
        private DBFFile dbfFile = new DBFFile();

        /// <summary>
        /// Создаём экземпляр класса log
        /// </summary>
        private Log log = new Log();

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Определяем метод загрузки формы и объявляем заполнение
        /// datagridview и выбор полей для фильтрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Загружаем данные в таблицу "testDataSet.InfoJobAS".
            infoJobASTableAdapter.Fill(DS_Main.InfoJobAS);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                comboBox1.Items.Add(dataGridView1.Columns[i].HeaderText);
            }

            comboBox1.SelectedIndex = 0;

            log.Write("Открытие программы");

        }

        /// <summary>
        /// Кнопка фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Переменная с типом данных по которому будем осуществлять фильтрацию
            var vtype = dataGridView1.Columns[comboBox1.Text + "DataGridViewTextBoxColumn"].ValueType;

            //Проверяем заполнено ли поле для фильтрации, если нет, то сбрасываем фильтр
            if ((textBox1.Text == ""))
            {
                infoJobASBindingSource.Filter = null;
                button1.Text = "Фильтровать";
                log.Write("Сброс фильтра");
            }
            else
            {
                try
                {
                    //В зависимости от типа данных применются разные операторы фильтрации
                    if ((vtype.ToString() == "System.String") | (vtype.ToString() == "System.Text"))
                    {
                        infoJobASBindingSource.Filter = comboBox1.Text + $" like '%{textBox1.Text}%'";
                    }
                    else
                    {
                        if (vtype.ToString() == "System.DateTime")
                        {
                            infoJobASBindingSource.Filter = comboBox1.Text + $" = '{textBox1.Text}'";
                        }
                        else
                        {
                            if ((vtype.ToString() == "System.Int16") | (vtype.ToString() == "System.Int32") | (vtype.ToString() == "System.Int64"))
                            {
                                infoJobASBindingSource.Filter = comboBox1.Text + $" = {textBox1.Text}";
                            }
                            else
                            {
                                if ((vtype.ToString() == "System.Decimal") & (button1.Text == "Фильтровать"))
                                {
                                    infoJobASBindingSource.Filter = comboBox1.Text + $" >= '{textBox1.Text}'";
                                    button1.Text = "Фильтровать (>=)";
                                }
                                else
                                {
                                    infoJobASBindingSource.Filter = comboBox1.Text + $" <= '{textBox1.Text}'";
                                    button1.Text = "Фильтровать (<=)";
                                }
                            }
                        }
                    }

                    log.Write($"Применён фильтр по столбцу: {comboBox1.Text}, введено значение: {textBox1.Text}");
                }
                catch { }


            }

        }

        /// <summary>
        /// Кнопка выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            log.Write("Произведён выход из программы");
        }

        /// <summary>
        /// Кнопка экспорта данных в Excel файл,
        /// далее можно сохранить в форматы CSV,XLS,XSLX или другие
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add(Type.Missing);
            exApp.Columns.ColumnWidth = 15;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                exApp.Cells[1, 1 + i] = dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    exApp.Cells[j + 2, i + 1] = (dataGridView1[i, j].Value).ToString();
                }
            }
            exApp.Visible = true;

            log.Write("Выполнен экспорт в excel файл");
        }

        /// <summary>
        /// Кнопка экспорта данных в dbf файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Количество столбцов
            int ColCount = dataGridView1.ColumnCount;
            // Количество значений
            int RowCount = dataGridView1.RowCount;

            // Имена столбцов с их типами
            string[] FieldsT = new string[ColCount];
            // Имена столбцов
            string[] Fields = new string[ColCount];
            // Массив строк со значениями
            string[] RowsVal = new string[RowCount];

            //Заполняем массивы для SQL запросов
            for (int i = 0; i < ColCount; i++)
            {
                string CurFieldType = ((dataGridView1.Columns[i].ValueType).ToString()).Replace("System.", "");

                if ((CurFieldType == "Int16") | (CurFieldType == "Int32") | (CurFieldType == "Int64")) { CurFieldType = "int"; };
                if (CurFieldType == "String") { CurFieldType = "varchar(254)"; };
                if (CurFieldType == "Text") { CurFieldType = "varchar(254)"; };
                if (CurFieldType == "Decimal") { CurFieldType = "Double"; };
                if (CurFieldType == "DateTime") { CurFieldType = "TimeStamp"; };

                FieldsT[i] = (dataGridView1.Columns[i].HeaderText.ToString() + " " + CurFieldType);
                Fields[i] = (dataGridView1.Columns[i].HeaderText.ToString());

                if (Fields[i].Length > 10) { Fields[i] = Fields[i].Substring(0, 10); };
            }

            try
            {
                //Проверяем существование файла, если он существует, то удаляем и записываем новый
                if (File.Exists("Test.dbf")) { File.Delete("Test.dbf"); };

                dbfFile.CreateDBF("Test", FieldsT);

                int ri = 0;

                //Производим парсинг данных для приведения к нужному виду
                foreach (DataGridViewRow CurCellsVal in dataGridView1.Rows)
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

                //Возводим все поля в верхний регистр
                string StrField = String.Join(", ", Fields).ToUpper();

                //Записываем в dbf файл данные
                for (int i = 0; i < RowsVal.Count(); i++)
                    dbfFile.SetDBF($"INSERT INTO TEST.DBF ({StrField}) VALUES {RowsVal[i]}");

                log.Write("Выполнен экспорт в dbf файл");
            }
            catch { MessageBox.Show("Не могу получить доступ к файлу, закройте все приложения и повторите операцию"); }

        }

        /// <summary>
        /// Описываем метод закрытия (пишем лог)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Write("Произведён выход из программы");
        }

        /// <summary>
        /// Описываем метод клика по именованию столбца (пишем лог)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            log.Write($"Выполнена сортировка по столбцу: {dataGridView1.Columns[dataGridView1.SortedColumn.Index].HeaderText.ToString()}");
        }

    }
}



