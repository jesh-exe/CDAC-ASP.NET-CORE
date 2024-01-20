namespace Delegates
{
    internal class Program
    {
        /*
         *  Delegates are used to call Functions indirectly, to make it happen we need to make a
         *  delegate class.
         *  Delegate class is made for a function or a group of function which has a same method signature
         *  
         *  For example for method Add with 3 input parameters, I have made a Delegate 1 with 3 params
         *  Similary for Add with 2 params,
         *  and a Delegate 3 for method Display and Show as they have same signature
         * 
         */

        public delegate int Delegate1(int a, int b, int c);

        public delegate int Delegate2(int a, int b);

        public delegate void Delegate3();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            //Make a object of Delegate1 for Add(a,b,c) method and assign Method name to the object for which delegate was made
            Delegate1 objD1 = Add;
            //Another way to call the Add method we can write method name inside he constructor of Delegate1
            Delegate1 objD11 = new Delegate1(Add);
            //To call the method Add(a,b,c) just write the object with () and add parameters if mentioned in method and delegate
            Console.WriteLine(objD1(80,10,10));
            //Add with 2 Params
            Delegate2 objD2 = Add;
            Console.WriteLine(objD2(10, 20));
            Delegate3 objD3 = Display;

            //We can also combine more than 1 object of our delegate to call the methods
            Delegate3 obj = (Delegate3)Delegate.Combine(new Delegate3(Display), new Delegate3(Show));
            //obj();
            
            //Another way to use combine
            //Delegate.Combine(new Delegate3(Display), new Delegate3(Show)).DynamicInvoke();

            obj += Display;         //Adds the Display method call in the stack 
            obj();
            obj -= Show;            //Removing the Show method call from the stack
            obj();

        }

        public static void Display()
        {
            Console.WriteLine("In Display");
        }
        public static void Show()
        {
            Console.WriteLine("In Show");
        }
        public static int Add(int a=10,int b=20)
        {
            Console.WriteLine("In Add2");
            return a + b;
        }
        public static int Add(int a,int b,int c)
        {
            Console.WriteLine("In Add3");
            return a + b + c;
        }
    }
}


namespace MathOperations
{

    
    public delegate int Delegate1(int a, int b);
    
    internal class Tester {

        public static void Main1()
        {
            Console.WriteLine(Operation(Calculate.Add));
        }

        public static int Operation(Delegate1 obj)
        {
            return obj(10, 20);
        }
    }

    internal class Calculate
    {

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Substract(int a, int b)
        {
            return a - b;
        }


    }

}