namespace GridMachine.Models
{
    public enum Direction
    {
        up, right, down, left
    }

    public class Machine
    {
        public Cell currentCell { get; protected set; }
        protected Direction currentDirection { get; set; } = Direction.right;

        public Machine(Cell defaultCell)
        {
            currentCell = defaultCell;
        }

        /// <summary>
        /// Rotates 90° clockwise if the machine is in a white square and 90° counter-clockwise if it's in a black square
        /// </summary>
        public void UpdateOrientation()
        {
            if (!currentCell.color)
            {
                currentDirection = currentDirection != Direction.left ? currentDirection + 1 : Direction.up;
            }
            else
            {
                currentDirection = currentDirection != Direction.up ? currentDirection - 1 : Direction.left;
            }
        }
        
        /// <summary>
        /// Updates the current cell
        /// </summary>
        /// <param name="newCell"></param>
        public void SetCurrentCell(Cell newCell)
        {
            currentCell = newCell;
        }

        /// <summary>
        /// Returns the next cell in front of the machine
        /// </summary>
        /// <returns></returns>
        public Cell GetTargetCell()
        {
            Cell targetCell = new Cell();

            switch (currentDirection)
            {
                case Direction.up:
                    targetCell.y = currentCell.y + 1;
                    targetCell.x = currentCell.x;
                    break;
                case Direction.right:
                    targetCell.x = currentCell.x + 1;
                    targetCell.y = currentCell.y;
                    break;
                case Direction.down:
                    targetCell.y = currentCell.y - 1;
                    targetCell.x = currentCell.x;
                    break;
                case Direction.left:
                    targetCell.x = currentCell.x - 1;
                    targetCell.y = currentCell.y;
                    break;
            }


            return targetCell;
        }
    }
}
