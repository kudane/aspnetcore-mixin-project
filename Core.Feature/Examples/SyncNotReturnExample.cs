namespace Core.Feature
{
    public class SyncNotReturnExample
    {
        public class Command : IRequest { }

        public class Response
        {
            public int Id { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            public Handler() { }

            protected override void Handle(Command request)
            {
                throw new NotImplementedException();
            }
        }
    }
}
