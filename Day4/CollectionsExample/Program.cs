using System.Collections;
using System.Collections.Generic;

namespace CollectionsExample
{
    internal class ArrayListExample
    {
        static void Main1(string[] args)
        {
            //Non-Generic
            ArrayList arrList = new ArrayList();
            arrList.Add(1);
            arrList.Add(2);
            arrList.Add(6);
            arrList.Add(9);
            arrList.Add(14);
            arrList.Add(3);
            arrList.Remove(3);
            arrList.RemoveAt(2);
            int[] arr = new int[arrList.Count];
            arrList.CopyTo(arr);
            arrList.Sort();
            arrList.BinarySearch(10);
            arrList.Contains(14);
            IEnumerator iterator = arrList.GetEnumerator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
            Console.WriteLine(arrList[4]);

            Console.WriteLine(arrList.ToArray());

            Hashtable ht = new Hashtable();
            ht.Add(1, 2);
            ht.Add(2, 3);
            ht.Add(3, 4);
            ht.Add(4, 5);
            foreach(DictionaryEntry item in ht)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
            //arrList.Clear();

            //Generic
            
            List<int> list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(6);
            list.Add(9);
            list.Add(14);
            list.Add(3);
            list.Remove(3);
            list.RemoveAt(2);
            int[] arr1 = new int[arrList.Count];
            list.CopyTo(arr);
            list.Sort();
            list.BinarySearch(10);
            list.Contains(14);


            Dictionary<int, string> d = new Dictionary<int, string>();

        }
    }

    internal class DictionaryExample
    {
        public static void Main()
        {

            //Non-Generic
            IDictionary map = new Hashtable();
            map.Add(1, "Jayesh");
            map.Add(2, "ABSD");
            map.Add(3, "OASDSD");
            map.Add(4, "PDJKNFDPSFS");
            map.Add(5, "KASMDKSDFSD");
            map.Add(6, "ASDASDAS");

            map.Remove(2);
            map.Contains(5);

            foreach(DictionaryEntry de in map)
            {
                Console.WriteLine(de.Key);
                Console.WriteLine(de.Value);
            }

            Dictionary<int,string> dic = new Dictionary<int,string>();

            dic.Add(1,"Jayesh");
            dic.Add(2,"ASDASd");
            dic.Add(3,"AFDGDFG");
            dic.Add(4,"SDFGSDF");
            dic.ContainsKey(5);
            dic.ContainsValue("Jayesh");

            foreach(KeyValuePair<int,string> pair in dic)
            {
                Console.WriteLine(pair.Value);
                Console.WriteLine(pair.Key);
            }


        }
    }

}