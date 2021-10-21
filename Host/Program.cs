using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {

          
           ServiceHost serviceHost = new ServiceHost(typeof(EmployeesService.ManageEmployees), new Uri("http://localhost:800/EmployeesService"));
            try
            {
                
                serviceHost.Open();

            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                Console.Read();
            }
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.ReadLine();

        }
    }
}
