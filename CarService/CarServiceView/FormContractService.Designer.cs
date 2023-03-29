namespace CarServiceView
{
	partial class FormContractService
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
			labelService = new Label();
			labelPrice = new Label();
			comboBoxService = new ComboBox();
			textBoxPrice = new TextBox();
			buttonSave = new Button();
			buttonCancel = new Button();
			SuspendLayout();
			// 
			// labelService
			// 
			labelService.AutoSize = true;
			labelService.Location = new Point(22, 20);
			labelService.Name = "labelService";
			labelService.Size = new Size(47, 15);
			labelService.TabIndex = 0;
			labelService.Text = "Услуга:";
			// 
			// labelPrice
			// 
			labelPrice.AutoSize = true;
			labelPrice.Location = new Point(22, 70);
			labelPrice.Name = "labelPrice";
			labelPrice.Size = new Size(38, 15);
			labelPrice.TabIndex = 1;
			labelPrice.Text = "Цена:";
			// 
			// comboBoxService
			// 
			comboBoxService.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxService.FormattingEnabled = true;
			comboBoxService.Location = new Point(128, 20);
			comboBoxService.Margin = new Padding(3, 2, 3, 2);
			comboBoxService.Name = "comboBoxService";
			comboBoxService.Size = new Size(282, 23);
			comboBoxService.TabIndex = 2;
			comboBoxService.SelectedIndexChanged += comboBoxService_SelectedIndexChanged;
			// 
			// textBoxPrice
			// 
			textBoxPrice.Enabled = false;
			textBoxPrice.Location = new Point(128, 68);
			textBoxPrice.Margin = new Padding(3, 2, 3, 2);
			textBoxPrice.Name = "textBoxPrice";
			textBoxPrice.Size = new Size(282, 23);
			textBoxPrice.TabIndex = 3;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(128, 111);
			buttonSave.Margin = new Padding(3, 2, 3, 2);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(125, 22);
			buttonSave.TabIndex = 4;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(284, 111);
			buttonCancel.Margin = new Padding(3, 2, 3, 2);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(125, 22);
			buttonCancel.TabIndex = 5;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// FormContractService
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(447, 142);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSave);
			Controls.Add(textBoxPrice);
			Controls.Add(comboBoxService);
			Controls.Add(labelPrice);
			Controls.Add(labelService);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormContractService";
			Text = "Услуга контракта";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelService;
		private Label labelPrice;
		private ComboBox comboBoxService;
		private TextBox textBoxPrice;
		private Button buttonSave;
		private Button buttonCancel;
	}
}