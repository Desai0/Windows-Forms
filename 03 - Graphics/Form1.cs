namespace _03___Graphics
{
    public partial class Form1 : Form
    {

        private Image exampleImage;
        private Image baklanImage;

        private const int IMAGE_WIDTH = 100;
        private const int IMAGE_HEIGHT = 100;
        private int x = 1000;
        private bool isJumping = false;

        private int pesx = 50;
        private int pesy = 205;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            try
            {
                exampleImage = Image.FromFile("example.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения 'example.png': {ex.Message}");
                // Можно установить какое-то изображение по умолчанию или просто пропустить
                exampleImage = null;
            }

            try
            {
                baklanImage = Image.FromFile("baklan.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения 'baklan.png': {ex.Message}");
                baklanImage = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.DrawLine(Pens.Black, 0, 300, 1000, 300);


            if (exampleImage != null)
            {
                g.DrawImage(exampleImage, pesx, pesy, IMAGE_WIDTH, IMAGE_HEIGHT);
            }

            if (baklanImage != null)
            {
                g.DrawImage(baklanImage, x, 205, IMAGE_WIDTH, IMAGE_HEIGHT);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            x -= 5;

            // Если изображение ушло за левый край
            if (baklanImage != null && (x + IMAGE_WIDTH < 0))
            {
                x = this.ClientSize.Width; // Возвращаем на правый край формы
            }

            if (isJumping == true && pesy > 5)
            {
                pesy -= 10;
            }
            

            if (isJumping == false && pesy < 205)
            {
                pesy += 10;
            }

            if (isJumping == true && pesy == 5)
            {

                isJumping = false;
            }

            //if (x == pesx)
            //{
            //    break;
            //}

            this.Invalidate(); // Перерисовываем форму (теперь с двойной буферизацией)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isJumping = !isJumping;
        }
    }
}
