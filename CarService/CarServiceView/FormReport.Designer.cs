namespace CarServiceView
{
	partial class FormReport
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.buttonRef = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(10, 9);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 51;
			this.dataGridView.RowTemplate.Height = 29;
			this.dataGridView.Size = new System.Drawing.Size(444, 320);
			this.dataGridView.TabIndex = 0;
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(471, 88);
			this.buttonRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(133, 22);
			this.buttonRef.TabIndex = 4;
			this.buttonRef.Text = "Обновить";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// FormReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 338);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.dataGridView);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FormReport";
			this.Text = "Отчёты";
			this.Load += new System.EventHandler(this.FormReport_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonRef;
	}
}