using EmployeeMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeMVC.DAL
{
    public interface IEmployeeDal
    {
        void AddEmployee(Employee emp);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        void DeleteEmployee(Employee emp);
        void UpdateEmployee(Employee emp);

    }
    public class EmployeeDal : IEmployeeDal
    {
        private readonly SqlConnection connection;

        public EmployeeDal()
        {
            connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeMVC;Integrated Security=True;";
        }

        public void AddEmployee(Employee emp)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Employee values(@Name, @City, @Address)";
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@City",emp.City);
                cmd.Parameters.AddWithValue("@Address",emp.Address);
                cmd.ExecuteNonQuery();

                connection.Close();

            }catch (Exception ex)
            {
                throw new Exception("Database Error!");
            }
        }

        public void DeleteEmployee(Employee emp)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;


                connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Error!");
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandType= CommandType.Text;
                cmd.CommandText = "select * from Employee";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee() { Id = reader.GetInt32("Id"), Name = reader.GetString("Name"), City = reader.GetString("City"), Address = reader.GetString("Address") };
                    list.Add(emp);
                }
                reader.Close();
                connection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error!");
            }
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = new Employee();
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employee where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    emp = new Employee() { Id = reader.GetInt32("Id"), Name = reader.GetString("Name"), City = reader.GetString("City"), Address = reader.GetString("Address") };
                }

                reader.Close();
                connection.Close();
                return emp;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error!");
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Employee set Name=@Name,City=@City,Address=@Address where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Error!");
            }
        }
    }
}
