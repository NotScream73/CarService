namespace CarServiceView
{
    partial class FormContracts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            справочникиToolStripMenuItem = new ToolStripMenuItem();
            CarsToolStripMenuItem = new ToolStripMenuItem();
            ClientsToolStripMenuItem = new ToolStripMenuItem();
            EmployeesToolStripMenuItem = new ToolStripMenuItem();
            ServicesToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            отчётToolStripMenuItem = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            buttonRef = new Button();
            buttonAdd = new Button();
            buttonMongo = new Button();
            buttonPostgres = new Button();
            buttonTransferData = new Button();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, testToolStripMenuItem, отчётToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(997, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "Справочники";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CarsToolStripMenuItem, ClientsToolStripMenuItem, EmployeesToolStripMenuItem, ServicesToolStripMenuItem });
            справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            справочникиToolStripMenuItem.Size = new Size(94, 20);
            справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // CarsToolStripMenuItem
            // 
            CarsToolStripMenuItem.Name = "CarsToolStripMenuItem";
            CarsToolStripMenuItem.Size = new Size(140, 22);
            CarsToolStripMenuItem.Text = "Машины";
            CarsToolStripMenuItem.Click += CarsToolStripMenuItem_Click;
            // 
            // ClientsToolStripMenuItem
            // 
            ClientsToolStripMenuItem.Name = "ClientsToolStripMenuItem";
            ClientsToolStripMenuItem.Size = new Size(140, 22);
            ClientsToolStripMenuItem.Text = "Клиенты";
            ClientsToolStripMenuItem.Click += ClientsToolStripMenuItem_Click;
            // 
            // EmployeesToolStripMenuItem
            // 
            EmployeesToolStripMenuItem.Name = "EmployeesToolStripMenuItem";
            EmployeesToolStripMenuItem.Size = new Size(140, 22);
            EmployeesToolStripMenuItem.Text = "Сотрудники";
            EmployeesToolStripMenuItem.Click += EmployeesToolStripMenuItem_Click;
            // 
            // ServicesToolStripMenuItem
            // 
            ServicesToolStripMenuItem.Name = "ServicesToolStripMenuItem";
            ServicesToolStripMenuItem.Size = new Size(140, 22);
            ServicesToolStripMenuItem.Text = "Услуги";
            ServicesToolStripMenuItem.Click += ServicesToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(42, 20);
            testToolStripMenuItem.Text = "Тест";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // отчётToolStripMenuItem
            // 
            отчётToolStripMenuItem.Name = "отчётToolStripMenuItem";
            отчётToolStripMenuItem.Size = new Size(51, 20);
            отчётToolStripMenuItem.Text = "Отчёт";
            отчётToolStripMenuItem.Click += отчётToolStripMenuItem_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 23);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(801, 305);
            dataGridView.TabIndex = 1;
            // 
            // buttonRef
            // 
            buttonRef.Location = new Point(817, 60);
            buttonRef.Margin = new Padding(3, 2, 3, 2);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(170, 22);
            buttonRef.TabIndex = 6;
            buttonRef.Text = "Обновить";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += ButtonRef_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(815, 34);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(170, 22);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "Добавить контракт";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // buttonMongo
            // 
            buttonMongo.Location = new Point(815, 303);
            buttonMongo.Name = "buttonMongo";
            buttonMongo.Size = new Size(168, 23);
            buttonMongo.TabIndex = 8;
            buttonMongo.Text = "MongoDB";
            buttonMongo.UseVisualStyleBackColor = true;
            buttonMongo.Click += buttonMongo_Click;
            // 
            // buttonPostgres
            // 
            buttonPostgres.Location = new Point(817, 274);
            buttonPostgres.Name = "buttonPostgres";
            buttonPostgres.Size = new Size(166, 23);
            buttonPostgres.TabIndex = 9;
            buttonPostgres.Text = "PostgreSQL";
            buttonPostgres.UseVisualStyleBackColor = true;
            buttonPostgres.Click += buttonPostgres_Click;
            // 
            // buttonTransferData
            // 
            buttonTransferData.Location = new Point(817, 245);
            buttonTransferData.Name = "buttonTransferData";
            buttonTransferData.Size = new Size(166, 23);
            buttonTransferData.TabIndex = 10;
            buttonTransferData.Text = "Перенести данные";
            buttonTransferData.UseVisualStyleBackColor = true;
            buttonTransferData.Click += buttonTransferData_Click;
            // 
            // FormContracts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 338);
            Controls.Add(buttonTransferData);
            Controls.Add(buttonPostgres);
            Controls.Add(buttonMongo);
            Controls.Add(buttonAdd);
            Controls.Add(buttonRef);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormContracts";
            Text = "Контракты";
            Load += FormContracts_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem CarsToolStripMenuItem;
        private ToolStripMenuItem ClientsToolStripMenuItem;
        private DataGridView dataGridView;
        private Button buttonRef;
        private ToolStripMenuItem EmployeesToolStripMenuItem;
        private ToolStripMenuItem ServicesToolStripMenuItem;
        private Button buttonAdd;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem отчётToolStripMenuItem;
        private Button buttonMongo;
        private Button buttonPostgres;
        private Button buttonTransferData;
    }
}