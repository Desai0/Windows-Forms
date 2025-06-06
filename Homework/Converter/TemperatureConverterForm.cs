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
    public partial class TemperatureConverterForm : Form
    {

        public TemperatureConverterForm()
        {
            InitializeComponent();
            LoadUnits();
        }

        private void LoadUnits()
        {
            string[] units = { "Цельсий", "Фаренгейт", "Кельвин" };
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

            // Базовая единица - Цельсий
            double valueInCelsius = 0;
            switch (fromUnit)
            {
                case "Цельсий": valueInCelsius = inputValue; break;
                case "Фаренгейт": valueInCelsius = (inputValue - 32) * 5 / 9; break;
                case "Кельвин": valueInCelsius = inputValue - 273.15; break;
            }

            double result = 0;
            switch (toUnit)
            {
                case "Цельсий": result = valueInCelsius; break;
                case "Фаренгейт": result = (valueInCelsius * 9 / 5) + 32; break;
                case "Кельвин": result = valueInCelsius + 273.15; break;
            }

            label1.Text = $"Результат: {result:F2}";
        }
    }
}
