using System;
using System.IO;
using zav1;

interface ILogger
{
    void Log(string message);
    void Error(string message);
    void Warn(string message);
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("== Console Logger ==");
        Logger logger = new Logger();
        logger.Log("Everything OK");
        logger.Warn("Warn");
        logger.Error("Something wrong");

        Console.WriteLine("\n== File Logger через адаптер ==");
        FileWriter fw = new FileWriter("log.txt");
        ILogger fileLogger = new FileLoggerAdapter(fw);
        fileLogger.Log("Writed in File: Everything OK");
        fileLogger.Warn("Writed in File: Warn");
        fileLogger.Error("Writed in File: Something wrong");
        System.Diagnostics.Process.Start("notepad.exe", "log.txt");

    }
}
