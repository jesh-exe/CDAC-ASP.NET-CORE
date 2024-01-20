namespace AbstractExamples
{

    //This is abstract class which cant be instantiated and contains Abstract + Non Abstract Methods....
    public abstract class AbstractClass
    {
        //This is the pure virtual method which has no body and is virtual
        public abstract void display(string name);
        public void hide()
        {
            Console.WriteLine("In Hide...!!!");
        }

    }

    public sealed class SealedClass
    {
        
        public void SealedMethod(string name)
        {
            Console.WriteLine("In Sealed Method!");
        }

    }

    internal class BaseClass : AbstractClass
    {
        //This is the mandatory method of the Abstract Class
        //If we wish not to override the method, then we need to make this class as Abstract
        public override void display(string name)
        {
            Console.WriteLine("In BaseClass");
        }
    }

    internal class Tester
    {
        static void Main(string[] args)
        {
            BaseClass ob = new BaseClass();
            ob.display("test");
            SealedClass obj = new SealedClass();
            obj.SealedMethod("test");
            Console.WriteLine("Hello, World!");
        }
    }
}
