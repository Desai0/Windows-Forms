namespace Converter
{
    partial class LengthConverterForm
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
            label3 = new Label();
            resultRichTextBox = new RichTextBox();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 133);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 14;
            label3.Text = "label3";
            // 
            // resultRichTextBox
            // 
            resultRichTextBox.Location = new Point(324, 27);
            resultRichTextBox.Name = "resultRichTextBox";
            resultRichTextBox.Size = new Size(421, 396);
            resultRichTextBox.TabIndex = 13;
            resultRichTextBox.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(55, 89);
            button2.Name = "button2";
            button2.Size = new Size(99, 23);
            button2.TabIndex = 12;
            button2.Text = "Вставить файл";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(33, 16);
            label2.Name = "label2";
            label2.Size = new Size(308, 80);
            label2.TabIndex = 11;
            label2.Text = "Сортировка методом турнира с выбыванием";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 239);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(55, 187);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // LengthConverterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(resultRichTextBox);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "LengthConverterForm";
            Text = "LengthConverterForm";
            Load += LengthConverterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private RichTextBox resultRichTextBox;
        private Button button2;
        private Label label2;
        private Label label1;
        private Button button1;
    }
}