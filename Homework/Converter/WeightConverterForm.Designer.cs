namespace Converter
{
    partial class WeightConverterForm
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
            btnConvert1 = new Button();
            cmbFromUnit1 = new ComboBox();
            cmbToUnit1 = new ComboBox();
            txtValue1 = new TextBox();
            lblResult1 = new Label();
            SuspendLayout();
            // 
            // btnConvert1
            // 
            btnConvert1.Location = new Point(38, 171);
            btnConvert1.Name = "btnConvert1";
            btnConvert1.Size = new Size(75, 23);
            btnConvert1.TabIndex = 0;
            btnConvert1.Text = "button1";
            btnConvert1.UseVisualStyleBackColor = true;
            btnConvert1.Click += btnConvert1_Click;
            // 
            // cmbFromUnit1
            // 
            cmbFromUnit1.FormattingEnabled = true;
            cmbFromUnit1.Location = new Point(38, 23);
            cmbFromUnit1.Name = "cmbFromUnit1";
            cmbFromUnit1.Size = new Size(121, 23);
            cmbFromUnit1.TabIndex = 1;
            // 
            // cmbToUnit1
            // 
            cmbToUnit1.FormattingEnabled = true;
            cmbToUnit1.Location = new Point(38, 72);
            cmbToUnit1.Name = "cmbToUnit1";
            cmbToUnit1.Size = new Size(121, 23);
            cmbToUnit1.TabIndex = 2;
            // 
            // txtValue1
            // 
            txtValue1.Location = new Point(38, 120);
            txtValue1.Name = "txtValue1";
            txtValue1.Size = new Size(100, 23);
            txtValue1.TabIndex = 3;
            // 
            // lblResult1
            // 
            lblResult1.AutoSize = true;
            lblResult1.Location = new Point(38, 227);
            lblResult1.Name = "lblResult1";
            lblResult1.Size = new Size(0, 15);
            lblResult1.TabIndex = 4;
            // 
            // WeightConverterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult1);
            Controls.Add(txtValue1);
            Controls.Add(cmbToUnit1);
            Controls.Add(cmbFromUnit1);
            Controls.Add(btnConvert1);
            Name = "WeightConverterForm";
            Text = "WeightConverterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConvert1;
        private ComboBox cmbFromUnit1;
        private ComboBox cmbToUnit1;
        private TextBox txtValue1;
        private Label lblResult1;
    }
}