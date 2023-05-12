namespace Core.Feature
{
    public class SyncReturnExample
    {
        public class Command : IRequest<Response> { }

        public class Response
        {
            public int Id { get; set; }
        }

        public class Handler : RequestHandler<Command, Response>
        {
            public Handler() { }

            protected override Response Handle(Command request)
            {
                throw new NotImplementedException();
            }
        }
    }
}
