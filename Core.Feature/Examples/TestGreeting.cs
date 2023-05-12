namespace Core.Feature
{
    public class TestGreeting
    {
        public class Command : IRequest<Response> { }

        public class Response
        {
            public string Message { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response>
        {

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                return new Response() { Message = "Hello"};
            }
        }
    }
}
