using GridMachine.Models;
using GridMachine.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GridMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        // PUT api/step
        [HttpPut]
        public void Put([FromBody] int steps)
        {
            Grid grid = new Grid();
            Machine machine = new Machine(grid.GetCell(0, 0));
            Iterator iterator = new StepIterator(grid, machine, steps);
            Writer writer = new HtmlWriter();

            while (iterator.HasNext())
            {
                iterator.Next();
            }

            writer.Write(grid.ToList());
            GC.Collect();
        }
    }
}
