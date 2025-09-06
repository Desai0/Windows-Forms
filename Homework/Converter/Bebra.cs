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
    public partial class Bebra : Form
    {
        private string selectedFilePath;

        // Add the following declaration for openFileDialog1 at the class level.  
        // This ensures that the openFileDialog1 object exists in the current context.  

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Bebra()
        {
            InitializeComponent();
        }

        public static void TournamentSelectionSort<T>(T[] array, StringBuilder log = null, IComparer<T> comparer = null)
        {
            int n = array.Length;
            if (n <= 1)
            {
                if (log != null) log.AppendLine("Массив слишком мал для сортировки.");
                return;
            }

            comparer ??= Comparer<T>.Default;

            // ближайшая степень двойки >= n
            int leafCount = 1;
            while (leafCount < n) leafCount <<= 1;

            int treeSize = 2 * leafCount - 1;
            int[] tree = new int[treeSize];      // храним индексы элементов (или -1 = +inf)
            int leafStart = leafCount - 1;

            // заполним листья индексами или -1 для "пустых" листьев
            for (int i = 0; i < leafCount; i++)
                tree[leafStart + i] = (i < n) ? i : -1;

            // построим внутренние узлы (выбираем индекс победителя)
            for (int i = leafStart - 1; i >= 0; i--)
            {
                int left = tree[2 * i + 1];
                int right = tree[2 * i + 2];
                tree[i] = PickWinnerIndex(left, right, array, comparer);
            }

            // лог: начало (ограничиваем длину вывода для больших массивов)
            if (log != null)
            {
                int show = Math.Min(n, 100);
                log.AppendLine("Начальный массив (первые " + show + "): " + string.Join(", ", array.Take(show)));
                if (n > show) log.AppendLine($"... (всего {n} элементов)");
                log.AppendLine("Начинаем турнирную сортировку...");
            }

            // результирующий отсортированный массив
            T[] result = new T[n];

            // извлекаем по одному минимальному
            for (int k = 0; k < n; k++)
            {
                int winnerIdx = tree[0];
                if (winnerIdx == -1) // на случай, если все листья пусты (страж)
                {
                    // остаток заполняем значениями по-умолчанию (на практике не случится, но защитилась)
                    for (int t = k; t < n; t++) result[t] = default;
                    break;
                }

                result[k] = array[winnerIdx];

                // при логировании — выводим первые 200 извлечений, чтобы не захламлять лог
                if (log != null && k < 200)
                {
                    log.AppendLine($"[{k}] Извлечено: {result[k]} (оригинальный индекс {winnerIdx})");
                }
                else if (log != null && k == 200)
                {
                    log.AppendLine("Дальше выводу извлечений в лог отключён (больше 200 элементов).");
                }

                // пометим соответствующий лист как "удалённый"
                int leaf = leafStart + winnerIdx;
                tree[leaf] = -1;

                // обновим путь к корню
                int current = leaf;
                while (current > 0)
                {
                    int parent = (current - 1) / 2;
                    int left = tree[2 * parent + 1];
                    int right = tree[2 * parent + 2];
                    tree[parent] = PickWinnerIndex(left, right, array, comparer);
                    current = parent;
                }
            }

            // копируем результат обратно в исходный массив
            Array.Copy(result, 0, array, 0, n);

            if (log != null)
            {
                log.AppendLine("Сортировка завершена.");
                int show = Math.Min(n, 100);
                log.AppendLine("Отсортированный массив (первые " + show + "): " + string.Join(", ", array.Take(show)));
                if (n > show) log.AppendLine($"... (всего {n} элементов)");
            }
        }

        // Вспомогательная функция: выбирает индекс меньшего элемента,
        // если один из индексов -1 => возвращаем другой; если оба -1 => -1.
        private static int PickWinnerIndex<T>(int left, int right, T[] array, IComparer<T> comparer)
        {
            if (left == -1) return right;
            if (right == -1) return left;
            return (comparer.Compare(array[left], array[right]) <= 0) ? left : right;
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
            TournamentSelectionSort(numbers, log);

            stopwatch.Stop();

            // log.AppendLine("------------------------------------");
            log.AppendLine("Сортировка завершена!");
            log.AppendLine("Отсортированный массив: " + string.Join(", ", numbers));
            log.AppendLine();
            log.AppendLine($"Затраченное время: {stopwatch.ElapsedMilliseconds} мс ({stopwatch.Elapsed.TotalSeconds:F4} секунд).");

            resultRichTextBox.Text = log.ToString();
        }

        private void Bebra_Load(object sender, EventArgs e)
        {

        }
    }
}
