using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMD2_Snake
{
    class SquareBlockManager
    {
        int squareWidth = 10;
        int squareHeight = 10;
        int amountOfSquaresX = 25;
        int amountOfSquaresY = 25;
        LinkedList<SquareBlock> squareBlocks;

        int GetSquareSize() 
        {
            return squareHeight * squareWidth;
        }

        int GetHorizontalSquares() 
        {
            return amountOfSquaresX;
        }

        int GetVerticalSquares()
        {
            return amountOfSquaresY;
        }
    }
}
