using Microsoft.Data.SqlClient;
using System.Data;

/*
 * 
 *  Prerequisites for Database in .NET
 *  
 *  DOWNLOADING Dependencies :-
 *  Go to Tools -> NuGet Package Manager -> Manage Nu Get Package for Solution
 *      -> Browse -> Search "Microsoft.Data.SQLClient" -> Download
 *      
 *  Creating Database :-
 *  1. Go to View -> SQL Server Object Explorer
 *  2. Go in localDb-> Right on the Databses -> Add New Database -> Give the name and Create
 *  
 *  Creating Table :-
 *  1. Go in your created DB -> Right click Tables -> Add New Table
 *  2. Change the name of Table from the below window
 *  3. You can change the table structure either by GUI or Query Window provided, also there is option
 *      to add Constraints on Right side window
 *  4. At the END do not forget to click Update on upper left corner to save the details of your table
 *      
 *  View Table Data :-
 *  Under your Database, there would be your table in Tables
 *  Right click on the table -> View Data
 *  You can directly enter the data from the gui provided.
 * 
 */

// BOILER PLATE
//using (SqlConnection conn = new SqlConnection())
//{
//    conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
//    conn.Open();
//    try
//    {
//
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}
namespace DatabasePractise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //addEmployeeByQuery();
            //addEmployeeByParameters();
            //addEmployeeByStoredProcedure(new Employee() {EmpId=3,Name="Arpit",Basic=32000,DeptNo=3});

            //selectByScalar();
            //selectAllByDataReader();
            //Employee emp = selectEmployeeById(2);
            //Console.WriteLine(emp);
        }

        /*TO Insert Data*/
        //Done using HardCoded Values in Query
        //
        //
        static void addEmployeeByQuery()
        {
            //I have got the SqlConnection from the Class Connection at the end
            SqlConnection conn = Database.Connection.GetConnection();
            try
            {
                //To execute any query, we need to make SqlCommand object
                SqlCommand cmd = conn.CreateCommand();
                //We need to set the type of command we gonna pass, either Text or Procedure
                cmd.CommandType = CommandType.Text;
                //Then we set the query (Hardcoded here)
                cmd.CommandText = "insert into Employee values (1,'Jayesh',25000,1)";

                //ExecuteNonQuery fires the query and returns the number of rows affected
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted " + rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //DO NOT FORGET TO CLOSE THE CONNECTION
                Database.Connection.CloseConnection();
            }
        }

        //Done using Dynamic Parameter in Query
        //
        //
        static void addEmployeeByParameters()
        {
            //Using block to auto close the connection
            //Creating an instance of Connection
            using (SqlConnection conn = new SqlConnection())
            {
                //This connection string is obtained from the properties of out DB
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();
                try
                {

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    //Parameters are marked as @AnyNameButUnique in string
                    cmd.CommandText = "insert into Employee values (@EmpId,@Name,@Basic,@DeptNo)";

                    //This is the way to set the @ tagged parameter names with our specific value
                    cmd.Parameters.AddWithValue("@EmpId", 2);
                    cmd.Parameters.AddWithValue("@Name", "Ayushi");
                    cmd.Parameters.AddWithValue("@Basic", 40000);
                    cmd.Parameters.AddWithValue("@DeptNo", 2);

                    Console.WriteLine(cmd.ExecuteNonQuery() + " Record Inserted");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //Recommended to avoid SQL Injection and Data Concatenation Problem of Escape Characters
        //Done using Stored Procedure with Dynamic Parameters
        //Refere InsertEmployee Procedure for syntax
        static void addEmployeeByStoredProcedure(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    //Setting the Command Type as StoredProcedure to invoke the procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Name of procedure is passed in Command Text , only name is required
                    cmd.CommandText = "InsertEmployee";

                    //Again setting the parameters as mentioned in the procedure
                    cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                    cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                    Console.WriteLine(cmd.ExecuteNonQuery() + " Record Inserted!");

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /*To Select Data*/
        //Select using ExecuteScalar
        //This method only returns the First Column's First Row's Element - 1 Entity basically
        //So even if select statement returns multiple entity, it will only give the first one
        static void selectByScalar()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select Name from Employee where EmpId = 2";

                    //This method returns the Object class type
                    object value = cmd.ExecuteScalar();
                    //Downcasting it to string
                    Console.WriteLine((string)value);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //Select Using SqlDataReader
        //This is used to read multiple lines of data from the select query
        //It can read full data from the database, and points before the first data before iterating
        static void selectAllByDataReader()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Employee";

                    //Creating instance of SqlDataReader which gets the data from SqlCommand's method Execute Reader
                    //This will return all the data of select query
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    //We need while loop to iterate the reader, and we use read() method to move towards next pointer,
                    //if there is values we can read it, or else it returns null
                    while (reader.Read())
                    {
                        //Using Indexer to fetch the Row Data Column wise from the pointer
                        //There is other way to read the data , written in below method
                        Console.WriteLine(reader["EmpId"] + " " + reader["Name"] + " " + reader["Basic"] + " " + reader["DeptNo"]);
                    }
                    //Remember to close the READER
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //Select query to fetch single data from the database
        //
        //
        static Employee selectEmployeeById(int EmpId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Employee emp = new Employee();
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
               
                conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Employee where EmpId = @EmpId";

                    cmd.Parameters.AddWithValue("@EmpId",EmpId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        //reader.Get{DataType} converts the reader's output to desired object
                        emp = new Employee() { EmpId = EmpId, Name = reader.GetString("Name"), Basic = reader.GetInt32("Basic"), DeptNo = reader.GetInt32("DeptNo") };

                    reader.Close();
                    return emp;
            }
        }


    }

    internal class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Basic { get; set; }
        public int DeptNo { get; set; }

        public override string? ToString()
        {
            return EmpId+" "+Name+" "+Basic+" "+DeptNo;
        }
}
}


namespace Database
{
    public class Connection
    {
        //Creating and instance of SqlConnection
        private static SqlConnection connection = new SqlConnection();

        //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;
        //Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
        //Application Intent=ReadWrite;Multi Subnet Failover=False

        public static SqlConnection GetConnection()
        {
            //Before opening the connection, we need to set the connection string indicating the database for which
            //the connection is to be opened
            //This is obtained from the Properties of you Database, not everything is important of ConnectionString
            connection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
            connection.Open();
            return connection;
        }

        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

    }
}