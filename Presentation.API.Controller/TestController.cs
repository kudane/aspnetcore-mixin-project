namespace Presentation.API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        [HttpGet("Mixin")]
        public async Task<IActionResult> TestMixin([FromServices] IMediator mediator)
        {
            var blog = await mediator.Send(new TestDbContextMixin.Command());
            return Ok(blog);
        }

        [HttpGet("Event")]
        public async Task<IActionResult> TestEvent([FromServices] IMediator mediator)
        {
            var blog = await mediator.SendAndPublish(new TestEvent.Command());

            return Ok(blog);
        }
    }
}