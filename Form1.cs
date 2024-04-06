using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kursach_OOP
{
    public partial class gameForm : Form
    {
        GameController mainController;

        public gameForm()
        {
            Init();
        }

        private void gameForm_ResizeEnd(object sender, EventArgs e)
        {
            this.ClientSize = new Size(600, 600);
        }

        private void Init()
        {
            InitializeComponent();
            //MessageBox.Show("Нажмите чтобы начать");
            this.ClientSize = new Size(600, 600);
            mainController = new GameController(this, pictureBox1);
            mainController.InitializeMap();
            Fruit fruit = new Fruit(600, 600, mainController.grid.PixelSize);

            this.KeyDown += new KeyEventHandler(mainController.keyboardHandler.Move);
        }

        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                mainController.timer.Start();
            }
            if (e.KeyCode == Keys.Space)
            {
                mainController.timer.Start();
            }
        }
    }
}

