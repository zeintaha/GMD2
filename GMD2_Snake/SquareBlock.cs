namespace GMD2_Snake
{
    public class SquareBlock
    {
        int x;
        int y;
        int width;
        int height;

        public SquareBlock(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public int[] GetPosition() 
        {
            int[] position = { x, y };
            return position;
        }

        public int GetWidth() 
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }
    }
}