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

        Boolean IsGameOver = true;

        Int32 squareSize = 25;
        Int32 numberSquaresX = 20;
        Int32 numberSquaresY = 20;

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
            //test_textBox.Text = "HELLO" + DateTime.Now.ToString();
            //DrawBackgroundSquares();

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

        //private void DrawBackgroundSquares()
        //{
        //    Bitmap bm = new Bitmap(bgPB.Width, bgPB.Height);
        //    Graphics g = Graphics.FromImage(bm);
        //    g.FillRectangle(Brushes.Gray, 0, 0, bgPB.Width, bgPB.Height);
        //    Size sizeCell = new Size(bgPB.Width / matrixSize, bgPB.Height / matrixSize);

        //    for (int x = 0; x < matrixSize; x++)
        //    {
        //        for (int y = 0; y < matrixSize; y++)
        //        {
        //            g.FillRectangle(Brushes.LightGreen, x * sizeCell.Width + 1, y * (bgPB.Height / matrixSize) + 1, sizeCell.Width - 2, (bgPB.Height / matrixSize) - 2);
        //        }
        //    }

        //    //bgPB.BackgroundImage = bm;
        //}

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
            for (int i = 0; i < snake.BlocksOfSnake.Count; ++i)
                imgGraph.FillRectangle(snakeColor, squareSize * snake.BlocksOfSnake[i].X, squareSize * snake.BlocksOfSnake[i].Y, squareSize - 1, squareSize - 1);


            graph.DrawImage(img, 0, 0);
        }


    }
}
