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
    public partial class WeightConverterForm : Form
    {
        public WeightConverterForm()
        {
            InitializeComponent();
            LoadUnits();
        }

        private void LoadUnits()
        {
            string[] units = { "Килограммы", "Граммы", "Фунты", "Унции" };
            cmbFromUnit1.Items.AddRange(units);
            cmbToUnit1.Items.AddRange(units);
            cmbFromUnit1.SelectedIndex = 0;
            cmbToUnit1.SelectedIndex = 1;
        }

        private void btnConvert1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtValue1.Text, out double inputValue))
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fromUnit = cmbFromUnit1.SelectedItem.ToString();
            string toUnit = cmbToUnit1.SelectedItem.ToString();

            // Базовая единица - килограмм
            double valueInKg = 0;
            switch (fromUnit)
            {
                case "Килограммы": valueInKg = inputValue; break;
                case "Граммы": valueInKg = inputValue / 1000; break;
                case "Фунты": valueInKg = inputValue * 0.453592; break;
                case "Унции": valueInKg = inputValue * 0.0283495; break;
            }

            double result = 0;
            switch (toUnit)
            {
                case "Килограммы": result = valueInKg; break;
                case "Граммы": result = valueInKg * 1000; break;
                case "Фунты": result = valueInKg / 0.453592; break;
                case "Унции": result = valueInKg / 0.0283495; break;
            }

            lblResult1.Text = $"Результат: {result:F4}";
        }
    }
}
