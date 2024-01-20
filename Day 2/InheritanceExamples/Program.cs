namespace InheritanceExamples
{

    class BaseClass
    {
        int num1;
        int num2;

        //If we want this function to overload, we need to make this function VIRTUAL to be ready for overriding.
        //Also we need to write override keyword where ever we wish to override it in other Derived class.
        //VIRTUAL methods are Late Binded, decided on Runtime so it will be decided by the type of Object reference is
        //pointing to
        //EXM : BaseClass obj = new DerivedClass(); --> Invoke Overriden method of DerivedClass
        public virtual void OverrideMethod()
        {
            Console.WriteLine("In the BaseClass Overriden method");
        }

        public void HiddenMethod()
        {
            Console.WriteLine("In the Hidden Method of Base Class");
        }

        //Here overloading is diff as of java and cpp, overloading is done between inherited clases if same signature is kept then its
        //method HIDING
        public void OverloadedMethod()
        {
            Console.WriteLine("In OverloadedMethod");
        }
    }


    class DerivedClass : BaseClass
    {
        int num3;
        int num4;

        /*
         * If you wish to stop the overloading of a method for further Derived classes, then just add sealed keyword
         * It will stop the derived class from overriding the method
         */
        
        //public sealed override void OverrideMethod()
        //{
        //    Console.WriteLine("In Derived Class Overrided Method");
        //}

        public override void OverrideMethod()
        {
            Console.WriteLine("In Derived Class Overrided Method");
        }

        //As I have written the same method with same signature as given in the Base Class, this is called as HIDING a method
        //This method will only be invoked by the same reference of a object as of where the Hidden Method is written
        //exm : DerivedClass obj = ANY OBJECT
        public new void HiddenMethod()
        {
            Console.WriteLine("In the Hidden Method of Derived Class");
        }

        public void OverloadedMethod(int a)
        {
            Console.WriteLine("In Overloaded Method of Derived Class");
        }

    }

    class SubDerived : DerivedClass
    {
        int num5;
        public override void OverrideMethod()
        {
            Console.WriteLine("In Subderived Override Method");
        }
        public new void HiddenMethod()
        {
            Console.WriteLine("In Hidden Method of Subderived Class");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Base class reference containing Base class object
            BaseClass obj1 = new DerivedClass();
            //Invokes the Override Method according to the Object type
            obj1.OverrideMethod();
            //Invokes the Hidden Method according to the Reference
            obj1.HiddenMethod();
            obj1.OverloadedMethod();

            (obj1 as BaseClass).OverrideMethod();

            BaseClass objBase = new DerivedClass();
            objBase.OverrideMethod();
            objBase.HiddenMethod();
            objBase.OverloadedMethod();

            BaseClass baseClass = new SubDerived();
            baseClass.OverrideMethod();
            baseClass.HiddenMethod();

            DerivedClass obj = new DerivedClass();
            obj.OverrideMethod();
            obj.HiddenMethod();
            obj.OverloadedMethod(1);

            SubDerived sbObj = new SubDerived();
            sbObj.OverrideMethod();
            sbObj.HiddenMethod();

            Console.WriteLine("Hello, World!");
        }
    }
}

