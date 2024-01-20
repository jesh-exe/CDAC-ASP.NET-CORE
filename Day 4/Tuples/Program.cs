namespace Tuples
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Tuple<int, string, decimal> t1 = new Tuple<int, string, decimal>(1,"Jayesh",100.10m);
            
            var t2 = new Tuple<int, string, decimal>(1, "Jayesh", 100.10m);

            var t3 = Tuple.Create(1, "Jayesh", 100.10m);

            (int, string) vt1 = (1,"jayesh");

            Console.WriteLine(vt1.Item1);

            var vt2 = (1, "jayesh");

            (int roll, string name) vt3 = (1, "jayesh");

            Console.WriteLine(vt3.roll);

            var vt4 = (roll: 1, name: "Jayesh");
            Console.WriteLine(vt4.name);

            var t4 = Tuple.Create(1, 2, 3, 4, 5, 6,7,Tuple.Create(1,2,3,4,5,6,7, Tuple.Create(543, 756)));

            Console.WriteLine(t4.Rest.Item1.Rest.Item1.Item2);

        }
    }


}