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
        Graphics gfx = null;
        Graphics graph = null;


        //private int matrixSize = 20;
        public SnakeWindowForm()
        {
            InitializeComponent();

            img = new Bitmap(squareSize * numberSquaresX, squareSize * numberSquaresY);
            gfx = Graphics.FromImage(img);
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
            Draw();
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
            gfx.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, squareSize * numberSquaresX, squareSize * numberSquaresY);
        }

        void DrawUI() 
        {
            gfx.DrawString("Food eaten: " + (snake.blocksOfSnake.Count - 5).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), 210, 475);
            if (IsGameOver)
            {
                gfx.DrawString("GAME OVER", new Font("Arial", 20), new SolidBrush(Color.Black), 175, 225);
            }
        }

        void DrawFood() 
        {
            var foodColor = new SolidBrush(Color.Red);
            gfx.FillEllipse(foodColor, squareSize * snake.snakeHead.PosX, squareSize * snake.snakeHead.PosY, squareSize, squareSize);
            gfx.DrawImage(GMD2_Snake.Properties.Resources.apple_pixel_art, squareSize * snake.snakeHead.PosX, squareSize * snake.snakeHead.PosY, squareSize, squareSize);
        }

        private void DrawSnake() 
        {
            var snakeColor = new SolidBrush(Color.Gray);
            for (int i = 0; i < snake.blocksOfSnake.Count; ++i)
                gfx.FillRectangle(snakeColor, squareSize * snake.blocksOfSnake[i].PosX, squareSize * snake.blocksOfSnake[i].PosY, squareSize - 1, squareSize - 1);
        }

        private void DrawPlayspace() 
        {
            var gridBrush = new SolidBrush(Color.LightGray);
            var gridPen = new Pen(gridBrush);
            for (int i = 1; i < numberSquaresX; ++i)
                gfx.DrawLine(gridPen, 0, i * squareSize, squareSize * numberSquaresX, i * squareSize);

            for (int i = 1; i < numberSquaresX; ++i)
                gfx.DrawLine(gridPen, i * squareSize, 0, i * squareSize, squareSize * numberSquaresY);
            
        }
    }
}
