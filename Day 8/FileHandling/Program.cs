using System.Text;

namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //writeByteData();
            //readByteData();

            //writeStream();
            //readStream();

        }
        
        static void writeByteData()
        {
            //We use FileStream to write data from byte array to a file, which const. takes path and file mode as input
            //Filemode create - creates a new File, or overrites
            FileStream file = new FileStream("D:\\2.CDAC ACTS\\.NET Core-C# - Vikram Sulakhe\\Lab\\Class Work\\Day 8\\Files\\binaryFile.txt", FileMode.Create);
            string str = "Hi DOT.NET, I am Jayesh!";
            
            //We need to convert out string to the byte array using inbuilt converter
            byte[] buffer = Encoding.Default.GetBytes(str);

            //Using the write method of FileStream which takes he byte array, from to where as input
            file.Write(buffer, 0, buffer.Length);
            file.Close();
            Console.WriteLine("Binary Data Writted!");
        }
        static void readByteData()
        {

            FileStream file = new FileStream("D:\\2.CDAC ACTS\\.NET Core-C# - Vikram Sulakhe\\Lab\\Class Work\\Day 8\\Files\\binaryFile.txt", FileMode.Open);
            //We need a buffer array which will be filled by the data read from the file
            //But what about the size? we use the Lenght of FileStream
            byte[] buffer = new byte[file.Length];
            //Reades the data
            file.Read(buffer, 0, buffer.Length);
            //Converts the data from byte to string
            string str = Encoding.Default.GetString(buffer);
            Console.WriteLine(str);
            file.Close();
        }


        static void writeStream()
        {
            //Stream writer is just like our console write line, easy and simple
            //We need to create an instance of StreamWrite and CreateText to be created
            StreamWriter writer = File.CreateText("D:\\2.CDAC ACTS\\.NET Core-C# - Vikram Sulakhe\\Lab\\Class Work\\Day 8\\Files\\binaryFile.txt");
            //We can directly write the data using method WriteLine
            writer.WriteLine("Hi DOT NET, I am Jayesh!");
            writer.WriteLine("You are tough to understand, but");
            writer.WriteLine("Not for Me!");
            writer.Close();
        }
        static void readStream()
        {
            StreamReader reader = File.OpenText("D:\\2.CDAC ACTS\\.NET Core-C# - Vikram Sulakhe\\Lab\\Class Work\\Day 8\\Files\\binaryFile.txt");
            string str = reader.ReadToEnd();
            Console.WriteLine(str);
        }

    }
}
