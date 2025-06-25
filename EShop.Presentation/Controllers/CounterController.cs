using Microsoft.AspNetCore.Mvc;

namespace EShop.Presentation.Controllers
{
    public interface ICounterService
    {
        int GetNextNumber();
    }

    public class CounterService : ICounterService
    {
        private int _counter = 0;

        public int GetNextNumber()
        {
            return ++_counter;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        [HttpGet("counter")]
        public ActionResult<int> GetCounter(
            [FromServices] ICounterService counter1,
            [FromServices] ICounterService counter2,
            [FromServices] ICounterService counter3,
            [FromServices] ICounterService counter4)
        {
            return Ok(new
            {
                Counter1 = counter1.GetNextNumber(),
                Counter2 = counter2.GetNextNumber(),
                Counter3 = counter3.GetNextNumber(),
                Counter4 = counter4.GetNextNumber(),
            });
        }
    }
}
