using System;

class SampleCollection<T>
{
    // Declare an array to store the data elements.
    private T[] arr = new T[100];

    // Define the indexer to allow client code to use [] notation.
    public T this[int i]
    {
        get { return arr[i]; }
        set { arr[i] = value; }
    }
}

class Program
{
    static void Main()
    {
        var stringCollection = new SampleCollection<string>();
        stringCollection[0] = "Hello, World";
        stringCollection[1] = "Greetings chummer";
        Console.WriteLine(stringCollection[0]);
        Console.WriteLine(stringCollection[1]);

        var personCollection = new SampleCollection<Person>();
        personCollection[0] = new Person() { Name = "Matt", Age = 36 };

        Console.WriteLine($"{personCollection[0].Name}, {personCollection[0].Age}");

        Console.ReadLine();
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}