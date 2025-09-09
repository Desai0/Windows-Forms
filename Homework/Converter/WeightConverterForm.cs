using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Квадратичный выбор

namespace Converter
{
    public partial class filePathLabel1 : Form
    {
        private string selectedFilePath;

        // Add the following declaration for openFileDialog1 at the class level.  
        // This ensures that the openFileDialog1 object exists in the current context.  

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public filePathLabel1()
        {
            InitializeComponent();
            //LoadUnits();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // 1. Проверяем, был ли вообще выбран файл
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

            // 3. Запускаем сортировку, замеряем время и получаем лог
            StringBuilder log = new StringBuilder();
            // log.AppendLine("Начальный массив: " + string.Join(", ", numbers));
            // log.AppendLine("------------------------------------");
            // log.AppendLine("Начинаем квадратичную сортировку выбором:");

            // Создаем и запускаем таймер
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // Вызываем новый метод сортировки
            SelectionSort(numbers, log);

            // Останавливаем таймер
            stopwatch.Stop();

            // log.AppendLine("------------------------------------");
            log.AppendLine("Сортировка завершена!");
            log.AppendLine("Отсортированный массив: " + string.Join(", ", numbers));
            log.AppendLine(); // Пустая строка для разделения
            log.AppendLine($"Затраченное время: {stopwatch.ElapsedMilliseconds} мс ({stopwatch.Elapsed.TotalSeconds:F4} секунд).");

            // 4. Выводим результат в RichTextBox
            resultRichTextBox.Text = log.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        /// <summary>
        /// Сортирует массив методом квадратичного выбора (поиском минимума и максимума)
        /// и записывает подробный лог процесса.
        /// </summary>
        /// <param name="array">Массив для сортировки.</param>
        /// <param name="log">Объект StringBuilder для записи лога.</param>
        private void SelectionSort(int[] array, StringBuilder log)
        {
            int left = 0;
            int right = array.Length - 1;

            // Цикл продолжается, пока левый и правый указатели не встретятся
            for (int i = 0; left < right; i++)
            {
                int minIndex = left;
                int maxIndex = right;

                // В одном проходе ищем индекс минимального и максимального элементов
                for (int j = left; j <= right; j++)
                {
                    if (array[j] < array[minIndex]) minIndex = j;
                    if (array[j] > array[maxIndex]) maxIndex = j;
                }

                // Ставим найденный минимум в начало текущего диапазона
                int tempMin = array[left]; array[left] = array[minIndex]; array[minIndex] = tempMin;

                // Если максимум был на месте левого элемента, то после обмена он переместился.
                // Корректируем его индекс.
                if (maxIndex == left) maxIndex = minIndex;

                // Ставим найденный максимум в конец текущего диапазона
                int tempMax = array[right]; array[right] = array[maxIndex]; array[maxIndex] = tempMax;

                // Сужаем диапазон для следующей итерации
                left++;
                right--;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void filePathLabel1_Load(object sender, EventArgs e)
        {

        }
    }
}
