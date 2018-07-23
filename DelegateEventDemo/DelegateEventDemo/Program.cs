using System;

namespace EventSample
{
    public delegate void ContractHandler(Employee sender);

    public class Employee
    {
        private bool bIsEngaged = false;
        private int iAge = -1;
        private String strName = null;
        public event ContractHandler Engaged;

        public Employee()
        {
            this.Engaged += new ContractHandler(this.OnEngaged);
        }

        private void OnEngaged(Employee sender)
        {
            Console.WriteLine("private void OnEngaged was called! this employee is engaged now!");
        }

        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        public int Age
        {
            get { return iAge; }
            set { iAge = value; }
        }

        public bool IsEngaged
        {
            get { return bIsEngaged; }
            set
            {
                if (bIsEngaged == false && value == true)
                {
                    Engaged(this);
                }
                bIsEngaged = value;
            }
        }
    }

    public class EntryPointClass
    {
        static void Main(string[] a_strArgs)
        {
            Employee simpleEmployee = new Employee();

            simpleEmployee.Age = 18;
            simpleEmployee.Name = "Samanta Rock";

            simpleEmployee.Engaged += new ContractHandler(SimpleEmployee_Engaged);

            //simpleEmployee.IsEngaged = true;

            Console.ReadLine();

            return;
        }

        static void SimpleEmployee_Engaged(Employee sender)
        {
            Console.WriteLine("The employee {0} is happy!", sender.Name);
        }
    }
}