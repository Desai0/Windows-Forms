using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Пирамидальная сортировка

namespace Converter
{
    public partial class AkimchikLoh : Form
    {
        private string selectedFilePath;

        // Add the following declaration for openFileDialog1 at the class level.  
        // This ensures that the openFileDialog1 object exists in the current context.  

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public AkimchikLoh()
        {
            InitializeComponent();
        }

        private void HeapSort(int[] array, StringBuilder log)
        {
            int n = array.Length;

            // 1. Построение первичной "max-кучи".
            // Превращаем массив в структуру, где каждый родительский элемент больше своих дочерних.
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i, log);
            }

            // 2. Извлечение элементов.
            // Многократно меняем местами корневой (максимальный) элемент с последним в куче,
            // уменьшаем размер кучи и восстанавливаем ее свойства.
            for (int i = n - 1; i > 0; i--)
            {
                int temp = array[0]; array[0] = array[i]; array[i] = temp;
                Heapify(array, i, 0, log);
            }
        }

        /// <summary>
        /// Вспомогательная функция для HeapSort. Превращает поддерево с корнем 'i' в max-кучу.
        /// Гарантирует, что самый большой элемент "всплывет" на позицию 'i'.
        /// </summary>
        private void Heapify(int[] array, int n, int i, StringBuilder log)
        {
            int largest = i;          // Предполагаем, что корень - самый большой
            int left = 2 * i + 1;     // Левый дочерний узел
            int right = 2 * i + 2;    // Правый дочерний узел

            // Если левый дочерний узел существует и он больше корня
            if (left < n && array[left] > array[largest]) largest = left;

            // Если правый дочерний узел существует и он больше текущего "самого большого"
            if (right < n && array[right] > array[largest]) largest = right;

            // Если самый большой элемент - не корень, то меняем их местами
            if (largest != i)
            {
                int swap = array[i]; array[i] = array[largest]; array[largest] = swap;

                // Рекурсивно вызываем для поддерева, чтобы "просеять" элемент дальше вниз
                Heapify(array, n, largest, log);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Пожалуйста, сначала выберите файл с данными.", "Файл не выбран", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] numbers;
            try
            {
                string fileContent = File.ReadAllText(selectedFilePath);
                numbers = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numbers.Length == 0)
            {
                resultRichTextBox.Text = "Файл пуст или не содержит чисел.";
                return;
            }

            StringBuilder log = new StringBuilder();
            // log.AppendLine("Начальный массив: " + string.Join(", ", numbers));
            // log.AppendLine("------------------------------------");
            // log.AppendLine("Начинаем сортировку выбором из дерева (Пирамидальная сортировка):");

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // Вызываем метод Пирамидальной сортировки
            HeapSort(numbers, log);

            stopwatch.Stop();

            // log.AppendLine("------------------------------------");
            log.AppendLine("Сортировка завершена!");
            log.AppendLine("Отсортированный массив: " + string.Join(", ", numbers));
            log.AppendLine();
            log.AppendLine($"Затраченное время: {stopwatch.ElapsedMilliseconds} мс ({stopwatch.Elapsed.TotalSeconds:F4} секунд).");

            resultRichTextBox.Text = log.ToString();
        }
    }
}
