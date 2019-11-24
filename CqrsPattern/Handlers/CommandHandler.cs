using System.Linq;
using CqrsPattern.Actions;
using CqrsPattern.Domain;
using CqrsPattern.Infrastructure;

namespace CqrsPattern.Handlers
{
    public class CommandHandler
    {
        private Db _db;

        public CommandHandler(Db db)
        {
            _db = db;
        }

        public void Handle(AddCustomerCommand cmd)
        {
            // Does not account for duplicates
            _db.Customers.Add(new Customer { Id = cmd.Id, Name = cmd.Name });
        }

        public void Handle(RemoveCustomerCommand cmd)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Id == cmd.Id);

            if (customer != null)
            {
                _db.Customers.Remove(customer);
            }
        }
    }
}
