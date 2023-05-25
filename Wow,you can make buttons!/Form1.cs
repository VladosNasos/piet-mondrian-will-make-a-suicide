namespace Wow_you_can_make_buttons_
{
    public partial class Form1 : Form
    {
        private Button createdButton;
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            MouseDown += Form1_MouseDown;
            MouseUp += Form1_MouseUp;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                createdButton = new Button();
                createdButton.Size = new Size(100, 30);
                createdButton.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));;

                Point startPoint = PointToClient(MousePosition);
                createdButton.Location = startPoint;

                Controls.Add(createdButton);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && createdButton != null)
            {
                Point endPoint = PointToClient(MousePosition);

                // Ограничение кнопки в пределах области, где начался и закончился клик
                int minX = Math.Min(createdButton.Left, endPoint.X);
                int minY = Math.Min(createdButton.Top, endPoint.Y);
                int maxX = Math.Max(createdButton.Left, endPoint.X);
                int maxY = Math.Max(createdButton.Top, endPoint.Y);

                int buttonWidth = maxX - minX;
                int buttonHeight = maxY - minY;

                createdButton.Location = new Point(minX, minY);
                createdButton.Size = new Size(buttonWidth, buttonHeight);

                createdButton = null;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}