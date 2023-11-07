using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        (new Thread(() =>
        {
            Computer comp2 = new Computer();
            comp2.OS = OS.getInstance("Singleton new Thread Windows Vista");
            Console.WriteLine(comp2.OS.Name);
        })).Start();

        Computer comp = new Computer();
        comp.Launch("Windows 8.1");
        Console.WriteLine(comp.OS.Name);

        // у нас не получится изменить ОС, так как объект уже создан    
        comp.OS = OS.getInstance("Windows 10");
        Console.WriteLine(comp.OS.Name);

        Singleton singleton = Singleton.GetInstance();
        Console.WriteLine("Singleton " + singleton.Date);


        Thread.Sleep(500);
        (new Thread(() =>
        {
            Singleton singleton2 = Singleton.GetInstance();
            Console.WriteLine("Singleton new Thread " + singleton2.Date);
        })).Start();
    }
}

class Computer
{
    public OS OS { get; set; }
    public void Launch(string osName)
    {
        OS = OS.getInstance(osName);
    }
}

class OS
{
    private static OS instance;
    public string Name { get; private set; }
    protected OS(string name)
    {
        Name = name;
    }
    public static OS getInstance(string name)
    {
        if (instance == null)
            instance = new OS(name);

        return instance;
    }
}

public class Singleton
{
    private static readonly Singleton instance = new Singleton();
    public string Date { get; private set; }
    private Singleton()
    {
        Date = DateTime.Now.TimeOfDay.ToString();
    }
    public static Singleton GetInstance()
    {
        return instance;
    }
}