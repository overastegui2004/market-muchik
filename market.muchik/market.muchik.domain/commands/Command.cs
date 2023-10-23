using market.muchik.domain.events;

namespace market.muchik.domain.commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command() 
        {
            Timestamp = DateTime.Now;
        }
    }
}
