namespace Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "������������������� ���������";

            this.IsMdiContainer = true;

            this.WindowState = FormWindowState.Maximized;

            CreateMainMenu();
        }

        private void CreateMainMenu()
        {
            MenuStrip mainMenuStrip = new MenuStrip();

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("����");

            ToolStripMenuItem createSubMenu = new ToolStripMenuItem("�������");
            // ��������� � ���� ������ ��� �������� �����������
            createSubMenu.DropDownItems.Add("��������� �����", null, OpenLengthConverter);
            createSubMenu.DropDownItems.Add("��������� ����", null, OpenWeightConverter);
            createSubMenu.DropDownItems.Add("��������� �����������", null, OpenTempConverter);

            fileMenu.DropDownItems.Add(createSubMenu);
            fileMenu.DropDownItems.Add("������� ��� ����", null, CloseAllChildWindows);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add("�����", null, (sender, e) => Application.Exit());

            ToolStripMenuItem windowMenu = new ToolStripMenuItem("����");
            windowMenu.DropDownItems.Add("��������", null, (sender, e) => this.LayoutMdi(MdiLayout.Cascade));
            windowMenu.DropDownItems.Add("�������������", null, (sender, e) => this.LayoutMdi(MdiLayout.TileHorizontal));
            windowMenu.DropDownItems.Add("�����������", null, (sender, e) => this.LayoutMdi(MdiLayout.TileVertical));

            mainMenuStrip.Items.Add(fileMenu);
            mainMenuStrip.Items.Add(windowMenu);

            this.MainMenuStrip = mainMenuStrip;
            this.Controls.Add(mainMenuStrip);
        }

        #region ������ ��� �������� �������� ����

        private void OpenLengthConverter(object sender, EventArgs e)
        {
            LengthConverterForm lengthForm = new LengthConverterForm();
            lengthForm.MdiParent = this;
            lengthForm.Show();
        }

        private void OpenWeightConverter(object sender, EventArgs e)
        {
            WeightConverterForm weightForm = new WeightConverterForm();
            weightForm.MdiParent = this;
            weightForm.Show();
        }

        private void OpenTempConverter(object sender, EventArgs e)
        {
            TemperatureConverterForm tempForm = new TemperatureConverterForm();
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
    }
}
