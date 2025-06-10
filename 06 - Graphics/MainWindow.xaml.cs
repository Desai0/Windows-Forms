using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            listBox1.Items.Add("Первый");
            listBox1.Items.Add("Второй");
            listBox1.Items.Add("Третий");

        }
    }
}
