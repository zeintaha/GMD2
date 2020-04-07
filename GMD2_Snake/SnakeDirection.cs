namespace GMD2_Snake
{
    class SnakeDirection
    {
        Direction currentDirection;
        bool canChangeDirection = true;

        public SnakeDirection(Direction currentDirection)
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

        public void AttemptToLookUp()
        {
            AttemptToChangeDirection(Direction.Up);
        }

        public void AttemptToLookDown()
        {
            AttemptToChangeDirection(Direction.Down);
        }

        public void AttemptToLookRight()
        {
            AttemptToChangeDirection(Direction.Right);
        }

        public void AttemptToLookLeft()
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
