namespace Core.Mediator.Integration
{
    public class ClienteLicencaIntegrationEvent : IntegrationEvent
    {
        public int Id { get; private set; }

        public ClienteLicencaIntegrationEvent(int id)
        {
            Id = id;
        }
    }
}
