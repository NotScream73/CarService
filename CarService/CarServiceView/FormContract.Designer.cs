namespace CarServiceView
{
	partial class FormContract
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
			labelDate = new Label();
			labelPrice = new Label();
			textBoxPrice = new TextBox();
			groupBoxServices = new GroupBox();
			buttonRef = new Button();
			buttonDel = new Button();
			buttonUpd = new Button();
			buttonAdd = new Button();
			dataGridView = new DataGridView();
			ID = new DataGridViewTextBoxColumn();
			ColumnServiceTitle = new DataGridViewTextBoxColumn();
			ColumnPrice = new DataGridViewTextBoxColumn();
			buttonSave = new Button();
			buttonCancel = new Button();
			dateTimePicker1 = new DateTimePicker();
			labelClient = new Label();
			labelEmployee = new Label();
			labelCar = new Label();
			comboBoxCar = new ComboBox();
			comboBoxEmployee = new ComboBox();
			comboBoxClient = new ComboBox();
			groupBoxServices.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
			// 
			// labelDate
			// 
			labelDate.AutoSize = true;
			labelDate.Location = new Point(10, 7);
			labelDate.Name = "labelDate";
			labelDate.Size = new Size(35, 15);
			labelDate.TabIndex = 0;
			labelDate.Text = "Дата:";
			// 
			// labelPrice
			// 
			labelPrice.AutoSize = true;
			labelPrice.Location = new Point(10, 34);
			labelPrice.Name = "labelPrice";
			labelPrice.Size = new Size(70, 15);
			labelPrice.TabIndex = 1;
			labelPrice.Text = "Стоимость:";
			// 
			// textBoxPrice
			// 
			textBoxPrice.Enabled = false;
			textBoxPrice.Location = new Point(86, 29);
			textBoxPrice.Margin = new Padding(3, 2, 3, 2);
			textBoxPrice.Name = "textBoxPrice";
			textBoxPrice.Size = new Size(138, 23);
			textBoxPrice.TabIndex = 3;
			// 
			// groupBoxServices
			// 
			groupBoxServices.Controls.Add(buttonRef);
			groupBoxServices.Controls.Add(buttonDel);
			groupBoxServices.Controls.Add(buttonUpd);
			groupBoxServices.Controls.Add(buttonAdd);
			groupBoxServices.Controls.Add(dataGridView);
			groupBoxServices.Location = new Point(13, 62);
			groupBoxServices.Margin = new Padding(3, 2, 3, 2);
			groupBoxServices.Name = "groupBoxServices";
			groupBoxServices.Padding = new Padding(3, 2, 3, 2);
			groupBoxServices.Size = new Size(612, 206);
			groupBoxServices.TabIndex = 4;
			groupBoxServices.TabStop = false;
			groupBoxServices.Text = "Услуги";
			// 
			// buttonRef
			// 
			buttonRef.Location = new Point(456, 98);
			buttonRef.Margin = new Padding(3, 2, 3, 2);
			buttonRef.Name = "buttonRef";
			buttonRef.Size = new Size(136, 22);
			buttonRef.TabIndex = 4;
			buttonRef.Text = "Обновить";
			buttonRef.UseVisualStyleBackColor = true;
			buttonRef.Click += ButtonRef_Click;
			// 
			// buttonDel
			// 
			buttonDel.Location = new Point(456, 72);
			buttonDel.Margin = new Padding(3, 2, 3, 2);
			buttonDel.Name = "buttonDel";
			buttonDel.Size = new Size(136, 22);
			buttonDel.TabIndex = 3;
			buttonDel.Text = "Удалить";
			buttonDel.UseVisualStyleBackColor = true;
			buttonDel.Click += ButtonDel_Click;
			// 
			// buttonUpd
			// 
			buttonUpd.Location = new Point(456, 46);
			buttonUpd.Margin = new Padding(3, 2, 3, 2);
			buttonUpd.Name = "buttonUpd";
			buttonUpd.Size = new Size(136, 22);
			buttonUpd.TabIndex = 2;
			buttonUpd.Text = "Изменить";
			buttonUpd.UseVisualStyleBackColor = true;
			buttonUpd.Click += ButtonUpd_Click;
			// 
			// buttonAdd
			// 
			buttonAdd.Location = new Point(456, 20);
			buttonAdd.Margin = new Padding(3, 2, 3, 2);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(136, 22);
			buttonAdd.TabIndex = 1;
			buttonAdd.Text = "Добавить";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += ButtonAdd_Click;
			// 
			// dataGridView
			// 
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, ColumnServiceTitle, ColumnPrice });
			dataGridView.Location = new Point(5, 20);
			dataGridView.Margin = new Padding(3, 2, 3, 2);
			dataGridView.Name = "dataGridView";
			dataGridView.RowHeadersWidth = 51;
			dataGridView.RowTemplate.Height = 29;
			dataGridView.Size = new Size(429, 182);
			dataGridView.TabIndex = 0;
			// 
			// ID
			// 
			ID.HeaderText = "ID";
			ID.Name = "ID";
			ID.Visible = false;
			// 
			// ColumnServiceTitle
			// 
			ColumnServiceTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			ColumnServiceTitle.HeaderText = "Услуга";
			ColumnServiceTitle.MinimumWidth = 6;
			ColumnServiceTitle.Name = "ColumnServiceTitle";
			ColumnServiceTitle.Resizable = DataGridViewTriState.True;
			// 
			// ColumnPrice
			// 
			ColumnPrice.HeaderText = "Стоимость";
			ColumnPrice.MinimumWidth = 6;
			ColumnPrice.Name = "ColumnPrice";
			ColumnPrice.Width = 125;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(312, 284);
			buttonSave.Margin = new Padding(3, 2, 3, 2);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(136, 22);
			buttonSave.TabIndex = 5;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(469, 284);
			buttonCancel.Margin = new Padding(3, 2, 3, 2);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(136, 22);
			buttonCancel.TabIndex = 6;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Location = new Point(86, 2);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(200, 23);
			dateTimePicker1.TabIndex = 7;
			// 
			// labelClient
			// 
			labelClient.AutoSize = true;
			labelClient.Location = new Point(312, 7);
			labelClient.Name = "labelClient";
			labelClient.Size = new Size(49, 15);
			labelClient.TabIndex = 8;
			labelClient.Text = "Клиент:";
			// 
			// labelEmployee
			// 
			labelEmployee.AutoSize = true;
			labelEmployee.Location = new Point(312, 45);
			labelEmployee.Name = "labelEmployee";
			labelEmployee.Size = new Size(69, 15);
			labelEmployee.TabIndex = 9;
			labelEmployee.Text = "Сотрудник:";
			// 
			// labelCar
			// 
			labelCar.AutoSize = true;
			labelCar.Location = new Point(588, 10);
			labelCar.Name = "labelCar";
			labelCar.Size = new Size(58, 15);
			labelCar.TabIndex = 10;
			labelCar.Text = "Машина:";
			// 
			// comboBoxCar
			// 
			comboBoxCar.FormattingEnabled = true;
			comboBoxCar.Location = new Point(652, 7);
			comboBoxCar.Name = "comboBoxCar";
			comboBoxCar.Size = new Size(121, 23);
			comboBoxCar.TabIndex = 5;
			// 
			// comboBoxEmployee
			// 
			comboBoxEmployee.FormattingEnabled = true;
			comboBoxEmployee.Location = new Point(387, 42);
			comboBoxEmployee.Name = "comboBoxEmployee";
			comboBoxEmployee.Size = new Size(121, 23);
			comboBoxEmployee.TabIndex = 6;
			// 
			// comboBoxClient
			// 
			comboBoxClient.FormattingEnabled = true;
			comboBoxClient.Location = new Point(367, 5);
			comboBoxClient.Name = "comboBoxClient";
			comboBoxClient.Size = new Size(121, 23);
			comboBoxClient.TabIndex = 7;
			// 
			// FormContract
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(858, 327);
			Controls.Add(comboBoxEmployee);
			Controls.Add(comboBoxClient);
			Controls.Add(comboBoxCar);
			Controls.Add(labelCar);
			Controls.Add(labelEmployee);
			Controls.Add(labelClient);
			Controls.Add(dateTimePicker1);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSave);
			Controls.Add(groupBoxServices);
			Controls.Add(textBoxPrice);
			Controls.Add(labelPrice);
			Controls.Add(labelDate);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormContract";
			Text = "Контракт";
			Load += FormContract_Load;
			groupBoxServices.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelDate;
		private Label labelPrice;
		private TextBox textBoxPrice;
		private GroupBox groupBoxServices;
		private DataGridView dataGridView;
		private Button buttonRef;
		private Button buttonDel;
		private Button buttonUpd;
		private Button buttonAdd;
		private Button buttonSave;
		private Button buttonCancel;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn ColumnServiceTitle;
		private DataGridViewTextBoxColumn ColumnPrice;
		private DateTimePicker dateTimePicker1;
		private Label labelClient;
		private Label labelEmployee;
		private Label labelCar;
		private ComboBox comboBoxCar;
		private ComboBox comboBoxEmployee;
		private ComboBox comboBoxClient;
	}
}