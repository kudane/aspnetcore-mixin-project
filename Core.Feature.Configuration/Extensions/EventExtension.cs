namespace Core.Feature.Configuration
{
    public static class EventExtension
    {
        public static async Task<object?> SendAndPublish<T>(this IMediator mediator, T command) 
            where T: class 
        {
            var reponse = await mediator.Send(command);

            var notification = reponse as WithMessageEvent;

            if (notification != null)
            {
                foreach (var item in notification.GetEvents())
                {
                    await mediator.Publish(item).ConfigureAwait(false);
                }
            }

            return reponse;
        }
    }
}
