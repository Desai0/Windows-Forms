namespace Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Многофункциональный конвертер";

            this.IsMdiContainer = true;

            this.WindowState = FormWindowState.Maximized;

            CreateMainMenu();
        }

        private void CreateMainMenu()
        {
            MenuStrip mainMenuStrip = new MenuStrip();

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");

            ToolStripMenuItem createSubMenu = new ToolStripMenuItem("Создать");
            // Добавляем в него пункты для открытия конвертеров
            createSubMenu.DropDownItems.Add("Пирамидальная сортировка", null, AkimchikLoh);
            createSubMenu.DropDownItems.Add("Выбор из дерева", null, Bebra);
            createSubMenu.DropDownItems.Add("Сортировка методом\nтурнира с выбыванием", null, OpenLengthConverter);
            createSubMenu.DropDownItems.Add("Квадратичный выбор", null, OpenWeightConverter);
            createSubMenu.DropDownItems.Add("Простой выбор", null, OpenTempConverter);

            fileMenu.DropDownItems.Add(createSubMenu);
            fileMenu.DropDownItems.Add("Закрыть все окна", null, CloseAllChildWindows);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add("Выход", null, (sender, e) => Application.Exit());

            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Окна");
            windowMenu.DropDownItems.Add("Каскадом", null, (sender, e) => this.LayoutMdi(MdiLayout.Cascade));
            windowMenu.DropDownItems.Add("Горизонтально", null, (sender, e) => this.LayoutMdi(MdiLayout.TileHorizontal));
            windowMenu.DropDownItems.Add("Вертикально", null, (sender, e) => this.LayoutMdi(MdiLayout.TileVertical));

            mainMenuStrip.Items.Add(fileMenu);
            mainMenuStrip.Items.Add(windowMenu);

            this.MainMenuStrip = mainMenuStrip;
            this.Controls.Add(mainMenuStrip);
        }

        #region Методы для открытия дочерних окон
        private void AkimchikLoh(object sender, EventArgs e)
        {
            AkimchikLoh lengthForm = new AkimchikLoh();
            lengthForm.MdiParent = this;
            lengthForm.Show();
        }

        private void Bebra(object sender, EventArgs e)
        {
            Bebra lengthForm = new Bebra();
            lengthForm.MdiParent = this;
            lengthForm.Show();
        }

        private void OpenLengthConverter(object sender, EventArgs e)
        {
            LengthConverterForm lengthForm = new LengthConverterForm();
            lengthForm.MdiParent = this;
            lengthForm.Show();
        }

        private void OpenWeightConverter(object sender, EventArgs e)
        {
            filePathLabel1 weightForm = new filePathLabel1();
            weightForm.MdiParent = this;
            weightForm.Show();
        }

        private void OpenTempConverter(object sender, EventArgs e)
        {
            filePathLabel tempForm = new filePathLabel();
            tempForm.MdiParent = this;
            tempForm.Show();
        }

        private void CloseAllChildWindows(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
