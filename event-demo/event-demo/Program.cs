using System;
namespace eventdemo
{
    public class Metronome
    {
        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(Metronome m, EventArgs e);

        public void Start()
        {
            while (true) //never ending loop
            {
                System.Threading.Thread.Sleep(3000);

                //Original version
                    //if (Tick != null)
                    //{
                    //    Tick(this, e);
                    //}

                Tick?.Invoke(this, e); //Invokes the Tick event, which in turn calls the method assigned through the delegate (HeardIt)
            }
        }
    }

    public class Metronome2
    {
        public event TickHandler Tick;        
        public delegate void TickHandler(Metronome2 m, TimeOfTick e);

        public void Start()
        {
            while (true) //never ending loop
            {
                System.Threading.Thread.Sleep(3000);
                
                if (Tick != null)
                {
                    TimeOfTick TOT = new TimeOfTick();
                    TOT.Time = DateTime.Now;
                    Tick(this, TOT);
                }
                
            }
        }
    }

    public class TimeOfTick : EventArgs
    {
        private DateTime TimeNow;

        public DateTime Time
        {
            set
            {
                TimeNow = value;
            }
            get
            {
                return this.TimeNow;
            }
        }
    }

    public class Listener
    {
        public void Subscribe(Metronome m)
        {
            //add an event handler to the event "Tick"
            //Note that we are assigning the delegate TickHandler, and the method we are passing in is HeardIt 
            //This method is part of the listener rather than the metronome - because of the delegate and the fact HeardIt has the same signature as the Delegate so works
            m.Tick += new Metronome.TickHandler(HeardIt); 
        }
        private void HeardIt(Metronome m, EventArgs e)
        {
            System.Console.WriteLine("HEARD IT");
        }

    }

    public class Listener2
    {
        public void Subscribe(Metronome2 m)
        {
            //add an event handler to the event "Tick"
            //Note that we are assigning the delegate TickHandler, and the method we are passing in is HeardIt 
            //This method is part of the listener rather than the metronome - because of the delegate and the fact HeardIt has the same signature as the Delegate so works
            m.Tick += new Metronome2.TickHandler(HeardIt);
        }
        private void HeardIt(Metronome2 m, TimeOfTick e)
        {
            System.Console.WriteLine("HEARD IT AT " + e.Time);
        }

    }
    class Test
    {
        static void Main()
        {
            Metronome2 m = new Metronome2(); //create new instance of metronome
            Listener2 l = new Listener2(); //create new listener instance
            l.Subscribe(m); //call listener's subscribe method, passsing in the instance of metronome
            m.Start(); //call the metronome's start method
        }
    }
}