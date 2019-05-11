using GridMachine.Models;

namespace GridMachine.Services
{
    public class StepIterator : Iterator
    {
        protected Grid currentGrid { get; set; }
        protected Machine currentMachine { get; set; }
        private int currentStep = 0;
        private int targetStep;

        public StepIterator(Grid grid, Machine machine, int targetStep)
        {
            this.currentGrid = grid;
            this.currentMachine = machine;
            this.targetStep = targetStep;
        }

        /// <summary>
        /// Checks if there is a next iteration
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            return currentStep < targetStep;
        }

        /// <summary>
        /// Moves to the next iteration
        /// </summary>
        public void Next()
        {
            Cell previousCell = currentMachine.currentCell;
            currentMachine.UpdateOrientation();
            Cell targetCell = currentMachine.GetTargetCell();
            
            if (!currentGrid.HasCell(targetCell.x, targetCell.y))
            {
                currentGrid.AddCell(targetCell);
            }

            currentMachine.SetCurrentCell(currentGrid.GetCell(targetCell.x, targetCell.y));
            currentGrid.SwitchCellColor(previousCell.x, previousCell.y);

            currentStep++;
        }
    }
}
