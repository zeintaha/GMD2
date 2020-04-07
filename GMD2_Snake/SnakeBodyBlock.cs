using System;

namespace GMD2_Snake
{
    class SnakeBodyBlock
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public SnakeBodyBlock(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public void Set(SnakeBodyBlock snakeBodyBlock)
        {
            PosX = snakeBodyBlock.PosX;
            PosY = snakeBodyBlock.PosY;
        }

        public bool Equals(SnakeBodyBlock snakeBodyBlock)
        {
            return snakeBodyBlock.PosX == PosX && snakeBodyBlock.PosY == PosY;
        }

        public override string ToString()
        {
            return String.Format("SnakeBodyBlock (X: {0}, Y: {1})", PosX, PosY);
        }
    }
}
