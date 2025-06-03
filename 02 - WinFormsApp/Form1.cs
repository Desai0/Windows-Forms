namespace _02___WinFormsApp
{
    public partial class Form1 : Form
    {
        int counter = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            label1.Text = $"Счетчик: {counter}";

            switch (counter % 4)
            {
                case 1:
                    this.BackColor = Color.AliceBlue;
                    break;
                case 2:
                    this.BackColor = Color.AntiqueWhite;
                    break;
                case 3:
                    this.BackColor = Color.Aquamarine;
                    break;
                case 0:
                    this.BackColor = Color.White;
                    break;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if ((checkBox1.Checked == true))
            {
                label2.Text = $"Добрый день {textBox1.Text}";
            }
            else
            {
                label2.Text = $"Пожалуйста, введите имя";
            }
        }
    }
}
