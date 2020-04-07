using System;
using System.Diagnostics;
using System.Drawing;
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
            //Input events here
            snake.ChangeSnakeDirection(e);
        }

        private void RenderToScreen()
        {
            //Render events here
            if (!IsGameOver)
            {               
                Draw();
            }
        }

        private void UpdateGameLogic()
        {
            //Game Logic changes here
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
            ClearDrawSpace();
            DrawPlayspace();
            DrawSnake();
            DrawFood();
            DrawUI();

            graph.DrawImage(img, 0, 0);
        }

        void ClearDrawSpace() 
        {
            imgGraph.FillRectangle(new SolidBrush(Color.FromArgb(192, 255, 192)), 0, 0, squareSize * numberSquaresX, squareSize * numberSquaresY);
        }

        void DrawUI() 
        {
            var score = new SolidBrush(Color.Black);
            imgGraph.DrawString("Food eaten: " + (snake.blocksOfSnake.Count - 5).ToString(), new Font("Arial", 10), score, 210, 475);
        }

        void DrawFood() 
        {
            var foodColor = new SolidBrush(Color.Blue);
            imgGraph.FillEllipse(foodColor, squareSize * snake.headBlockSnake.X, squareSize * snake.headBlockSnake.Y, squareSize, squareSize);
        }

        private void DrawSnake() 
        {
            var snakeColor = new SolidBrush(Color.Red);
            for (int i = 0; i < snake.blocksOfSnake.Count; ++i)
                imgGraph.FillRectangle(snakeColor, squareSize * snake.blocksOfSnake[i].X, squareSize * snake.blocksOfSnake[i].Y, squareSize - 1, squareSize - 1);
        }

        private void DrawPlayspace() 
        {
            var gridBrush = new SolidBrush(Color.LightGray);
            var gridPen = new Pen(gridBrush);
            for (int i = 1; i < numberSquaresX; ++i)
                imgGraph.DrawLine(gridPen, 0, i * squareSize, squareSize * numberSquaresX, i * squareSize);

            for (int i = 1; i < numberSquaresX; ++i)
                imgGraph.DrawLine(gridPen, i * squareSize, 0, i * squareSize, squareSize * numberSquaresY);
        }
    }
}
