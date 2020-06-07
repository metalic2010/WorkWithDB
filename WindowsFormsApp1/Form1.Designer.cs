namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.HMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusExport = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusExportCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimeJobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameACDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directoryFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorIDJobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorLogJobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoJobASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Main = new WindowsFormsApp1.DS_Main();
            this.infoJobASTableAdapter = new WindowsFormsApp1.TestDataSetTableAdapters.InfoJobASTableAdapter();
            this.tESTTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.TESTTableAdapter();
            this.StatusFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusFilterCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.HMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoJobASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // HMenu
            // 
            this.HMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.HMenu.Location = new System.Drawing.Point(0, 0);
            this.HMenu.Name = "HMenu";
            this.HMenu.Size = new System.Drawing.Size(800, 24);
            this.HMenu.TabIndex = 1;
            this.HMenu.Text = "HMenu";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортироватьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // экспортироватьToolStripMenuItem
            // 
            this.экспортироватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.dbfToolStripMenuItem});
            this.экспортироватьToolStripMenuItem.Name = "экспортироватьToolStripMenuItem";
            this.экспортироватьToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.экспортироватьToolStripMenuItem.Text = "Экспорт";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // dbfToolStripMenuItem
            // 
            this.dbfToolStripMenuItem.Name = "dbfToolStripMenuItem";
            this.dbfToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.dbfToolStripMenuItem.Text = "dbf";
            this.dbfToolStripMenuItem.Click += new System.EventHandler(this.dbfToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // CMenu
            // 
            this.CMenu.Name = "contextMenuStrip1";
            this.CMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Фильтровать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 381);
            this.panel2.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusFilter,
            this.StatusFilterCurrent,
            this.StatusExport,
            this.StatusExportCurrent});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusExport
            // 
            this.StatusExport.Name = "StatusExport";
            this.StatusExport.Size = new System.Drawing.Size(99, 17);
            this.StatusExport.Text = "Статус экспорта:";
            // 
            // StatusExportCurrent
            // 
            this.StatusExportCurrent.Name = "StatusExportCurrent";
            this.StatusExportCurrent.Size = new System.Drawing.Size(0, 17);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateTimeJobDataGridViewTextBoxColumn,
            this.nameACDataGridViewTextBoxColumn,
            this.operatorDataGridViewTextBoxColumn,
            this.directoryFileDataGridViewTextBoxColumn,
            this.errorIDJobDataGridViewTextBoxColumn,
            this.errorLogJobDataGridViewTextBoxColumn,
            this.transactMoneyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.infoJobASBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 381);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // dateTimeJobDataGridViewTextBoxColumn
            // 
            this.dateTimeJobDataGridViewTextBoxColumn.DataPropertyName = "DateTimeJob";
            this.dateTimeJobDataGridViewTextBoxColumn.HeaderText = "DateTimeJob";
            this.dateTimeJobDataGridViewTextBoxColumn.Name = "dateTimeJobDataGridViewTextBoxColumn";
            this.dateTimeJobDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameACDataGridViewTextBoxColumn
            // 
            this.nameACDataGridViewTextBoxColumn.DataPropertyName = "NameAC";
            this.nameACDataGridViewTextBoxColumn.HeaderText = "NameAC";
            this.nameACDataGridViewTextBoxColumn.Name = "nameACDataGridViewTextBoxColumn";
            this.nameACDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // operatorDataGridViewTextBoxColumn
            // 
            this.operatorDataGridViewTextBoxColumn.DataPropertyName = "Operator";
            this.operatorDataGridViewTextBoxColumn.HeaderText = "Operator";
            this.operatorDataGridViewTextBoxColumn.Name = "operatorDataGridViewTextBoxColumn";
            this.operatorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // directoryFileDataGridViewTextBoxColumn
            // 
            this.directoryFileDataGridViewTextBoxColumn.DataPropertyName = "DirectoryFile";
            this.directoryFileDataGridViewTextBoxColumn.HeaderText = "DirectoryFile";
            this.directoryFileDataGridViewTextBoxColumn.Name = "directoryFileDataGridViewTextBoxColumn";
            this.directoryFileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorIDJobDataGridViewTextBoxColumn
            // 
            this.errorIDJobDataGridViewTextBoxColumn.DataPropertyName = "ErrorIDJob";
            this.errorIDJobDataGridViewTextBoxColumn.HeaderText = "ErrorIDJob";
            this.errorIDJobDataGridViewTextBoxColumn.Name = "errorIDJobDataGridViewTextBoxColumn";
            this.errorIDJobDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorLogJobDataGridViewTextBoxColumn
            // 
            this.errorLogJobDataGridViewTextBoxColumn.DataPropertyName = "ErrorLogJob";
            this.errorLogJobDataGridViewTextBoxColumn.HeaderText = "ErrorLogJob";
            this.errorLogJobDataGridViewTextBoxColumn.Name = "errorLogJobDataGridViewTextBoxColumn";
            this.errorLogJobDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactMoneyDataGridViewTextBoxColumn
            // 
            this.transactMoneyDataGridViewTextBoxColumn.DataPropertyName = "TransactMoney";
            this.transactMoneyDataGridViewTextBoxColumn.HeaderText = "TransactMoney";
            this.transactMoneyDataGridViewTextBoxColumn.Name = "transactMoneyDataGridViewTextBoxColumn";
            this.transactMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // infoJobASBindingSource
            // 
            this.infoJobASBindingSource.DataMember = "InfoJobAS";
            this.infoJobASBindingSource.DataSource = this.DS_Main;
            // 
            // DS_Main
            // 
            this.DS_Main.DataSetName = "TestDataSet";
            this.DS_Main.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // infoJobASTableAdapter
            // 
            this.infoJobASTableAdapter.ClearBeforeFill = true;
            // 
            // tESTTableAdapter
            // 
            this.tESTTableAdapter.ClearBeforeFill = true;
            // 
            // StatusFilter
            // 
            this.StatusFilter.Name = "StatusFilter";
            this.StatusFilter.Size = new System.Drawing.Size(96, 17);
            this.StatusFilter.Text = "Статус фильтра:";
            // 
            // StatusFilterCurrent
            // 
            this.StatusFilterCurrent.Name = "StatusFilterCurrent";
            this.StatusFilterCurrent.Size = new System.Drawing.Size(146, 17);
            this.StatusFilterCurrent.Text = "Список не отфильтрован";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HMenu);
            this.MainMenuStrip = this.HMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.HMenu.ResumeLayout(false);
            this.HMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoJobASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip HMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DS_Main DS_Main;
        private System.Windows.Forms.BindingSource infoJobASBindingSource;
        private TestDataSetTableAdapters.InfoJobASTableAdapter infoJobASTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeJobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directoryFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorIDJobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorLogJobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem экспортироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbfToolStripMenuItem;
        private DataSet1TableAdapters.TESTTableAdapter tESTTableAdapter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusExport;
        private System.Windows.Forms.ToolStripStatusLabel StatusExportCurrent;
        private System.Windows.Forms.ToolStripStatusLabel StatusFilter;
        private System.Windows.Forms.ToolStripStatusLabel StatusFilterCurrent;
    }
}

