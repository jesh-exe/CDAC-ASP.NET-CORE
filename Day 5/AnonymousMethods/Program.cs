namespace AnonymousMethods
{
    
    internal class Tester
    {

        static void Display()
        {
            Console.WriteLine("In Display");
        }
        
        static void Main(string[] args)
        {
            Action action = Display;
            action();

            Action o1 = delegate ()
            {
                Console.WriteLine("In Anom Func");
            };
            o1();

            Func<int,int,int> o2 = delegate (int a,int b)
            {
                return a + b;
            };
            Console.WriteLine(o2(5,10));

            Action o3 = () => { Console.WriteLine("In Lambda"); };
            o3();

            Func<int,int,int> o4 = (a,b) => a + b;
            Console.WriteLine(o4(10,40));

            Predicate<int> o5 = a => a == 5 ;
            Console.WriteLine(o5(5));

        }

    }

}