using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Windows.Annotations;

namespace Employee_MVC_v2._0.Models
{
    public class Employee
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Employee Number is Required")]
        public int EmpNo { get; set; }
        
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee Name is Required")]
        [MinLength(3,ErrorMessage = "Minimum Length is 3")]
        public string Name { get; set; }

        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Employee Basic is Required")]
        public decimal Basic { get; set; }
        
        [Display(Name = "Department Number")]
        [Required(ErrorMessage = "Employee Department Number is Required")]
        public int DeptNo { get; set; }

        public static List<Employee> EmpList()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection())
            {
                //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employee";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new Employee(){EmpNo=reader.GetInt32("EmpNo"),Name=reader.GetString("Name"),Basic=reader.GetDecimal("Basic"),DeptNo=reader.GetInt32("DeptNo")});
                }
                reader.Close();
            }
            return employees;
        }

        public static Employee GetEmployeeById(int EmpId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Employee emp = null;
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employee where EmpNo = @EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpId);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                    emp = new Employee() { EmpNo = reader.GetInt32("EmpNo"), Name = reader.GetString("Name"), Basic = reader.GetDecimal("Basic"), DeptNo = reader.GetInt32("DeptNo") };
                
                reader.Close();
                return emp;
            }
        }

        public static void AddEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";
                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                Console.WriteLine(cmd.ExecuteNonQuery() + " Record Inserted!");
            }
        }

        public static void UpdateEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";
                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteEmployee(int EmpNo)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEmployee";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.ExecuteNonQuery();
            }
        }


    }

}
