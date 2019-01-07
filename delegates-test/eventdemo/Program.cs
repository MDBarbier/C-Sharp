using System;

namespace SampleApp
{
    public delegate string MyDel(string str);

    class EventProgram
    {
        event MyDel MyEvent;
        event MyDel MyEvent2;
        
        //Constructor
        public EventProgram()
        {
            this.MyEvent += new MyDel(this.WelcomeUser); //Assigns the Delegate "MyDel" to the event declared above
            this.MyEvent2 += new MyDel(HelloWorld);
        }

        //Action method
        public string WelcomeUser(string username)
        {
            return "Welcome " + username;
        }

        public string HelloWorld(string _)
        {
            return "HelloWorld";
        }

        //Main method
        static void Main(string[] args)
        {
            EventProgram obj1 = new EventProgram(); //Instantiate our class

            string result = obj1.MyEvent("Tutorials Point"); //Fire the event, passing in the string to the delegated method which has been attached
            string result2 = obj1.MyEvent2("This will be trashed");

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadLine();
        }
    }
}