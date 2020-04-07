namespace GMD2_Snake
{
    public class SquareBlock
    {
        int x;
        int y;

        public SquareBlock(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int[] GetPosition()
        {
            int[] position = { x, y };
            return position;
        }
    }
}