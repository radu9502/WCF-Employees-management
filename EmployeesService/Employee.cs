using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmployeesService
{
    [DataContract(Namespace = "EmployeesService")]
     public class Employee
    {
        int id;
        string firstName;
        string lastName;

        [DataMember]
        public string FirstName { get { return firstName; } set { firstName = value; } }
        [DataMember]
        public string LastName { get { return lastName; } set { lastName = value; } }
        [DataMember]
        public int Id { get { return id; } set { id = value; } }

        public Employee(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader["id"]);
            FirstName = reader["firstName"].ToString();
            LastName = reader["lastName"].ToString();

        }
        public Employee(int _id)
        {
            Id = _id;
        }
        public Employee(string _firstName, string _lastName)
        {

            FirstName = _firstName;
            LastName = _lastName;

        }
        public Employee(int _id, string _firstName, string _lastName)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;

        }
    }
}
