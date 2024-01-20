namespace IndexAndRanges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
            
            Index index = new Index(10);
            Console.WriteLine(arr[index]);

            index = new Index(3, true);
            Console.WriteLine(arr[index]);

            Console.WriteLine(arr[^3]);

            //arr[..];      Returns all the elements of array
            //arr[3..];     Returns first 3 elements of array
            //arr[^3..];    Returns last 3 elements of array

        }
    }
}