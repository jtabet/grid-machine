using System.Collections.Generic;

namespace GridMachine.Models
{
    public class Cell
    {
        public bool color { get; set; } = false;
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Grid
    {
        private SortedDictionary<int, SortedDictionary<int, Cell>> coordinates;
        private int xMin = 0;
        private int xMax = 0;
        private int yMin = 0;
        private int yMax = 0;

        public Grid()
        {
            coordinates = new SortedDictionary<int, SortedDictionary<int, Cell>>() {{
                    0,
                    new SortedDictionary<int, Cell>() {
                        { 0, new Cell() { x = 0, y = 0 } }
                    }
            }};
        }

        /// <summary>
        /// Gets the cell at the specified coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Cell GetCell(int x, int y)
        {
            return coordinates[y][x];
        }

        /// <summary>
        /// Switches the cell color at the given coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SwitchCellColor(int x, int y)
        {
            coordinates[y][x].color = !coordinates[y][x].color;
        }

        /// <summary>
        /// Creates a new cell based on the target given as parameter
        /// </summary>
        /// <param name="target"></param>
        public void AddCell(Cell target)
        {
            if (coordinates.ContainsKey(target.y))
            {
                coordinates[target.y].Add(target.x, target);
            }
            else
            {
                coordinates.Add(target.y, new SortedDictionary<int, Cell>() {{ target.x, target }});
            }

            UpdateBoundaries(target.x, target.y);
        }

        /// <summary>
        /// Returns true if the cell at the provided coordinates has already been discovered, false otherwise
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool HasCell(int x, int y)
        {
            return coordinates.ContainsKey(y) && coordinates[y].ContainsKey(x);
        }

        /// <summary>
        /// Creates an outputable 2 dimensional list of bools
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEnumerable<bool>> ToList()
        {
            var res = new List<List<bool>>();

            // The size of the border of the grid can be adjusted by increasing or decreasing additions and substractions on the boundaries
            for (var i = xMax + 1; i >= xMin - 1; i--)
            {
                var row = new List<bool>();

                for (var j = yMin - 1; j <= yMax + 1; j++)
                {
                    row.Add(HasCell(j, i) && GetCell(j, i).color);
                }

                res.Add(row);
            }

            return res;
        }

        /// <summary>
        /// Updates boudaries of the grid to display
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected void UpdateBoundaries(int x, int y)
        {
            if (y > yMax)
            {
                yMax = y;
            }

            if (y < yMin)
            {
                yMin = y;
            }

            if (x > xMax)
            {
                xMax = x;
            }

            if (x < xMin)
            {
                xMin = x;
            }
        }
    }
}
