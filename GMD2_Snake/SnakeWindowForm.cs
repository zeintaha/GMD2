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
        public SnakeWindowForm()
        {
            InitializeComponent();
        }

        private void SnakeWindow_Load(object sender, EventArgs e)
        {

        }

        public void GameLoop()
        {
            TimeSpan MS_PER_FRAME = TimeSpan.FromMilliseconds(1.0 / 60.0 * 1000.0);
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
                while (lag >= MS_PER_FRAME)
                {
                    UpdateGameLogic();
                    lag -= MS_PER_FRAME;
                }
                RenderToScreen();

                //To utilize the GameLoop using Windows Forms, tell the application to do the events
                Refresh();
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
            test_textBox.Text = "HELLO" + DateTime.Now.ToString();
        }

        private void UpdateGameLogic()
        {
            //Insert Game Logic changes here
        }

        private void test_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
