namespace Core.Feature.Configuration
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly AppDbContext context;

        public TransactionBehavior(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse? result = default(TResponse);

            try
            {
                context.Database.BeginTransaction();

                result = await next();

                context.Database.CommitTransaction();
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }

            return result;
        }
    }
}
