using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesService
{
    public class ManageEmployees : IManageEmployees
    {
        List<Employee> employees = new List<Employee>();

        SqlConnection conn = new SqlConnection("Server=DESKTOP-BV1K2CO\\SQLEXPRESS;Database=Northwind;Integrated Security=True;");
        public void Add(Employee emp)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"INSERT INTO Employees VALUES('{emp.FirstName}','{emp.LastName}')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Delete(Employee emp)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"DELETE FROM Employees WHERE id= {emp.Id} ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Edit(Employee emp)
        {
            SqlConnection conn = new SqlConnection("Server=DESKTOP-BV1K2CO\\SQLEXPRESS;Database=Northwind;Integrated Security=True;");
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"Update Employees firstName = '{emp.FirstName}', lastName = '{emp.LastName}' where id = {emp.Id} ;");
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        

        }

        public string Read(Employee emp)
        {
            string JSONString = string.Empty;
            List<Employee> employees = new List<Employee>();
          
            SqlConnection conn = new SqlConnection("Server=DESKTOP-BV1K2CO\\SQLEXPRESS;Database=Northwind;Integrated Security=True;");


            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees", conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee(reader);
                            employees.Add(employee);
                            JSONString = JsonConvert.SerializeObject(employees);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return JSONString;
    

        }
    

        public void Update(Employee emp)
        {
          
                try
                {
                    using (conn)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand($"UPDATE Employees SET firstName = '{emp.FirstName}', lastName = '{emp.LastName}' where id = {emp.Id}",conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            

        }

     
    }
}
