using System.Collections.Generic;
using CqrsPattern.Domain;

namespace CqrsPattern.Infrastructure
{
    public class Db
    {
        // In memory Db
        public IList<Customer> Customers = new List<Customer>();
    }
}
