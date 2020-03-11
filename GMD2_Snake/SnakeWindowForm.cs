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

        int squareSize = 10;
        int numberSquaresX = 50;
        int numberSquaresY = 50;

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
                
                ProcessInput();
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

        private void ProcessInput()
        {
            //Insert Input events here
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

        private void bgPB_Click(object sender, EventArgs e)
        {

        }

        private void ChangeGameState()
        {
            IsGameOver = !IsGameOver;
        }

        private void Draw()
        {
            imgGraph.FillRectangle(new SolidBrush(Color.FromArgb(192,255,192)), 0, 0, squareSize * numberSquaresX, squareSize * numberSquaresY);

            var gridBrush = new SolidBrush(Color.LightGray);
            var gridPen = new Pen(gridBrush);

            for (int i = 1; i < numberSquaresX; ++i)
                imgGraph.DrawLine(gridPen, 0, i * squareSize, squareSize * numberSquaresX, i * squareSize);

            for (int i = 1; i < numberSquaresX; ++i)
                imgGraph.DrawLine(gridPen, i * squareSize, 0, i * squareSize, squareSize * numberSquaresY);


            var snakeColor = new SolidBrush(Color.Black);
            for (int i = 0; i < snake.blocksOfSnake.Count; ++i)
                imgGraph.FillRectangle(snakeColor, squareSize * snake.blocksOfSnake[i].X, squareSize * snake.blocksOfSnake[i].Y, squareSize - 1, squareSize - 1);


            graph.DrawImage(img, 0, 0);
        }
    }
}
