namespace CarServiceView
{
	partial class FormTest
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
			buttonClient = new Button();
			labelClient = new Label();
			textBoxClientCount = new TextBox();
			textBoxEmployeeCount = new TextBox();
			labelEmployee = new Label();
			buttonEmployee = new Button();
			buttonService = new Button();
			textBoxCarCount = new TextBox();
			labelCar = new Label();
			buttonCar = new Button();
			textBoxContractCount = new TextBox();
			labelContract = new Label();
			buttonContract = new Button();
			SuspendLayout();
			// 
			// buttonClient
			// 
			buttonClient.Location = new Point(22, 56);
			buttonClient.Name = "buttonClient";
			buttonClient.Size = new Size(158, 23);
			buttonClient.TabIndex = 0;
			buttonClient.Text = "Сгенерировать клиентов";
			buttonClient.UseVisualStyleBackColor = true;
			buttonClient.Click += buttonClient_Click;
			// 
			// labelClient
			// 
			labelClient.AutoSize = true;
			labelClient.Location = new Point(22, 9);
			labelClient.Name = "labelClient";
			labelClient.Size = new Size(126, 15);
			labelClient.TabIndex = 1;
			labelClient.Text = "Количество клиентов";
			// 
			// textBoxClientCount
			// 
			textBoxClientCount.Location = new Point(22, 27);
			textBoxClientCount.Name = "textBoxClientCount";
			textBoxClientCount.Size = new Size(100, 23);
			textBoxClientCount.TabIndex = 2;
			// 
			// textBoxEmployeeCount
			// 
			textBoxEmployeeCount.Location = new Point(191, 27);
			textBoxEmployeeCount.Name = "textBoxEmployeeCount";
			textBoxEmployeeCount.Size = new Size(100, 23);
			textBoxEmployeeCount.TabIndex = 5;
			// 
			// labelEmployee
			// 
			labelEmployee.AutoSize = true;
			labelEmployee.Location = new Point(191, 9);
			labelEmployee.Name = "labelEmployee";
			labelEmployee.Size = new Size(145, 15);
			labelEmployee.TabIndex = 4;
			labelEmployee.Text = "Количество сотрудников";
			// 
			// buttonEmployee
			// 
			buttonEmployee.Location = new Point(191, 56);
			buttonEmployee.Name = "buttonEmployee";
			buttonEmployee.Size = new Size(171, 23);
			buttonEmployee.TabIndex = 3;
			buttonEmployee.Text = "Сгенерировать сотрудников";
			buttonEmployee.UseVisualStyleBackColor = true;
			buttonEmployee.Click += buttonEmployee_Click;
			// 
			// buttonService
			// 
			buttonService.Location = new Point(375, 12);
			buttonService.Name = "buttonService";
			buttonService.Size = new Size(171, 67);
			buttonService.TabIndex = 6;
			buttonService.Text = "Сгенерировать услуги";
			buttonService.UseVisualStyleBackColor = true;
			buttonService.Click += buttonService_Click;
			// 
			// textBoxCarCount
			// 
			textBoxCarCount.Location = new Point(22, 121);
			textBoxCarCount.Name = "textBoxCarCount";
			textBoxCarCount.Size = new Size(100, 23);
			textBoxCarCount.TabIndex = 9;
			// 
			// labelCar
			// 
			labelCar.AutoSize = true;
			labelCar.Location = new Point(22, 103);
			labelCar.Name = "labelCar";
			labelCar.Size = new Size(115, 15);
			labelCar.TabIndex = 8;
			labelCar.Text = "Количество машин";
			// 
			// buttonCar
			// 
			buttonCar.Location = new Point(22, 150);
			buttonCar.Name = "buttonCar";
			buttonCar.Size = new Size(158, 23);
			buttonCar.TabIndex = 7;
			buttonCar.Text = "Сгенерировать машины";
			buttonCar.UseVisualStyleBackColor = true;
			buttonCar.Click += buttonCar_Click;
			// 
			// textBoxContractCount
			// 
			textBoxContractCount.Location = new Point(191, 121);
			textBoxContractCount.Name = "textBoxContractCount";
			textBoxContractCount.Size = new Size(100, 23);
			textBoxContractCount.TabIndex = 12;
			// 
			// labelContract
			// 
			labelContract.AutoSize = true;
			labelContract.Location = new Point(191, 103);
			labelContract.Name = "labelContract";
			labelContract.Size = new Size(137, 15);
			labelContract.TabIndex = 11;
			labelContract.Text = "Количество контрактов";
			// 
			// buttonContract
			// 
			buttonContract.Location = new Point(191, 150);
			buttonContract.Name = "buttonContract";
			buttonContract.Size = new Size(171, 23);
			buttonContract.TabIndex = 10;
			buttonContract.Text = "Сгенерировать контракты";
			buttonContract.UseVisualStyleBackColor = true;
			buttonContract.Click += buttonContract_Click;
			// 
			// FormTest
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(textBoxContractCount);
			Controls.Add(labelContract);
			Controls.Add(buttonContract);
			Controls.Add(textBoxCarCount);
			Controls.Add(labelCar);
			Controls.Add(buttonCar);
			Controls.Add(buttonService);
			Controls.Add(textBoxEmployeeCount);
			Controls.Add(labelEmployee);
			Controls.Add(buttonEmployee);
			Controls.Add(textBoxClientCount);
			Controls.Add(labelClient);
			Controls.Add(buttonClient);
			Name = "FormTest";
			Text = "FormTest";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button buttonClient;
		private Label labelClient;
		private TextBox textBoxClientCount;
		private TextBox textBoxEmployeeCount;
		private Label labelEmployee;
		private Button buttonEmployee;
		private Button buttonService;
		private TextBox textBoxCarCount;
		private Label labelCar;
		private Button buttonCar;
		private TextBox textBoxContractCount;
		private Label labelContract;
		private Button buttonContract;
	}
}