using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using zav4;

namespace zav4
{
    class Program
    {
        static void Main(string[] args)
        {
            string allowedFile = "allowed.txt";
            string deniedFile = "secret.txt";

            File.WriteAllText(allowedFile, "Roman\nVernitskyi!");
            File.WriteAllText(deniedFile, "This is secret!");

            Console.WriteLine("\nChecker Proxy");
            SmartTextReader checker = new SmartTextChecker();
            checker.ReadFile(allowedFile);

            Console.WriteLine("\nLocker Proxy");
            SmartTextReader locker = new SmartTextReaderLocker("secret");
            locker.ReadFile(deniedFile);
            locker.ReadFile(allowedFile);
        }
    }
}

