using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsPattern.Actions
{
    public class AddCustomerCommand
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public AddCustomerCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
