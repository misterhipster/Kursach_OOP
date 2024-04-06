using System;
using System.Drawing;
using System.Windows.Forms;
using Kursach_OOP;

public class GameController
{
    private gameForm _form;
    private int _numOfCells = 15;
    public Grid grid;
    public KeyboardHandler keyboardHandler;
    private int timeInterval = 150;
    public Timer timer;
    public Fruit fruit;
    private PictureBox mainPictureBox;
    Snake snake;

    public GameController(gameForm form, PictureBox picturebox)
    {
        _form = form;
        mainPictureBox = picturebox;
        InitializeMap();

        keyboardHandler = new KeyboardHandler();

        fruit = new Fruit(600, 600, grid.PixelSize);

        _form.Controls.Add(fruit.generateFruit());

        timer = new Timer();
        timer.Interval = timeInterval;
        timer.Tick += new EventHandler(Update);
        timer.Start();
        _form.KeyDown += new KeyEventHandler(keyboardHandler.Move);
        snake = new Snake(grid.PixelSize, _numOfCells, mainPictureBox, timer);
    }

    public void Update(object sender, EventArgs e)
    {
        snake.MoveSnake(keyboardHandler.dirX, keyboardHandler.dirY);
        if (snake.CheckLocation())
        {

            if (snake.EatItSelf())
            {
                PictureBox pictureBox = snake.eatFruit(fruit, keyboardHandler.dirX, keyboardHandler.dirY);
                if (snake.Score == -1)
                {
                    timer.Stop();
                    MessageBox.Show("You win! Your score: " + snake.Score.ToString());
                    timer.Start();
                    Reinit();
                }

                if (pictureBox != null)
                {
                    fruit.generateFruit();
                    _form.Controls.Add(pictureBox);
                }
            }
            else
            {
                timer.Stop();
                MessageBox.Show("You lose! Your score: " + snake.Score.ToString());
                timer.Start();
                Reinit();
            }
        }
        else
        {
            timer.Stop();
            MessageBox.Show("You lose! Your score: ");
            timer.Start();
            Reinit();
        }
    }

    public void InitializeMap()
    {
        grid = new Grid(_form.ClientSize.Width, _form.ClientSize.Height, _numOfCells);
        var gridControls = grid.CreateGrid();
        foreach (var control in gridControls)
        {
            _form.Controls.Add(control);
        }
    }

    private void Reinit()
    {
        snake = new Snake(grid.PixelSize, _numOfCells, mainPictureBox, timer);
        _form.Controls.Clear();
        _form.Controls.Add(mainPictureBox);
        keyboardHandler.dirX = 1;
        keyboardHandler.dirY = 0;
        fruit = new Fruit(600, 600, grid.PixelSize);
        _form.Controls.Add(fruit.generateFruit());
        InitializeMap();
    }

}
