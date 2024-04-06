using System;
using System.Drawing;
using System.Windows.Forms;
using Kursach_OOP;

class Snake
    {
    private PictureBox[] body;
    private int score;
    private int scoreToWin;
    private int wh;
    private int pixelSize;

    public int Score
    { get { return score; } }

    public Snake(int pixelsize, int numOfCells, PictureBox mainPictureBox, Timer mainTimer)
    {
        body = new PictureBox[410];
        body[0] = mainPictureBox;

        wh = numOfCells * pixelsize;
        pixelSize = pixelsize;

        score = 0;
        scoreToWin = numOfCells * numOfCells - 2* numOfCells;
        //body.ClientSize = new Size(600, 600);
        body[0].Size = new Size(600 / numOfCells, 600 / numOfCells);

        body[0].Location = new Point(pixelsize, pixelsize);
    }

    public void MoveSnake(int dirX, int dirY)
    {
        for (int i = score; i >= 1; i--)
        {
            body[i].Location = body[i - 1].Location;
        }
        body[0].Location = new Point(body[0].Location.X + dirX * (pixelSize),
            body[0].Location.Y + dirY * (pixelSize));

    }

    public PictureBox eatFruit(Fruit fruit, int dirX, int dirY)
    {
        if (body[0].Location.X == fruit.rI && body[0].Location.Y == fruit.rJ)
        {
            score++;
            body[score] = new PictureBox();
            body[score].Location = new Point(body[score - 1].Location.X + pixelSize* dirX,
                body[score - 1].Location.Y + pixelSize * dirY);
            body[score].Size = new Size(pixelSize, pixelSize);
            body[score].BackColor = Color.Red;
            return body[score];
        }
        if (score >= scoreToWin)
        {
            //MessageBox.Show("You win! Your score: " + score.ToString());
            score = -1;
            //_form.Close();
        }
        return null;
    }

    public bool EatItSelf()
    {
        for (int i = 1; i < score; i++)
        {
            if (body[0].Location == body[i].Location)
            {
                //timer.Stop();
                //_form.Close();
                return false;
            }
        }
        return true;
    }

    public bool CheckLocation()
    {
        if (body[0].Location.X >  wh||
            body[0].Location.X < 0 ||
            body[0].Location.Y < 0 ||
            body[0].Location.Y > wh)
        {
            //MessageBox.Show("You lose! Your score: " + score.ToString());
            return false;
            //_form.Close();
            //_form.rest
        }
        return true;
    }

}
