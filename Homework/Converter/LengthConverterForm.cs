using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class LengthConverterForm : Form
    {

        public LengthConverterForm()
        {
            InitializeComponent();
            LoadUnits();
        }

        private void LoadUnits()
        {
            string[] units = { "Метры", "Километры", "Мили", "Футы", "Дюймы" };
            comboBox1.Items.AddRange(units);
            comboBox2.Items.AddRange(units);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double inputValue))
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fromUnit = comboBox1.SelectedItem.ToString();
            string toUnit = comboBox2.SelectedItem.ToString();

            double valueInMeters = 0;
            switch (fromUnit)
            {
                case "Метры": valueInMeters = inputValue; break;
                case "Километры": valueInMeters = inputValue * 1000; break;
                case "Мили": valueInMeters = inputValue * 1609.34; break;
                case "Футы": valueInMeters = inputValue * 0.3048; break;
                case "Дюймы": valueInMeters = inputValue * 0.0254; break;
            }

            double result = 0;
            switch (toUnit)
            {
                case "Метры": result = valueInMeters; break;
                case "Километры": result = valueInMeters / 1000; break;
                case "Мили": result = valueInMeters / 1609.34; break;
                case "Футы": result = valueInMeters / 0.3048; break;
                case "Дюймы": result = valueInMeters / 0.0254; break;
            }

            // 4. Вывод результата
            label1.Text = $"Результат: {result:F4}";
        }
    }
}
