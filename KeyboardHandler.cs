using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

public class KeyboardHandler
{
    //private int speed;
    private int dirx;
    private int diry;
    //private int _pixelSize;
    //private PictureBox pictureBox1;

    public int dirY { get { return diry; } set{ dirx = value; } }
    public int dirX { get { return dirx; } set { diry = value; } }

    public KeyboardHandler()
    {
        dirx = 1;
        diry = 0;
    }

    public void Move(object sender, KeyEventArgs e)
    {
        if (e.KeyCode.ToString() == "Left" && dirx != 1)
        {
            dirx = -1;
            diry = 0;
            //pictureBox1.Location = new Point(pictureBox1.Location.X - speed, pictureBox1.Location.Y);
        }
        if (e.KeyCode.ToString() == "Right" && dirx != -1)
        {
            dirx = 1;
            diry = 0;
            //pictureBox1.Location = new Point(pictureBox1.Location.X + speed, pictureBox1.Location.Y);
        }
        if (e.KeyCode.ToString() == "Up" && diry != 1)
        {
            dirx = 0;
            diry = -1;
            //pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - speed);
        }
        if (e.KeyCode.ToString() == "Down" && diry != -1)
        {
            dirx = 0;
            diry = 1;
            //pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + speed);
        }
    }
}
