namespace Core.Mediator.Integration
{
    public class ComandaIntegrationEvent : IntegrationEvent
    {
        public string Id { get; private set; }

        public ComandaIntegrationEvent(string id)
        {
            Id = id;
        }
    }
}
