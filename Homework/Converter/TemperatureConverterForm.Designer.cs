using System.ComponentModel;

namespace Converter
{
    partial class filePathLabel
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            resultRichTextBox = new RichTextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(46, 187);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 239);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(46, 27);
            label2.Name = "label2";
            label2.Size = new Size(189, 32);
            label2.TabIndex = 5;
            label2.Text = "Простой выбор";
            label2.Click += label2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button2
            // 
            button2.Location = new Point(46, 84);
            button2.Name = "button2";
            button2.Size = new Size(99, 23);
            button2.TabIndex = 6;
            button2.Text = "Вставить файл";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // resultRichTextBox
            // 
            resultRichTextBox.Location = new Point(315, 27);
            resultRichTextBox.Name = "resultRichTextBox";
            resultRichTextBox.Size = new Size(421, 396);
            resultRichTextBox.TabIndex = 7;
            resultRichTextBox.Text = "";
            resultRichTextBox.TextChanged += richTextBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 133);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 8;
            label3.Text = "label3";
            // 
            // filePathLabel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 435);
            Controls.Add(label3);
            Controls.Add(resultRichTextBox);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "filePathLabel";
            Text = "TemperatureConverterForm";
            Load += TemperatureConverterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void TemperatureConverterForm_Load(object sender, EventArgs e)
        {
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        #endregion
        private Button button1;
        private Label label1;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private RichTextBox resultRichTextBox;
        private Label label3;
    }
}