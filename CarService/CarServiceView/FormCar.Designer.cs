namespace CarServiceView
{
	partial class FormCar
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
			this.labelNumber = new System.Windows.Forms.Label();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelAdditiveName
			// 
			this.labelNumber.AutoSize = true;
			this.labelNumber.Location = new System.Drawing.Point(27, 14);
			this.labelNumber.Name = "labelAdditiveName";
			this.labelNumber.Size = new System.Drawing.Size(62, 15);
			this.labelNumber.TabIndex = 0;
			this.labelNumber.Text = "Номер машины:";
			// 
			// textBoxName
			// 
			this.textBoxNumber.Location = new System.Drawing.Point(127, 12);
			this.textBoxNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxNumber.Name = "textBoxName";
			this.textBoxNumber.Size = new System.Drawing.Size(263, 23);
			this.textBoxNumber.TabIndex = 2;
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
			// FormAdditive
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 155);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxNumber);
			this.Controls.Add(this.labelNumber);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FormCar";
			this.Text = "Машина";
			this.Load += new System.EventHandler(this.FormCar_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label labelNumber;
		private TextBox textBoxNumber;
		private Button buttonSave;
		private Button buttonCancel;
	}
}