using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GMD2_Snake
{
    class Snake
    {
        int posX;
        int posY;
        readonly Random random;
        public OneBlockSnake headBlockSnake;
        public List<OneBlockSnake> blocksOfSnake;
        private readonly SnakeDirection snakeDirection;

        public Snake(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            snakeDirection = new SnakeDirection(Direction.Up);

            random = new Random();
            blocksOfSnake = new List<OneBlockSnake>();
            headBlockSnake = new OneBlockSnake(0, 0);
            CreateNewFood();

            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 + 1, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 + 0, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 1, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 2, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 3, posY / 2));
        }

        public void ChangeSnakeDirection(KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                snakeDirection.AttemptToLookUp();

            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                snakeDirection.AttemptToLookDown();

            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                snakeDirection.AttemptToLookRight();

            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                snakeDirection.AttemptToLookLeft();
        }


        public void Move()
        {
            var count = blocksOfSnake.Count;

            for (int i = count - 1; i > 0; --i)
                blocksOfSnake[i].Set(blocksOfSnake[i - 1]);

            MoveTowardsDirection();

            if (CanEat())
                FinishEating();
            snakeDirection.SetCanChangeDirection(true);
        }

        void MoveTowardsDirection() 
        {
            switch (snakeDirection.GetCurrentDirection())
            {
                case Direction.Left:
                    MoveLeft();
                    break;
                case Direction.Right:
                    MoveRight();
                    break;
                case Direction.Up:
                    MoveUp();
                    break;
                case Direction.Down:
                    MoveDown();
                    break;
            }
        }

        void MoveLeft() 
        {
            blocksOfSnake[0].X = (blocksOfSnake[0].X + posX - 1) % posX;
        }

        void MoveRight() 
        {
            blocksOfSnake[0].X = (blocksOfSnake[0].X + 1) % posX;
        }

        void MoveUp() 
        {
            blocksOfSnake[0].Y = (blocksOfSnake[0].Y + posY - 1) % posY;
        }

        void MoveDown()
        {
            blocksOfSnake[0].Y = (blocksOfSnake[0].Y + 1) % posY;
        }

        public bool IsCrossed()
        {
            var count = blocksOfSnake.Count;

            for (int i = 1; i < count; ++i)
                if (blocksOfSnake[0].Equals(blocksOfSnake[i]))
                    return true;

            return false;
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
                headBlockSnake.X = random.Next() % posX;
                headBlockSnake.Y = random.Next() % posY;
                newFood = false;

                var count = blocksOfSnake.Count;
                for (int i = 0; i < count; ++i)
                    if (blocksOfSnake[i].Equals(headBlockSnake))
                        newFood = true;
            }
        }
    }
}
