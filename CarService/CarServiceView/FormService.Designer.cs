namespace CarServiceView
{
	partial class FormService
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelPrice = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(27, 14);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(62, 15);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Название:";
			// 
			// labelPrice
			// 
			this.labelPrice.AutoSize = true;
			this.labelPrice.Location = new System.Drawing.Point(27, 73);
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Size = new System.Drawing.Size(38, 15);
			this.labelPrice.TabIndex = 1;
			this.labelPrice.Text = "Цена:";
			// 
			// textBoxName
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(127, 12);
			this.textBoxTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxTitle.Name = "textBoxName";
			this.textBoxTitle.Size = new System.Drawing.Size(263, 23);
			this.textBoxTitle.TabIndex = 2;
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(127, 70);
			this.textBoxPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(128, 23);
			this.textBoxPrice.TabIndex = 3;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(127, 116);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(82, 22);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(254, 116);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(82, 22);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// FormService
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 155);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.labelTitle);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FormService";
			this.Text = "Услуга";
			this.Load += new System.EventHandler(this.FormService_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label labelTitle;
		private Label labelPrice;
		private TextBox textBoxTitle;
		private TextBox textBoxPrice;
		private Button buttonSave;
		private Button buttonCancel;
	}
}