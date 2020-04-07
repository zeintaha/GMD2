namespace GMD2_Snake
{
    class SnakeMovement
    {
        Direction currentDirection;
        bool canChangeDirection = true;

        public SnakeMovement(Direction currentDirection)
        {
            this.currentDirection = currentDirection;
        }

        public Direction GetCurrentDirection() 
        {
            return currentDirection;
        }

        public void SetCanChangeDirection(bool canChangeDirection) 
        {
            this.canChangeDirection = canChangeDirection;
        }

        public void AttemptToMoveUp()
        {
            AttemptToChangeDirection(Direction.Up);
        }

        public void AttemptToMoveDown()
        {
            AttemptToChangeDirection(Direction.Down);
        }

        public void AttemptToMoveRight()
        {
            AttemptToChangeDirection(Direction.Right);
        }

        public void AttemptToMoveLeft()
        {
            AttemptToChangeDirection(Direction.Left);
        }

        private void AttemptToChangeDirection(Direction direction)
        {
            if (canChangeDirection)
            {
                if (this.currentDirection == Direction.Left && direction == Direction.Right)
                    return; //Uneligible move
                if (this.currentDirection == Direction.Right && direction == Direction.Left)
                    return; //Uneligible move
                if (this.currentDirection == Direction.Up && direction == Direction.Down)
                    return; //Uneligible move
                if (this.currentDirection == Direction.Down && direction == Direction.Up)
                    return;  //Uneligible move

                this.currentDirection = direction;
                canChangeDirection = false;
            }
        }
    }
}
