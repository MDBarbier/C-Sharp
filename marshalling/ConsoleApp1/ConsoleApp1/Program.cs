using System;
using System.Runtime.InteropServices;

public class ConsoleApp1
{
    [DllImport("kernel32.dll")]
    static extern bool GetSystemTimes(out long idleTime, out long kernelTime, out long userTime);

    public static void Main()
    {
        long idleTime, kernelTime, userTime;

        GetSystemTimes(out idleTime, out kernelTime, out userTime);
        Console.WriteLine("Your CPU(s) have been idle for: " + (new TimeSpan(idleTime)).ToString());
        Console.ReadKey();
    }
}