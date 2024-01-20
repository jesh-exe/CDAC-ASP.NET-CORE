namespace AccessSpecifierRelatedStuff
{

    /*
     *  Access Specifiers Related Stuff
     *  1. PUBLIC --> Accessed from Anywhere
     *  2. PRIVATE --> Accessed within the class
     *  3. PROTECTED --> Accessed within the class or in the Derived Class
     *  4. INTERNAL --> Accessed from the Same class or Same Assembly (Project)
     *  5. INTERNAL PROTECTED -->   Accessed from the same class, derived class and Same Project(Assembly)
     *  6. PRIVATE PROTECTED --> Accessed from the same class and Assembly
     *  
     */

    public class BaseClass
    {
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        internal protected int INTERNAL_PROTECTED;
        private protected int PRIVATE_PROTECTED;
    }

    public class DerivedClass : BaseClass
    {
        
        public void Main()
        {

            //PUBLIC++;
            //PROTECTED;
            //INTERNAL
            //INTERNAL_PROTECTED
            //PRIVATE_PROTECTED

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BaseClass bs = new BaseClass();
            //bs.INTERNAL;
            //bs.INTERNAL_PROTECTED;
            //bs.PUBLIC;

        }
    }
}