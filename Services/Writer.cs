using System.Collections.Generic;

namespace GridMachine.Services
{
    interface Writer
    {
        void Write(IEnumerable<IEnumerable<bool>> grid);
    }
}
