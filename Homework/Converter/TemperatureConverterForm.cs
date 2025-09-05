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
    public partial class filePathLabel : Form
    {
        private string selectedFilePath;

        public filePathLabel()
        {
            InitializeComponent();
            //LoadUnits();
        }

        //private void LoadUnits()
        //{
        //    string[] units = { "Цельсий", "Фаренгейт", "Кельвин" };
        //    comboBox1.Items.AddRange(units);
        //    comboBox2.Items.AddRange(units);
        //    comboBox1.SelectedIndex = 0;
        //    comboBox2.SelectedIndex = 1;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Пожалуйста, сначала выберите файл с данными.", "Файл не выбран", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Читаем числа из файла
            int[] numbers;
            try
            {
                string fileContent = File.ReadAllText(selectedFilePath);
                // Разделяем строку на части по пробелам, табуляции и переносам строк,
                // убираем пустые элементы и преобразуем каждую часть в число.
                numbers = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл не найден. Возможно, он был перемещен или удален.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Файл содержит некорректные данные. Убедитесь, что в файле только числа, разделенные пробелами.", "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Если в файле нет чисел, выходим
            if (numbers.Length == 0)
            {
                resultRichTextBox.Text = "Файл пуст или не содержит чисел.";
                return;
            }

            // 3. Запускаем сортировку и получаем подробный лог
            StringBuilder log = new StringBuilder();
            log.AppendLine("Начальный массив: " + string.Join(", ", numbers));
            log.AppendLine("------------------------------------");
            log.AppendLine("Начинаем сортировку методом простого выбора:");

            SelectionSort(numbers, log); // Вызываем метод сортировки

            log.AppendLine("------------------------------------");
            log.AppendLine("Сортировка завершена!");
            log.AppendLine("Отсортированный массив: " + string.Join(", ", numbers));

            // 4. Выводим результат в RichTextBox
            resultRichTextBox.Text = log.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog1.Title = "Выберите текстовый файл с числами";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Сохраняем путь к файлу в нашу переменную
                selectedFilePath = openFileDialog1.FileName;

                // Показываем пользователю, какой файл он выбрал
                label3.Text = "Выбранный файл: " + Path.GetFileName(selectedFilePath);
                resultRichTextBox.Text = "Файл успешно выбран. Нажмите 'Сортировать' для начала.";

                this.Text = "Сортировка файла: " + Path.GetFileName(selectedFilePath);
            }
        }

        private void SelectionSort(int[] array, StringBuilder log)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                log.AppendLine($"\n--- Итерация {i + 1} (ищем элемент для позиции {i}) ---");
                log.AppendLine("Текущий массив: " + string.Join(", ", array));

                // Находим индекс минимального элемента в оставшейся части массива
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                log.AppendLine($"Найден минимальный элемент {array[minIndex]} на позиции {minIndex}.");

                // Если минимальный элемент не на своем месте, меняем его с текущим
                if (minIndex != i)
                {
                    log.AppendLine($"Меняем местами {array[i]} (на позиции {i}) и {array[minIndex]} (на позиции {minIndex}).");
                    int temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }
                else
                {
                    log.AppendLine("Минимальный элемент уже на своем месте.");
                }

                log.AppendLine("Массив после итерации: " + string.Join(", ", array));
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
