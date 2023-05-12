namespace Core.Feature
{
    public class AsyncAndNotReturnExample
    {
        public class Command : IRequest{ }

        public class Handler : AsyncRequestHandler<Command>
        {
            public Handler() { }

            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                await Task.FromResult(0);
            }
        }
    }
}
