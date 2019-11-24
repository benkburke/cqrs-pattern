namespace CqrsPattern.Actions
{
    public class FindCustomerQuery
    {
        public int Id { get; private set; }

        public FindCustomerQuery(int id)
        {
            Id = id;
        }
    }
}
