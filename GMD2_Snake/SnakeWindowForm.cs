using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            GameLoop();
        }

        private void SnakeWindow_Load(object sender, EventArgs e)
        {

        }

        async void GameLoop()
        {
            while (true)
            {
                await Task.Delay(100);
                test_textBox.Text = DateTime.Now.ToString();
            }
        }

        private void test_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
