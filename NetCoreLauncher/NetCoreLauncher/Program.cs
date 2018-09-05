using System;
using System.Diagnostics;
using System.IO;

namespace NetCoreLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = typeof(Program).Assembly;
            var assemblyFileName = $"{Path.GetFileNameWithoutExtension(assembly.Location)}.dll";
            //assemblyFileName = "ConsoleApp1.dll";
            Console.WriteLine($"Assembly File Name: {assemblyFileName}");

            if (!File.Exists(assemblyFileName))
            {
                Console.WriteLine("The assembly is not found.");
                return;
            }

            // dotnet ConsoleApp1.dll
            var info = new ProcessStartInfo("dotnet", assemblyFileName)
            {
                UseShellExecute = false,
            };
            Process.Start(info).WaitForExit();
        }
    }
}
