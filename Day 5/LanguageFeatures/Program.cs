namespace AnonymousClass
{
    internal class Tester
    {
        static void Main0(string[] args)
        {
            var class1 = new { Id=10, Name="Jayesh" };
            var class2 = new { Id=50, Name="Arpit" };
            var class3 = new { Id=20, Status=false, Course="DAC" };

            Console.WriteLine(class1.Id+" "+class1.Name);
            Console.WriteLine(class2.Id+" "+class2.Name);
        }
    }
}

namespace PartialClass
{
    public partial class PartialClass
    {
        public int id;
    }

    public partial class PartialClass
    {
        public string? name;
    }

    internal class Tester
    {
        public static void Main1(string[] args)
        {
            PartialClass obj = new PartialClass();
            obj.id = 10;
            obj.name = "Jayesh";
            obj.status = true;
            Console.WriteLine(obj.id+" "+obj.name+" "+obj.status);
        }
    }
}

namespace PartialMethodExample
{
    public partial class Class1
    {
        partial void Display();
        public int id;
        public void CheckDisplayWorking()
        {
            Console.WriteLine("IN Check");
            Display();
        }
    }
    public partial class Class1
    {
        partial void Display()
        {
            Console.WriteLine("In Display");
        }
    }
    internal class Tester
    {
        public static void Main2(string[] args)
        {
            Class1 obj = new Class1();
            obj.CheckDisplayWorking();
        }


    }
}

namespace ExtensionMethodExample
{
    public static class MyExtensions
    {
        public static void Display(this int intObj)
        {
            Console.WriteLine(intObj);
        }
        public static int Add(this int intObj, int b)
        {
            return intObj+b;
        }
        public static void DisplayStudent(this Student obj)
        {
            Console.WriteLine(obj.Id+" "+obj.Name);
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    internal class Tester
    {
        public static void Main(string[] args)
        {
            int i = 100;
            i.Display();
            Console.WriteLine(i.Add(200));

            Student obj = new Student() { Id=10, Name="Jayesh" };
            obj.DisplayStudent();
            //MyExtensions.DisplayStudent(obj);     Internal Code for above line
        }
    }
}
