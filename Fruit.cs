using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursach_OOP;

public class Fruit
{
    PictureBox fruitePictureBox;
    public int rI, rJ;
    private int _windowWidth, _windowHeight, _pixelSize;

    public Fruit(int windowWidth, int windowHeight, int pixelSize)
    {
        fruitePictureBox = new PictureBox();
        fruitePictureBox.BackColor = Color.Black;
        fruitePictureBox.Size = new Size(pixelSize, pixelSize);
        _windowWidth = windowWidth;
        _windowHeight = windowHeight;
        _pixelSize = pixelSize;


    }

    public PictureBox generateFruit()
    {
        Random r = new Random();
        rI = r.Next(0, _windowWidth - _pixelSize);
        int tempi = rI % _pixelSize;
        rI -= tempi;

        rJ = r.Next(0, _windowHeight - _pixelSize);
        int tempJ = rJ % _pixelSize;
        rJ -= tempJ;
        //rJ++;
        //rI++;
        fruitePictureBox.Location = new Point(rI, rJ);

        return fruitePictureBox;
    }
}

