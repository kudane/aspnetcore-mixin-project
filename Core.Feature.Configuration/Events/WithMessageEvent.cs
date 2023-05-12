namespace Core.Feature.Configuration
{
    public abstract class WithMessageEvent
    {
        private readonly List<MessageEvent> events  = new List<MessageEvent>();

        public void AddEvent(MessageEvent? evt)
        {
            if (evt != null)
            {
                events.Add(evt);
            }
        }

        public List<MessageEvent> GetEvents() 
        {
            return events;
        }
    }
}
