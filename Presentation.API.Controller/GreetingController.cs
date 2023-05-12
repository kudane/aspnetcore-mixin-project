namespace Presentation.API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private readonly IMediator mediator;

        public GreetingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "Welcome")]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new TestGreeting.Command());

            return Ok(response);
        }
    }
}
