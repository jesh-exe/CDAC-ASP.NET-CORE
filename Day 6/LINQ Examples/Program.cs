namespace LINQ_Examples
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }



    internal class Program
    {
        static List<Employee> empList = new List<Employee>();
        static List<Department> deptList = new List<Department>();
        public static void AddRecs()
        {
            deptList.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            deptList.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            deptList.Add(new Department { DeptNo = 30, DeptName = "IT" });
            deptList.Add(new Department { DeptNo = 40, DeptName = "HR" });

            empList.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            empList.Add(new Employee { EmpNo = 2, Name = "Vishal", Basic = 11000, DeptNo = 10, Gender = "M" });

            empList.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            empList.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            empList.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            empList.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            empList.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            empList.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
      

        //Traditional Way
        //Select Queries
        static void Main0(string[] args)
        {
            AddRecs();

            
            //Select the whole employee
            IEnumerable<Employee> emps = from emp in empList select emp;
            //Other way to avoid IEnumerable
            //var emps = from emp in empList select emp;

            //Select specific data from Employee class, we can only select 1 thing in particular
            IEnumerable<string> emps1 = from emp in empList select emp.Name;

            //To select more than one property of Employee, we need to make Anonymous Class
            var emps2 = from emp in empList select new { emp.Name, emp.Basic };

            foreach(var emp in emps2)
                Console.WriteLine(emp.Name+" "+emp.Basic);

        }

        //Where Queries
        static void Main1(string[] args)
        {
            AddRecs();

            //where keyword is used to add Conditions to the LINQ
            var emps = from emp in empList where emp.Basic>10000 select emp;

            //We can provide && || conditions also
            var emps1 = from emp in empList where emp.Basic>10000 && emp.Name.StartsWith('S') select emp;


            foreach(var emp in emps1)
            {
                Console.WriteLine(emp.Name);
            }

        }

        //Join Queries
        static void Main2(string[] args)
        {
            AddRecs();

            //We need 3 keywords to use Join query - join, on, equals
            var emps = from emp in empList join dept in deptList on emp.DeptNo equals dept.DeptNo select emp;

            //We will mostly use anonymous class to get the Join Query data as we need data from both the list
            var emps1 = from emp in empList join dept in deptList on emp.DeptNo equals dept.DeptNo select new {emp.Name, dept.DeptName};

            foreach (var obj in emps1)
                Console.WriteLine(obj.Name+" "+obj.DeptName);
        }


        //New Way
        //Select Queries
        static void Main4(string[] args)
        {
            AddRecs();
            //Using Select method of empList to fetch all the information of Employee
            var emps = empList.Select(obj => obj);

            //Using Select method to fetch data by anonymous
            var emps1 = empList.Select(obj => new {obj.Name, obj.Basic});
            
            foreach (var item in emps1)
                Console.WriteLine(item.Name +" "+ item.Basic);
        }

        //Where Queries
        static void Main5(string[] args)
        {
            AddRecs();
            
            //Where condition using where method, gives the whole object of Employee
            var emps = empList.Where(obj => obj.Name.StartsWith('S'));

            //Where + Select to select particular data by particular condition
            var emps1 = empList.Where(obj => obj.Name.StartsWith('S')).Select(obj => new { obj.Name });

            //var emps2 = empList.Select(obj => new { obj.Name }).Where(obj => obj.Basic>2000);   This throws error as where is not preferred before Select

            foreach (var item in emps1)
                Console.WriteLine(item.Name);

        }

        //Join Queries
        static void Main6(string[] args)
        {
            AddRecs();

            //Join Query
            //1st -> other list to perform join
            //2nd -> on which property of first list to apply join
            //3rd -> on which property of second list to apply join
            //4th -> what to select from the result
            var emps = empList.Join(deptList, emp => emp.DeptNo, dept => dept.DeptNo, (emp,dept) => new {emp.Name, dept.DeptName});

            foreach (var item in emps)
                Console.WriteLine(item.Name+" "+item.DeptName);
        }

        //OrderBy Queries
        static void Main7()
        {
            AddRecs();
            var emps = empList.OrderBy(obj => obj.Name);
            var emps1 = empList.OrderByDescending(obj => obj.Name);

            //to multiple sort
            var emps2 = empList.OrderBy(obj => obj.Name).ThenBy(obj => obj.DeptNo);

            foreach (var item in emps1)
                Console.WriteLine(item.Name+" "+item.DeptNo);
        }

    }

}