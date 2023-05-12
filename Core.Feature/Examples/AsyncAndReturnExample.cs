namespace Core.Feature
{
    public class AsyncAndReturnExample
    {
        public class Event : INotification
        {
            public int Id { get; set; }
        }

        public class Command : IRequest<Response>
        {
        }

        public class Response
        {
            public int Status { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            public Handler() { }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                await Task.FromResult(0);

                return new Response()
                {
                    Status = 200
                };
            }
        }
    }
}
