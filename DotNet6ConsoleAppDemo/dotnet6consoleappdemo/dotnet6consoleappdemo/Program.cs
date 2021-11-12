﻿using dotnet6consoleappdemo;
using System.Diagnostics;

#region Main

var stopwatch = new Stopwatch();
stopwatch.Start();
await LongRunningProcess(3000);
Console.WriteLine(GetMessage("Matt"));

ExtraClass extraClass = new ExtraClass();
Console.WriteLine(extraClass.GetMessage());

Console.WriteLine($"Finished in {stopwatch.Elapsed}");
stopwatch.Stop();

#endregion


#region Local functions

string GetMessage(string name) => $"Hello {name}";

async Task LongRunningProcess(int delay)
{
    await Task.Delay(delay);
}

#endregion