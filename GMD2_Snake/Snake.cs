using System;
using System.Collections.Generic;

namespace GMD2_Snake
{
    class Snake
    {
        Direction direction;
        Boolean canChangeDirection = true;

        int posX;
        int posY;

        Random randomVal;

        public OneBlockSnake headBlockSnake;
        public List<OneBlockSnake> blocksOfSnake;

        public Snake(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;

            randomVal = new Random();
            blocksOfSnake = new List<OneBlockSnake>();
            headBlockSnake = new OneBlockSnake(0, 0);
            CreateNewFood();

            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 + 1, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 + 0, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 1, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 2, posY / 2));
            blocksOfSnake.Add(new OneBlockSnake(this.posX / 2 - 3, posY / 2));


            direction = Direction.Right;
        }

        public void Move()
        {
            var count = blocksOfSnake.Count;

            for (int i = count - 1; i > 0; --i)
                blocksOfSnake[i].Set(blocksOfSnake[i - 1]);

            switch (direction)
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

            canChangeDirection = true;
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

        public void SetDirection(Direction direction)
        {
            if (canChangeDirection)
            {
                if (this.direction == Direction.Left && direction == Direction.Right)
                    return;
                if (this.direction == Direction.Right && direction == Direction.Left)
                    return;
                if (this.direction == Direction.Up && direction == Direction.Down)
                    return;
                if (this.direction == Direction.Down && direction == Direction.Up)
                    return;

                this.direction = direction;
                canChangeDirection = false;
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
