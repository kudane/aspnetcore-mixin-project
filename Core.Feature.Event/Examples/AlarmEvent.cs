namespace Core.Feature.Event
{
    public class AlarmEvent
    {
        public class Message : MessageEvent
        {
            public string Prop1 { get; set; }
        }

        public class Handler : INotificationHandler<Message>
        {
            public Task Handle(Message notification, CancellationToken cancellationToken)
            {
                Debug.WriteLine($"{notification.Prop1}");
                return Task.CompletedTask;
            }
        }
    }
}
