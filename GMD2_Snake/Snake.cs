using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GMD2_Snake
{
    class Snake
    {
        public SnakeBodyBlock snakeHead;
        public List<SnakeBodyBlock> blocksOfSnake;

        readonly int posX;
        readonly int posY;
        readonly Random random;        
        readonly SnakeDirection snakeDirection;

        public Snake(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            snakeDirection = new SnakeDirection(Direction.Up);
            random = new Random();
            blocksOfSnake = new List<SnakeBodyBlock>();
            snakeHead = new SnakeBodyBlock(0, 0);

            CreateNewFood();
            CreateSnake();
        }

        void CreateSnake() 
        {
            AddSnakeTail(posX / 2 + 1, posY / 2);
            AddSnakeTail(posX / 2 + 0, posY / 2);
            AddSnakeTail(posX / 2 - 1, posY / 2);
            AddSnakeTail(posX / 2 - 2, posY / 2);
            AddSnakeTail(posX / 2 - 3, posY / 2);
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

        void AddSnakeTail(int x, int y) 
        {
            blocksOfSnake.Add(new SnakeBodyBlock(x, y));
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
            blocksOfSnake[0].PosX = (blocksOfSnake[0].PosX + posX - 1) % posX;
        }

        void MoveRight() 
        {
            blocksOfSnake[0].PosX = (blocksOfSnake[0].PosX + 1) % posX;
        }

        void MoveUp() 
        {
            blocksOfSnake[0].PosY = (blocksOfSnake[0].PosY + posY - 1) % posY;
        }

        void MoveDown()
        {
            blocksOfSnake[0].PosY = (blocksOfSnake[0].PosY + 1) % posY;
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
            if (blocksOfSnake[0].Equals(snakeHead))
                return true;

            return false;
        }

        private void FinishEating()
        {
            var count = blocksOfSnake.Count;
            var last = blocksOfSnake[count - 1];

            AddSnakeTail(last.PosX, last.PosY);
            CreateNewFood();
        }

        private void CreateNewFood()
        {
            var newFood = true;

            while (newFood)
            {
                snakeHead.PosX = random.Next() % posX;
                snakeHead.PosY = random.Next() % posY;
                newFood = false;

                var count = blocksOfSnake.Count;
                for (int i = 0; i < count; ++i)
                    if (blocksOfSnake[i].Equals(snakeHead))
                        newFood = true;
            }
        }
    }
}
