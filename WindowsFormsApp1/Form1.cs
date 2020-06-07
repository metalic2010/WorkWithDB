using System;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExportDBF.Classes;
using LogHelper.Classes;
using ChildJob.Classes;
using System.Threading;
using System.Collections.Generic;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// Создаём экземпляр класса DBFFileDG
        /// </summary>
        private DBFFileDG dbfFile = new DBFFileDG();

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
            // Загружаем данные в таблицу "DS_Main.InfoJobAS".
            infoJobASTableAdapter.Fill(DS_Main.InfoJobAS);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                comboBox1.Items.Add(dataGridView1.Columns[i].HeaderText);

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
            if (button1.Text == "Сбросить фильтр")
            {
                infoJobASBindingSource.Filter = null;
                button1.Text = "Фильтровать";
                textBox1.Text = "";
                comboBox1.SelectedIndex = 0;
                log.Write("Сброс фильтра");
                StatusFilterCurrent.Text = "Список не отфильтрован";
            }
            else
            {
                try
                {
                    string query = string.Empty;
                    string btext = string.Empty;
                    string vtypeStr = vtype.ToString();

                    //В зависимости от типа данных применются разные операторы фильтрации
                    if (vtypeStr == "System.String" | vtypeStr == "System.Text")
                    {
                        query = comboBox1.Text + $" like '%{textBox1.Text}%'";
                    }
                    else if (vtypeStr == "System.DateTime")
                    {
                        query = comboBox1.Text + $" = '{textBox1.Text}'";
                    }
                    else if (vtypeStr == "System.Int16" | vtypeStr == "System.Int32" | vtypeStr == "System.Int64")
                    {
                        query = comboBox1.Text + $" = {textBox1.Text}";
                    }
                    else if (vtypeStr == "System.Decimal" & button1.Text == "Фильтровать" & comboBox1.Text != "")
                    {
                        query = comboBox1.Text + $" >= '{textBox1.Text}'";
                        btext = "Фильтровать (>=)";
                    }
                    else if (vtypeStr == "System.Decimal" & button1.Text == "Фильтровать (>=)" & comboBox1.Text != "")
                    {
                        query = comboBox1.Text + $" <= '{textBox1.Text}'";
                    }

                    if (query != string.Empty)
                    {
                        infoJobASBindingSource.Filter = query;

                        if (btext != string.Empty)
                            button1.Text = btext;
                        else
                            button1.Text = "Сбросить фильтр";

                        log.Write($"Применён фильтр по столбцу: {comboBox1.Text}, введено значение: {textBox1.Text}");
                        StatusFilterCurrent.Text = "Список отфильтрован";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            string status = "";

            ChildJobCl jobCl = new ChildJobCl();

            jobCl.ThreadProc(
                new ThreadStart(() =>
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

                    status = "Выполнен экспорт в excel файл";

                    log.Write(status);
                    StatusExportCurrent.Text = status;
                    MessageBox.Show(status, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));

            status = "Экспортирую данные в excel, пожалуйста подождите...";

            log.Write(status);
            StatusExportCurrent.Text = status;
            MessageBox.Show(status, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Кнопка экспорта данных в dbf файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string status = "Экспортирую данные в dbf, пожалуйста подождите...";

            log.Write(status);
            StatusExportCurrent.Text = status;
            MessageBox.Show(status, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ChildJobCl jobCl = new ChildJobCl();

            jobCl.ThreadProc(
                new ThreadStart(() =>
                {
                    //Собираем информацию о столбцах
                    List<string[]> FieldInfo = dbfFile.GetFieldInfo(dataGridView1);

                    // Массив строк со значениями
                    string[] RowsVal = dbfFile.GetValuesConcat(dataGridView1);
                    //Возводим все поля в верхний регистр
                    string StrField = String.Join(", ", FieldInfo[0]).ToUpper();

                    try
                    {
                        dbfFile.CreateDBF("Test", FieldInfo[1]);

                        //Записываем в dbf файл данные
                        for (int i = 0; i < RowsVal.Count(); i++)
                            dbfFile.SetDBF($"INSERT INTO TEST.DBF ({StrField}) VALUES {RowsVal[i]}");

                        status = "Экспорт в dbf выполнен успешно.";

                        log.Write(status);
                        StatusExportCurrent.Text = status;
                        MessageBox.Show(status, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        status = "Не могу получить доступ к файлу, закройте все приложения и повторите операцию.";

                        log.Write(status);
                        StatusExportCurrent.Text = status;
                        MessageBox.Show($"{status}\r\nОшибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
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



