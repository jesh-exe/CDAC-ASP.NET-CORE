namespace BasicProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PropertyExample obj = new PropertyExample();
            //Traditional way to access datatypes, but what if we want to use private vars
            //We use getter and setters, but also that is to tedious task
            //So Microsoft provides with a easy way called as Property --> written in PropertyExample
            obj.num1 = 10;

            LocalMethod objLocalMethod = new LocalMethod();
            objLocalMethod.parentMethod();


            ContructorExample constructorExample = new ContructorExample();
            constructorExample = new ContructorExample(10);
            constructorExample = new ContructorExample(10,20);
            constructorExample = new ContructorExample(10,20,30);
            constructorExample = new ContructorExample(10, num2: 10, 30);
        }
    }

    public class LocalMethod
    {
        /*
         *  As we know that we cannot access the local variables declared inside the method/function so we got a new topic known as Local Method
         *  In which we can declare the Local Method inside the Parent Method and cann access all the variables declared inside the 
         *  
         */
        public void parentMethod()
        {
            int parent_num = 10;
            void childMethod()
            {
                int parent_num = 10;
                parent_num = 20;
                parent_num = 30;
            }
            childMethod();
            Console.WriteLine(parent_num);
        }

    }

    public class PropertyExample
    {
        public int num1;

        private int num2;
        //Num2 is property of num2 field, naming convention of property is Pascal casing and for field is CamelCasing
        /*
         *  In property there is only 2 method available to use, get and set
         *  get is used to return the value
         *  set is used to set the value
         *  but we can see that Num2 doesnt take any parameter as input so where is the parameter we used as value stored?
         *  value is a keyword only used in the set method which takes the values sent by the user.
         *  
         *  We can either use get , set or both in a property and a property in always linked with a specific 
         *  
         *  But you can look that we are going to write such a large code repeatedly for all the fields we are going
         *  to declare in our class
         *  So for that there is a new syntax we gonna use for fast and better readeability
         */
        public int Num2
        {
            get {
                return num2;
            }
            set {
                num2 = value;
            }
        }

        /*
         *  Better way of writing a normal get and set without actually even creating a variable num3
         *  It will automatically create a new private variable num3 and get and set method related to it
         */
        public int Num3 { set; get; }
    }

    

    public class ContructorExample
    {

        private int num1;
        private int num2;
        private int num3;
        private static int num4;
        public ContructorExample(int num1 = 0, int num2=0, int num3=0)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.num3 = num3;
        }

        /*
         * Can only access the static fields and not the non static fields
         * Is called upon either the class loading or accessing the static field
         */

        static ContructorExample()
        {
            num4 = 10;
        }

    }
    




}