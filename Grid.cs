using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

public class Grid
{
    private int width;
    private int height;
    private int numOfCells;
    private int pixelSize;

    public int PixelSize { get { return pixelSize; }}
    public Grid(int windowWidth, int windowHeight, int numCells)
    {
        width = windowWidth;
        height = windowHeight;
        numOfCells = numCells;
        //pixelSize = width / numOfCells;
        pixelSize = Math.Min(width, height) / numOfCells;
    }

    public List<PictureBox> CreateGrid()
    {
        // Сначала горизонтальные линии окс?
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        for(int i = 0;i<numOfCells+1;i++)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "pictureBox1" + i.ToString();
            pictureBox.BackColor = Color.Blue;
            //pictureBox.Location = new Point(0,i*width/ numOfCells);

            pictureBox.Location = new Point(0, pixelSize * i);

            pictureBox.Size = new Size(width*2, 1);
            pictureBoxes.Add(pictureBox);
        }
        // Потом вертикальные линии 
        for (int i = 0; i < numOfCells+1; i++)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "pictureBox2" + i.ToString();
            pictureBox.BackColor = Color.Blue;

            //pictureBox.Location = new Point(i * height / numOfCells, 0);
            pictureBox.Location = new Point(i * pixelSize, 0);

            pictureBox.Size = new Size(1, height * 2);
            pictureBoxes.Add(pictureBox);
        }
        return pictureBoxes;
    }
}
