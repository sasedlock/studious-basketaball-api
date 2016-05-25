using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandAndQuery.Command.CommandHandlers;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var idk = typeof (BasketballTeamCreateCommand);



            Console.WriteLine(typeof (BasketballTeamCreateCommand));

            Console.ReadLine();
        }
    }
}
