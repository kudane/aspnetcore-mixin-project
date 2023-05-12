namespace Core.Feature
{
    public class TestEvent
    {
        public class Command : IRequest<Response?> { }

        public class Response : WithMessageEvent
        {
        }

        public class Handler : IRequestHandler<Command, Response?>
        {
            public async Task<Response?> Handle(Command request, CancellationToken cancellationToken)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

                var response = new Response();

                response.AddEvent(new AlarmEvent.Message());

                return response;
            }
        }
    }
}
