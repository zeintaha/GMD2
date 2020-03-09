using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMD2_Snake
{
    class Snake
    {
        Direction Direction;
        Boolean canChangeDirection = true;

        int PosX;
        int PosY;

        Random randomVal;

        public OneBlockSnake oneBlockSnake;
        public List<OneBlockSnake> BlocksOfSnake;

        public Snake(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;

            randomVal = new Random();
            BlocksOfSnake = new List<OneBlockSnake>();
            oneBlockSnake = new OneBlockSnake(0, 0);
            CreateNewFood();

            BlocksOfSnake.Add(new OneBlockSnake(PosX / 2 + 1, posY / 2));
            BlocksOfSnake.Add(new OneBlockSnake(PosX / 2 + 0, posY / 2));
            BlocksOfSnake.Add(new OneBlockSnake(PosX / 2 - 1, posY / 2));
            BlocksOfSnake.Add(new OneBlockSnake(PosX / 2 - 2, posY / 2));


            Direction = Direction.Right;
        }

        public void Move()
        {
            var count = BlocksOfSnake.Count;

            for (int i = count - 1; i > 0; --i)
                BlocksOfSnake[i].Set(BlocksOfSnake[i - 1]);

            switch (Direction)
            {
                case Direction.Left:
                    BlocksOfSnake[0].X = (BlocksOfSnake[0].X + PosX - 1) % PosX;
                    break;
                case Direction.Right:
                    BlocksOfSnake[0].X = (BlocksOfSnake[0].X + 1) % PosX;
                    break;
                case Direction.Up:
                    BlocksOfSnake[0].Y = (BlocksOfSnake[0].Y + PosY - 1) % PosY;
                    break;
                case Direction.Down:
                    BlocksOfSnake[0].Y = (BlocksOfSnake[0].Y + 1) % PosY;
                    break;
            }

            if (CanEat())
                FinishEating();

            canChangeDirection = true;
        }

        private Boolean CanEat()
        {
            if (BlocksOfSnake[0].Equals(oneBlockSnake))
                return true;

            return false;
        }

        private void FinishEating()
        {
            var count = BlocksOfSnake.Count;
            var last = BlocksOfSnake[count - 1];

            BlocksOfSnake.Add(new OneBlockSnake(last.X, last.Y));
            CreateNewFood();
        }

        private void CreateNewFood()
        {
            var newFood = true;

            while (newFood)
            {
                oneBlockSnake.X = randomVal.Next() % PosX;
                oneBlockSnake.Y = randomVal.Next() % PosY;
                newFood = false;

                var count = BlocksOfSnake.Count;
                for (int i = 0; i < count; ++i)
                    if (BlocksOfSnake[i].Equals(oneBlockSnake))
                        newFood = true;
            }
        }

        public void SetDirection(Direction direction)
        {
            if (canChangeDirection)
            {
                if (Direction == Direction.Left && direction == Direction.Right)
                    return;
                if (Direction == Direction.Right && direction == Direction.Left)
                    return;
                if (Direction == Direction.Up && direction == Direction.Down)
                    return;
                if (Direction == Direction.Down && direction == Direction.Up)
                    return;

                Direction = direction;
                canChangeDirection = false;
            }
        }

        public Boolean IsCrossed()
        {
            var count = BlocksOfSnake.Count;

            for (int i = 1; i < count; ++i)
                if (BlocksOfSnake[0].Equals(BlocksOfSnake[i]))
                    return true;

            return false;
        }
    }
}
