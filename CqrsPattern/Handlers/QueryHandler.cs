using System.Linq;
using System.Text.Json;
using CqrsPattern.Actions;
using CqrsPattern.Infrastructure;

namespace CqrsPattern.Handlers
{
    public class QueryHandler
    {
        private readonly Db _db;

        public QueryHandler(Db db)
        {
            _db = db;
        }

        public string Handle(FindCustomerQuery qry)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Id == qry.Id);

            return JsonSerializer.Serialize(customer);
        }

        public string Handle(GetAllCustomersQuery qry)
        {
            return JsonSerializer.Serialize(_db.Customers);
        }
    }
}
