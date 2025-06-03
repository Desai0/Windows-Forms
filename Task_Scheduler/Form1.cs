using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Scheduler
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int GetPrioritySortValue(string priority)
        {
            switch (priority?.ToLower())
            {
                case "высокий":
                    return 0;
                case "средний":
                    return 1;
                case "низкий":
                    return 2;
                default:
                    return 3;
            }
        }


        private void RefreshListBox()
        {
            listBox1.Items.Clear();

            IEnumerable<KeyValuePair<string, string>> itemsToDisplay = dic;

            if (radioButton1.Checked || checkBox1.Checked)
            {
                itemsToDisplay = dic.Where(pair => (pair.Value == "Высокий") || (pair.Value == "Средний"));
                itemsToDisplay = dic.OrderBy(pair => GetPrioritySortValue(pair.Value));
            }

            if (radioButton1.Checked)
            {
                itemsToDisplay = dic.OrderBy(pair => GetPrioritySortValue(pair.Value));
            }

            if (checkBox1.Checked)
            {
                itemsToDisplay = dic.Where(pair => (pair.Value == "Высокий") || (pair.Value == "Средний"));
            }

            foreach (var d in itemsToDisplay)
            {
                listBox1.Items.Add($"{d.Key} | {d.Value}");
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string taskName = textBox1.Text.Trim();
            string priority = comboBox1.Text;

            if (string.IsNullOrWhiteSpace(taskName))
            {
                MessageBox.Show("Название задачи не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(priority))
            {
                MessageBox.Show("Выберите приоритет.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }

            if (dic.ContainsKey(taskName))
            {
                MessageBox.Show($"Задача с именем '{taskName}' уже существует. Выберите другое имя или отредактируйте существующую.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            dic.Add(taskName, priority);
            textBox1.Clear();

            RefreshListBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Clear();
                RefreshListBox();
            } else
            {
                textBox1.Clear();
                RefreshListBox();
            }
        }
    }
}