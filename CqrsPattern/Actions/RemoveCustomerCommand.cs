namespace CqrsPattern.Actions
{
    public class RemoveCustomerCommand
    {
        public int Id { get; private set; }

        public RemoveCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
