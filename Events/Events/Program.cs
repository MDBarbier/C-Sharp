using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter(5);
            
            //Assign our event handler to the event so that when it is fired our handler will get called
            //This is all the "client" code knows about the internal workings of Counter
            c.ThresholdReached += c_ThresholdReachedA;
            c.ThresholdReached += c_ThresholdReachedB;

            Console.WriteLine("press 'a' key to increase total, any other key to exit");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }

            Console.WriteLine("Another key than 'a' was pressed, execution complete.");
        }

        //Event handler method, literally just a regular method that happens to have been associated to the Event being fired because it was linked to the event and matches the delegate signature for the event
        static void c_ThresholdReachedA(object sender, EventArgs e)
        {
            Console.WriteLine("Eventhandler A: The threshold was reached.");            
        }

        //Event handler method, literally just a regular method that happens to have been associated to the Event being fired because it was linked to the event and matches the delegate signature for the event
        static void c_ThresholdReachedB(object sender, EventArgs e)
        {
            Console.WriteLine("Eventhandler B: The threshold was reached.");
        }
    }

    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        //Our work method, which calls the event raising method when a condition is met
        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                OnThresholdReached(EventArgs.Empty);
            }
        }

        protected virtual void OnThresholdReached(EventArgs e)
        {
            //This line actually fires the event and any listening methods will be invoked
            ThresholdReached?.Invoke(this, e);

            /*The below are older ways of doing the above */ 

            //EventHandler handler = ThresholdReached;
            //handler?.Invoke(this, e);

            //EventHandler handler = ThresholdReached;
            //if (handler != null)
            //{
            //    handler(this, e);
            //}
        }

        //Here we declare our event, specifying EventHandler Delegate as the associated handler
        public event EventHandler ThresholdReached;
    }
}
