using System;
using System.Collections.Generic;

namespace RecursionExample
{
    internal class RecursionExample
    {
        static void Main()
        {
            var items = new List<string> { "Node1", "Node2", "Node3" };

            string output = BuildRecursionTree("", items, 0);

            // Result: Node1 <- Node2 <- Node3 <-.
            Console.Write(output);
        }

        static string BuildRecursionTree(string value, IList<string> items, int index)
        {
            // "index" variable value checking helps call recursive function finite number of times.
            if (items.Count == index)
            {
                return value;
            }

            // Add node.
            value += " " + items[index] + " <-";

            // Actual recursion: call function itself once more time.
            return BuildRecursionTree(value, items, index + 1);
        }
    }
}