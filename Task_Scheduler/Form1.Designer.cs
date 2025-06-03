namespace Task_Scheduler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            checkBox1 = new CheckBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightCyan;
            textBox1.Location = new Point(26, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Source Code Pro Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 15);
            label2.Name = "label2";
            label2.Size = new Size(172, 24);
            label2.TabIndex = 2;
            label2.Text = "Создать задачу";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.LightCyan;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Высокий", "Средний", "Низкий" });
            comboBox1.Location = new Point(26, 106);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Azure;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(494, 15);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(488, 274);
            listBox1.TabIndex = 4;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Cursor = Cursors.Hand;
            radioButton1.Font = new Font("Source Code Pro Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton1.Location = new Point(47, 14);
            radioButton1.Name = "radioButton1";
            radioButton1.RightToLeft = RightToLeft.Yes;
            radioButton1.Size = new Size(142, 21);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "По приоритету";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Cursor = Cursors.Hand;
            radioButton2.Font = new Font("Source Code Pro Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton2.Location = new Point(3, 41);
            radioButton2.Name = "radioButton2";
            radioButton2.RightToLeft = RightToLeft.Yes;
            radioButton2.Size = new Size(186, 21);
            radioButton2.TabIndex = 6;
            radioButton2.Text = "По дате добавления";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.PowderBlue;
            checkBox1.FlatStyle = FlatStyle.System;
            checkBox1.Font = new Font("Source Code Pro Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(325, 89);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(150, 22);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Только важные";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.PowderBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Source Code Pro Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(26, 151);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 8;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Font = new Font("Source Code Pro Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(286, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(202, 78);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Сортировка";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.лес;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(994, 395);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox1;
        private ListBox listBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private CheckBox checkBox1;
        private Button button1;
        private GroupBox groupBox1;
    }
}
