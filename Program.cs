using System;
using Noesis.Javascript;

namespace Javascript.NET
{
    public class SystemConsole
    {
        public SystemConsole() { }

        public void Print(string iString)
        {
            Console.WriteLine(iString);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // sample from http://javascriptdotnet.codeplex.com/

            // Initialize a context
            using (var context = new JavascriptContext())
            {

                // Setting external parameters for the context
                context.SetParameter("console", new SystemConsole());
                context.SetParameter("message", "Hello World !");
                context.SetParameter("number", 1);

                // Script
                var script = @"
        var i;
        for (i = 0; i < 5; i++)
            console.Print(message + ' (' + i + ')');
        number += i;
    ";

                // Running the script
                context.Run(script);

                // Getting a parameter
                Console.WriteLine("number: " + context.GetParameter("number"));
                Console.ReadKey();
            }
        }
    }
}
