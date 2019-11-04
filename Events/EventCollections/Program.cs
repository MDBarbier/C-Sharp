using System;
using System.ComponentModel;

namespace EventCollections
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.PhoneChanged += PhoneChangedHandler;
            p.Name = "Matt Barbier";
            p.Phone = "07753193349";

            Console.WriteLine("Execution finished");
        }

        private static void PhoneChangedHandler(object sender, EventArgs e)
        {
            Person p = sender as Person;
            Console.WriteLine($"The phone number has been updated to {p.Phone} for {p.Name}");
        }
    }

    public class Person
    {
        private string _name;
        private string _phone;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;

                //Invoke the Handlers now
                OnPhoneChanged();
            }
        }

        //The EventHandlerList is used if you have a lot of Events for performance purposes
        protected EventHandlerList EventDelegateCollection = new EventHandlerList();

        static readonly object PhoneChangedEventKey = new object();

        public event EventHandler PhoneChanged
        {
            add
            {
                EventDelegateCollection.AddHandler(PhoneChangedEventKey, value);
            }
            remove
            {
                EventDelegateCollection.RemoveHandler(PhoneChangedEventKey, value);
            }
        }

        private void OnPhoneChanged()
        {
            //Get the subscribed delegates of the supplied type
            EventHandler subscribedDelegates = (EventHandler)this.EventDelegateCollection[PhoneChangedEventKey];

            //Notify the matching delegates
            subscribedDelegates(this, EventArgs.Empty);
        }
    }
}
