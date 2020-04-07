using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GMD2_Snake
{
    class Snake
    {
        int posX;
        int posY;

        Random randomVal;

        public OneBlockSnake headBlockSnake;
        public List<OneBlockSnake> blocksOfSnake;
        private SnakeMovement snakeMovement;

        public Snake(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            snakeMovement = new SnakeMovement(Direction.Right);

            randomVal = new Random();
            blocksOfSnake = new List<OneBlockSnake>();
            headBlockSnake = new OneBlockSnake(0, 0);
            CreateNewFood();

            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 + 1, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 + 0, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 1, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 2, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 3, posY / 2));
        }

        public void MoveSnake(KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                snakeMovement.AttemptToMoveUp();

            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                snakeMovement.AttemptToMoveDown();

            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                snakeMovement.AttemptToMoveRight();

            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                snakeMovement.AttemptToMoveLeft();
        }


        public void Move()
        {
            var count = blocksOfSnake.Count;

            for (int i = count - 1; i > 0; --i)
                blocksOfSnake[i].Set(blocksOfSnake[i - 1]);

            switch (snakeMovement.GetCurrentDirection())
            {
                case Direction.Left:
                    blocksOfSnake[0].X = (blocksOfSnake[0].X + posX - 1) % posX;
                    break;
                case Direction.Right:
                    blocksOfSnake[0].X = (blocksOfSnake[0].X + 1) % posX;
                    break;
                case Direction.Up:
                    blocksOfSnake[0].Y = (blocksOfSnake[0].Y + posY - 1) % posY;
                    break;
                case Direction.Down:
                    blocksOfSnake[0].Y = (blocksOfSnake[0].Y + 1) % posY;
                    break;
            }

            if (CanEat())
                FinishEating();
            snakeMovement.SetCanChangeDirection(true);
        }

        private bool CanEat()
        {
            if (blocksOfSnake[0].Equals(headBlockSnake))
                return true;

            return false;
        }

        private void FinishEating()
        {
            var count = blocksOfSnake.Count;
            var last = blocksOfSnake[count - 1];

            blocksOfSnake.Add(new OneBlockSnake(last.X, last.Y));
            CreateNewFood();
        }

        private void CreateNewFood()
        {
            var newFood = true;

            while (newFood)
            {
                headBlockSnake.X = randomVal.Next() % posX;
                headBlockSnake.Y = randomVal.Next() % posY;
                newFood = false;

                var count = blocksOfSnake.Count;
                for (int i = 0; i < count; ++i)
                    if (blocksOfSnake[i].Equals(headBlockSnake))
                        newFood = true;
            }
        }

        public bool IsCrossed()
        {
            var count = blocksOfSnake.Count;

            for (int i = 1; i < count; ++i)
                if (blocksOfSnake[0].Equals(blocksOfSnake[i]))
                    return true;

            return false;
        }
    }
}
