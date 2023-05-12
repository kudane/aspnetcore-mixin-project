namespace Core.Feature
{
    public class TestDbContextMixin
    {
        public class Command : IRequest<Response?> { }

        public class Response
        {
            public Blog? Blog { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response?>
        {
            private readonly AppDbContext context;

            public Handler(AppDbContext context)
            {
                this.context = context;
            }

            public async Task<Response?> Handle(Command request, CancellationToken cancellationToken)
            {
                var dataFromQuery  = await context.Blogs.Where(a => a.BlogId == 1).FirstOrDefaultAsync(cancellationToken);

                var dataFromStore = await context.GetBlogWithPost.FromSqlInterpolated($"EXEC {nameof(context.GetBlogWithPost)}").ToListAsync(cancellationToken);

                return new Response()
                { 
                    Blog = dataFromQuery
                };
            }
        }
    }
}
