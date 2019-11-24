using System;
using CqrsPattern.Actions;
using CqrsPattern.Handlers;
using CqrsPattern.Infrastructure;

namespace CqrsPattern
{
    public class Program
    {
        private static readonly Db _db = new Db();
        private static readonly CommandHandler _commandHandler = new CommandHandler(_db);
        private static readonly QueryHandler _queryHandler = new QueryHandler(_db);

        static void Main(string[] args)
        {
            string keypress;

            do
            {
                // 0)
                // Display welcome text
                Console.Clear();

                Console.WriteLine("CQRS Pattern -- Customer List Context");
                Console.WriteLine();

                // 1)
                Console.WriteLine("Select Action:");

                Console.WriteLine();
                Console.WriteLine("1) Add Customer");
                Console.WriteLine("2) Remove Customer");
                Console.WriteLine("3) View all Customers");
                Console.WriteLine("4) Find Customer");

                var selection = Console.ReadKey().KeyChar.ToString();
                int.TryParse(selection, out int actionSelection);
                Console.Clear();

                // 2)
                // Should be broken into individual methods / classes,
                // utilizing other patterns such as the strategy pattern
                // for handling the user's selection
                switch (actionSelection)
                {
                    case 1: // Add Customer
                        {
                            Console.Write("Customer ID (number): ");
                            var id = Console.ReadKey().KeyChar.ToString();
                            int.TryParse(id, out int customerId);

                            Console.WriteLine();
                            Console.Write("Customer Name: ");
                            var name = Console.ReadLine();

                            var cmd = new AddCustomerCommand(customerId, name);
                            _commandHandler.Handle(cmd);

                            Console.WriteLine();
                            Console.WriteLine("Customer added");
                        }
                        break;

                    case 2: // Remove Customer
                        {
                            Console.Write("Customer ID (number): ");
                            var id = Console.ReadKey().KeyChar.ToString();
                            int.TryParse(id, out int customerId);

                            var cmd = new RemoveCustomerCommand(customerId);
                            _commandHandler.Handle(cmd);

                            Console.WriteLine();
                            Console.WriteLine("Customer removed");
                        }
                        break;

                    case 3: // View all Customers
                        Console.WriteLine(_queryHandler.Handle(new GetAllCustomersQuery()));
                        break;

                    case 4: // Find Customer
                        {
                            Console.Write("Customer ID (number): ");
                            var id = Console.ReadKey().KeyChar.ToString();
                            int.TryParse(id, out int customerId);
                            
                            var qry = new FindCustomerQuery(customerId);

                            Console.WriteLine();
                            Console.WriteLine(_queryHandler.Handle(qry));
                        }
                        break;

                    default:// Invalid choice - skip and display start menu
                        break;
                }

                // 3)
                Console.WriteLine();
                Console.WriteLine("Menu ( M )");
                Console.WriteLine("Exit ( X )");

                keypress = Console.ReadKey().KeyChar.ToString();
            } while (keypress.ToLower() != "x");
        }
    }
}
