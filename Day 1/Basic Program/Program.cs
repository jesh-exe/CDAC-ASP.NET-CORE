using Calculator;

//Namespace is holder of multiple classes, there can be many namespaces in one project
//It hold unique class, but diff namespace can hold same named classes.
//To access class we use namespaceName.className
namespace Basic_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.Console.WriteLine
            //System -> Namespace
            //Console -> Class
            //WriteLine -> Method

            //We dont use System in start because we have included the System namespace in Using in project Settings
            Console.WriteLine("Hello, World!");
            
            //This is the static method of Operations class, so we dont need object to call it, just the class name
            //IT WONT WORK BY INVOKING IT WITH OBJECT 
            Operations.addByStatic(10, 20);

            //CREATION obj REFERENCE OF CLASS OPERATIONS
            Operations obj = new Operations();
            obj.add(20, 30);

            Console.WriteLine("End Of Program");
        }
    }
}

namespace Calculator { 

    internal class Operations { 
    
        //public void add(int a, int b)
        //{
        //    Console.WriteLine(a + b);
        //}

        //This method gives a way to call add method by min 0 param or max 3 param as default of all param are 0 if not given 
        //by the use
        //If we wish to make any parameter mandatory, then we need to remove the default value of that param and make sure to add
        //Mandatory param from the start of Arguments
        public void add(int a=0,int b=0,int c=0)
        {
            Console.WriteLine(a + b);
        }

        public static void addByStatic(int a, int b)
        {
            Console.WriteLine(a + b);
        }

    }

}

