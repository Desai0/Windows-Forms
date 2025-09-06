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
        private string selectedFilePath;

        // Add the following declaration for openFileDialog1 at the class level.  
        // This ensures that the openFileDialog1 object exists in the current context.  

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public LengthConverterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сортирует массив методом "Турнира" (Tournament Sort).
        /// Алгоритм строит дерево "победителей" для поиска минимального элемента,
        /// затем последовательно извлекает победителя и перестраивает дерево.
        /// </summary>
        private void TournamentSort(int[] array, StringBuilder log)
        {
            int n = array.Length;
            if (n <= 1) return;

            // Находим ближайшую степень двойки для количества листьев
            int leafCount = 1;
            while (leafCount < n) leafCount *= 2;

            // Создаем явное дерево в дополнительной памяти
            int treeSize = 2 * leafCount - 1;
            int[] tree = new int[treeSize];
            int leafStartIndex = leafCount - 1;

            // Заполняем дерево "бесконечностью" - заведомо большим числом
            for (int i = 0; i < treeSize; i++) tree[i] = int.MaxValue;

            // Копируем исходные данные в "листья" дерева
            Array.Copy(array, 0, tree, leafStartIndex, n);

            // Проводим "турнир": заполняем родительские узлы "победителями" (минимумами)
            int currentIndex = leafStartIndex - 1;
            while (currentIndex >= 0)
            {
                tree[currentIndex] = Math.Min(tree[2 * currentIndex + 1], tree[2 * currentIndex + 2]);
                currentIndex--;
            }

            // Извлекаем победителей и перестраиваем дерево
            for (int i = 0; i < n; i++)
            {
                // Победитель всегда в корне дерева
                array[i] = tree[0];

                // Находим лист с победителем, чтобы "удалить" его
                currentIndex = 0;
                while (currentIndex < leafStartIndex)
                {
                    int leftChild = 2 * currentIndex + 1;
                    int rightChild = 2 * currentIndex + 2;
                    if (tree[leftChild] != array[i]) currentIndex = rightChild;
                    else currentIndex = leftChild;
                }
                tree[currentIndex] = int.MaxValue; // Удаляем, заменяя на "бесконечность"

                // "Переигрываем" турнир на пути от листа к корню
                while (currentIndex > 0)
                {
                    int parentIndex = (currentIndex - 1) / 2;
                    tree[parentIndex] = Math.Min(tree[2 * parentIndex + 1], tree[2 * parentIndex + 2]);
                    currentIndex = parentIndex;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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
            TournamentSort(numbers, log);

            stopwatch.Stop();

            // log.AppendLine("------------------------------------");
            log.AppendLine("Сортировка завершена!");
            log.AppendLine("Отсортированный массив: " + string.Join(", ", numbers));
            log.AppendLine();
            log.AppendLine($"Затраченное время: {stopwatch.ElapsedMilliseconds} мс ({stopwatch.Elapsed.TotalSeconds:F4} секунд).");

            resultRichTextBox.Text = log.ToString();
        }

        private void LengthConverterForm_Load(object sender, EventArgs e)
        {

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
    }
}