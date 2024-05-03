// See https://aka.ms/new-console-template for more information
using CSharpConsoleAppWithDLL;

#region callDllMethods

int total = WrapperClass.Add(8, 3);

int multiply = WrapperClass.Multiply(5, 10);
Console.WriteLine("Total Multiply method: " + multiply + ", Total Add method: " + total);

#endregion


