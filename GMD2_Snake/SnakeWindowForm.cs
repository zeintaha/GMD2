using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GMD2_Snake
{
    public partial class SnakeWindowForm : Form
    {

        bool IsGameOver = true;

        int squareSize = 20;
        int numberSquaresX = 25;
        int numberSquaresY = 25;

        Snake snake;

        Image img = null;
        Graphics imgGraph = null;
        Graphics graph = null;


        //private int matrixSize = 20;
        public SnakeWindowForm()
        {
            InitializeComponent();

            img = new Bitmap(squareSize * numberSquaresX, squareSize * numberSquaresY);
            imgGraph = Graphics.FromImage(img);
            graph = bgPB.CreateGraphics();

            snake = new Snake(numberSquaresX, numberSquaresY);
        }

        private void SnakeWindow_Load(object sender, EventArgs e)
        {
            snake = new Snake(numberSquaresX, numberSquaresY);

            ChangeGameState();
        }

        public void GameLoop()
        {  
            TimeSpan MS_PER_FRAME = TimeSpan.FromMilliseconds(1.0 / 60.0 * 10000.0);
            Stopwatch stopWatch = Stopwatch.StartNew();
            TimeSpan previous = stopWatch.Elapsed;
            TimeSpan lag = new TimeSpan(0);
            while (true)
            {
                
                TimeSpan current = stopWatch.Elapsed;
                TimeSpan elapsed = current - previous;
                previous = current;
                lag += elapsed;
                
                //ProcessInput();
                //Fixed timestep for logics, varying for rendering
                while (lag >= MS_PER_FRAME)
                {
                    UpdateGameLogic();

                    lag -= MS_PER_FRAME;

                    RenderToScreen();
                }
                
                //To utilize the GameLoop using Windows Forms, tell the application to do the events
                // Refresh();
                 Application.DoEvents();
            }
        }

        private void ProcessInput(object sender, KeyEventArgs e)
        {
            //Insert Input events here
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                snake.AttemptToMoveUp();
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                snake.AttemptToMoveDown();
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                snake.AttemptToMoveRight();
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                snake.AttemptToMoveLeft();
        }

        private void RenderToScreen()
        {
            //Insert Render events here

            if (!IsGameOver)
            {
                
                Draw();

            }
        }

        private void UpdateGameLogic()
        {
            //Insert Game Logic changes here

            if (!IsGameOver)
            {
                snake.Move();

                if (snake.IsCrossed())
                {
                    BeginInvoke(new Action(() => ChangeGameState()));
                }
            }
        }

        private void ChangeGameState()
        {
            IsGameOver = !IsGameOver;
        }

        private void Draw()
        {
            imgGraph.FillRectangle(new SolidBrush(Color.FromArgb(192,255,192)), 0, 0, squareSize * numberSquaresX, squareSize * numberSquaresY);

            var gridBrush = new SolidBrush(Color.LightGray);
            var score = new SolidBrush(Color.Black);
            var gridPen = new Pen(gridBrush);

            for (int i = 1; i < numberSquaresX; ++i)
                imgGraph.DrawLine(gridPen, 0, i * squareSize, squareSize * numberSquaresX, i * squareSize);

            for (int i = 1; i < numberSquaresX; ++i)
                imgGraph.DrawLine(gridPen, i * squareSize, 0, i * squareSize, squareSize * numberSquaresY);


            var snakeColor = new SolidBrush(Color.Red);
            for (int i = 0; i < snake.blocksOfSnake.Count; ++i)
                imgGraph.FillRectangle(snakeColor, squareSize * snake.blocksOfSnake[i].X, squareSize * snake.blocksOfSnake[i].Y, squareSize - 1, squareSize - 1);

            var foodColor = new SolidBrush(Color.Blue);
            imgGraph.FillEllipse(foodColor, squareSize * snake.headBlockSnake.X, squareSize * snake.headBlockSnake.Y, squareSize, squareSize);

            imgGraph.DrawString("Snake Size: " + snake.blocksOfSnake.Count.ToString(), new Font("Arial", 10), score, 0, 0);

            graph.DrawImage(img, 0, 0);
        }


    }
}
