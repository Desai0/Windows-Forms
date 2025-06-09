using System.Windows;

// Это code-behind

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textbox1.Text))
            {
                listbox1.Items.Add(textbox1.Text);
                textbox1.Clear();
            }
        }

    }
}
