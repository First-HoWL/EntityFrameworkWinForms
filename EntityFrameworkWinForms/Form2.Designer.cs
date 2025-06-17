namespace EntityFrameworkWinForms
{
    partial class Form2
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
            AddButton = new Button();
            CancelButton = new Button();
            comboPatientBox = new ComboBox();
            comboDoctorBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(41, 130);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 0;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(200, 130);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // comboPatientBox
            // 
            comboPatientBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPatientBox.FormattingEnabled = true;
            comboPatientBox.Location = new Point(41, 68);
            comboPatientBox.Name = "comboPatientBox";
            comboPatientBox.Size = new Size(121, 23);
            comboPatientBox.TabIndex = 2;
            comboPatientBox.SelectedIndexChanged += comboPatientBox_SelectedIndexChanged;
            // 
            // comboDoctorBox
            // 
            comboDoctorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDoctorBox.FormattingEnabled = true;
            comboDoctorBox.Location = new Point(200, 68);
            comboDoctorBox.Name = "comboDoctorBox";
            comboDoctorBox.Size = new Size(121, 23);
            comboDoctorBox.TabIndex = 3;
            comboDoctorBox.SelectedIndexChanged += comboDoctorBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 37);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 4;
            label1.Text = "Patient";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 37);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 5;
            label2.Text = "Doctor";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 220);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboDoctorBox);
            Controls.Add(comboPatientBox);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddButton;
        private Button CancelButton;
        private ComboBox comboPatientBox;
        private ComboBox comboDoctorBox;
        private Label label1;
        private Label label2;
    }
}