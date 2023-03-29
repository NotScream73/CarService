namespace CarServiceView
{
	partial class FormClient
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
			labelName = new Label();
			labelPhone = new Label();
			textBoxName = new TextBox();
			textBoxPhone = new TextBox();
			buttonSave = new Button();
			buttonCancel = new Button();
			labelSurname = new Label();
			textBoxSurname = new TextBox();
			labelPatronymic = new Label();
			textBoxPatronymic = new TextBox();
			SuspendLayout();
			// 
			// labelName
			// 
			labelName.AutoSize = true;
			labelName.Location = new Point(27, 14);
			labelName.Name = "labelName";
			labelName.Size = new Size(34, 15);
			labelName.TabIndex = 0;
			labelName.Text = "Имя:";
			// 
			// labelPhone
			// 
			labelPhone.AutoSize = true;
			labelPhone.Location = new Point(20, 116);
			labelPhone.Name = "labelPhone";
			labelPhone.Size = new Size(101, 15);
			labelPhone.TabIndex = 1;
			labelPhone.Text = "Номер телефона";
			// 
			// textBoxName
			// 
			textBoxName.Location = new Point(127, 12);
			textBoxName.Margin = new Padding(3, 2, 3, 2);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(263, 23);
			textBoxName.TabIndex = 2;
			// 
			// textBoxPhone
			// 
			textBoxPhone.Location = new Point(127, 113);
			textBoxPhone.Margin = new Padding(3, 2, 3, 2);
			textBoxPhone.Name = "textBoxPhone";
			textBoxPhone.Size = new Size(263, 23);
			textBoxPhone.TabIndex = 3;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(127, 166);
			buttonSave.Margin = new Padding(3, 2, 3, 2);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(82, 22);
			buttonSave.TabIndex = 4;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(254, 166);
			buttonCancel.Margin = new Padding(3, 2, 3, 2);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(82, 22);
			buttonCancel.TabIndex = 5;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// labelSurname
			// 
			labelSurname.AutoSize = true;
			labelSurname.Location = new Point(27, 45);
			labelSurname.Name = "labelSurname";
			labelSurname.Size = new Size(61, 15);
			labelSurname.TabIndex = 6;
			labelSurname.Text = "Фамилия:";
			// 
			// textBoxSurname
			// 
			textBoxSurname.Location = new Point(127, 42);
			textBoxSurname.Margin = new Padding(3, 2, 3, 2);
			textBoxSurname.Name = "textBoxSurname";
			textBoxSurname.Size = new Size(263, 23);
			textBoxSurname.TabIndex = 7;
			// 
			// labelPatronymic
			// 
			labelPatronymic.AutoSize = true;
			labelPatronymic.Location = new Point(27, 78);
			labelPatronymic.Name = "labelPatronymic";
			labelPatronymic.Size = new Size(61, 15);
			labelPatronymic.TabIndex = 8;
			labelPatronymic.Text = "Отчество:";
			// 
			// textBoxPatronymic
			// 
			textBoxPatronymic.Location = new Point(127, 75);
			textBoxPatronymic.Margin = new Padding(3, 2, 3, 2);
			textBoxPatronymic.Name = "textBoxPatronymic";
			textBoxPatronymic.Size = new Size(263, 23);
			textBoxPatronymic.TabIndex = 9;
			// 
			// FormClient
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(454, 201);
			Controls.Add(textBoxPatronymic);
			Controls.Add(labelPatronymic);
			Controls.Add(textBoxSurname);
			Controls.Add(labelSurname);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSave);
			Controls.Add(textBoxPhone);
			Controls.Add(textBoxName);
			Controls.Add(labelPhone);
			Controls.Add(labelName);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormClient";
			Text = "Клиент";
			Load += FormClient_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelName;
		private Label labelPhone;
		private TextBox textBoxName;
		private TextBox textBoxPhone;
		private Button buttonSave;
		private Button buttonCancel;
		private Label labelSurname;
		private TextBox textBoxSurname;
		private Label labelPatronymic;
		private TextBox textBoxPatronymic;
	}
}