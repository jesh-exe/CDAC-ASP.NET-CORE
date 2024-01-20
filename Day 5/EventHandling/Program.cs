namespace EventHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            EventHandlingClass obj = new EventHandlingClass();

            //obj.SetSalary(500);

            obj.ButtonHandler += Users_ButtonHandler;
            obj.InvalidInput += Obj_InvalidInput;

            obj.ButtonIsClicked(true);
        }

        private static void Users_ButtonHandler()
        { 
            Console.WriteLine("Logged In");
        }

        private static void Obj_InvalidInput()
        {
            Console.WriteLine("Button is Not Clicked!");
        }
    }


    //Developer's Code
    //public delegate void Delegate1();
    //public delegate void Delegate2();

    internal class EventHandlingClass
    {
        //public event Delegate1 InvalidInput;
        //public event Delegate2 ButtonHandler;

        //No Need of Delegates if Action or Func used
        public event Action InvalidInput;
        public event Action ButtonHandler;

        public void SetSalary(int sal)
        {
            if (sal > 1000)
                Console.WriteLine("input is valid");
            else
            {
                if(InvalidInput != null)
                    InvalidInput();
            }
        }

        public void ButtonIsClicked(bool isClicked)
        {
            if(isClicked==true)
            {
                if (InvalidInput != null)
                    ButtonHandler();
            }
            else
            {
                if (InvalidInput != null)
                    InvalidInput();
            }
        }

    }

}