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
            TextLabel1 = new Label();
            TextBox1 = new TextBox();
            ComboLabel1 = new Label();
            comboBox3 = new ComboBox();
            AddButton = new Button();
            CancelButton = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            comboBox1 = new ComboBox();
            TextBox2 = new TextBox();
            TextLabel2 = new Label();
            TextBox3 = new TextBox();
            TextLabel3 = new Label();
            TextBox4 = new TextBox();
            TextLabel4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            DateLabel = new Label();
            comboBox2 = new ComboBox();
            ComboLabel2 = new Label();
            button2 = new Button();
            button1 = new Button();
            SicretTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // TextLabel1
            // 
            TextLabel1.AutoSize = true;
            TextLabel1.Location = new Point(393, 98);
            TextLabel1.Name = "TextLabel1";
            TextLabel1.Size = new Size(39, 15);
            TextLabel1.TabIndex = 0;
            TextLabel1.Text = "Name";
            TextLabel1.Visible = false;
            // 
            // TextBox1
            // 
            TextBox1.Location = new Point(393, 126);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(100, 23);
            TextBox1.TabIndex = 1;
            TextBox1.Visible = false;
            // 
            // ComboLabel1
            // 
            ComboLabel1.AutoSize = true;
            ComboLabel1.Location = new Point(393, 169);
            ComboLabel1.Name = "ComboLabel1";
            ComboLabel1.Size = new Size(40, 15);
            ComboLabel1.TabIndex = 2;
            ComboLabel1.Text = "Group";
            ComboLabel1.Visible = false;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(535, 196);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 3;
            comboBox3.Visible = false;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(393, 344);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 4;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(712, 344);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "Close";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(354, 267);
            dataGridView1.TabIndex = 21;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(393, 15);
            label3.Name = "label3";
            label3.Size = new Size(161, 15);
            label3.TabIndex = 22;
            label3.Text = "With what you want to work?";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(393, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 23;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // TextBox2
            // 
            TextBox2.Location = new Point(499, 126);
            TextBox2.Name = "TextBox2";
            TextBox2.Size = new Size(100, 23);
            TextBox2.TabIndex = 25;
            TextBox2.Visible = false;
            // 
            // TextLabel2
            // 
            TextLabel2.AutoSize = true;
            TextLabel2.Location = new Point(499, 98);
            TextLabel2.Name = "TextLabel2";
            TextLabel2.Size = new Size(39, 15);
            TextLabel2.TabIndex = 24;
            TextLabel2.Text = "Name";
            TextLabel2.Visible = false;
            // 
            // TextBox3
            // 
            TextBox3.Location = new Point(605, 126);
            TextBox3.Name = "TextBox3";
            TextBox3.Size = new Size(100, 23);
            TextBox3.TabIndex = 27;
            TextBox3.Visible = false;
            // 
            // TextLabel3
            // 
            TextLabel3.AutoSize = true;
            TextLabel3.Location = new Point(605, 98);
            TextLabel3.Name = "TextLabel3";
            TextLabel3.Size = new Size(39, 15);
            TextLabel3.TabIndex = 26;
            TextLabel3.Text = "Name";
            TextLabel3.Visible = false;
            // 
            // TextBox4
            // 
            TextBox4.Location = new Point(712, 126);
            TextBox4.Name = "TextBox4";
            TextBox4.Size = new Size(100, 23);
            TextBox4.TabIndex = 29;
            TextBox4.Visible = false;
            // 
            // TextLabel4
            // 
            TextLabel4.AutoSize = true;
            TextLabel4.Location = new Point(712, 98);
            TextLabel4.Name = "TextLabel4";
            TextLabel4.Size = new Size(39, 15);
            TextLabel4.TabIndex = 28;
            TextLabel4.Text = "Name";
            TextLabel4.Visible = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(393, 270);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 30;
            dateTimePicker1.Visible = false;
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(393, 242);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(31, 15);
            DateLabel.TabIndex = 31;
            DateLabel.Text = "Date";
            DateLabel.Visible = false;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(393, 196);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 32;
            comboBox2.Visible = false;
            // 
            // ComboLabel2
            // 
            ComboLabel2.AutoSize = true;
            ComboLabel2.Location = new Point(535, 169);
            ComboLabel2.Name = "ComboLabel2";
            ComboLabel2.Size = new Size(40, 15);
            ComboLabel2.TabIndex = 33;
            ComboLabel2.Text = "Group";
            ComboLabel2.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(605, 344);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 35;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(500, 344);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 34;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SicretTextBox
            // 
            SicretTextBox.Location = new Point(12, 380);
            SicretTextBox.Name = "SicretTextBox";
            SicretTextBox.Size = new Size(10, 23);
            SicretTextBox.TabIndex = 36;
            SicretTextBox.Visible = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 415);
            ControlBox = false;
            Controls.Add(SicretTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ComboLabel2);
            Controls.Add(comboBox2);
            Controls.Add(DateLabel);
            Controls.Add(dateTimePicker1);
            Controls.Add(TextBox4);
            Controls.Add(TextLabel4);
            Controls.Add(TextBox3);
            Controls.Add(TextLabel3);
            Controls.Add(TextBox2);
            Controls.Add(TextLabel2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(comboBox3);
            Controls.Add(ComboLabel1);
            Controls.Add(TextBox1);
            Controls.Add(TextLabel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form2";
            Text = "Student";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TextLabel1;
        private TextBox TextBox1;
        private Label ComboLabel1;
        private ComboBox comboBox3;
        private Button AddButton;
        private Button CancelButton;
        private DataGridView dataGridView1;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox TextBox2;
        private Label TextLabel2;
        private TextBox TextBox3;
        private Label TextLabel3;
        private TextBox TextBox4;
        private Label TextLabel4;
        private DateTimePicker dateTimePicker1;
        private Label DateLabel;
        private ComboBox comboBox2;
        private Label ComboLabel2;
        private Button button2;
        private Button button1;
        private TextBox SicretTextBox;
    }
}