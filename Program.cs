using System.Collections.Generic;
using System;


class Program
{
    public static void Main()
    {
        Ludi ludi = new Ludi();
        WithGift list = new WithGift();
        NoGift list2 = new NoGift();
        Add add = new Add(list, list2);
        string command;
        bool exit = true;
        do
        {
            Console.WriteLine("Введите команду");
            command = Console.ReadLine();
            switch (command)
            {
                case "add":
                    add.Execute();
                    break;
                case "exit":
                    exit = false;
                    break;
                case "yg":
                    list.Execute();
                    break;
                case "ng":
                    list2.Execute();
                    break;
            }
        }
        while (exit);


    }
}



public class Ludi
{
    public string FIO { get; set; }
    public string Status { get; set; }
    public string Gift { get; set; }
}

public abstract class Command
{
    public abstract void Execute();
}

public class WithGift : Command
{
    public Dictionary<string, string> withGift = new Dictionary<string, string>();
    //public List<string> withGift = new List<string>(); 
    public override void Execute()
    {
        foreach (var ludi in withGift.Keys)
        {
            foreach (var gift in withGift.Values)
            {
                Console.WriteLine($"{ludi}: ");
            }
        }
    }
}

public class NoGift : Command
{

    public List<string> withoutGift = new List<string>();
    public override void Execute()
    {
        foreach (var ludi in withoutGift)
        {
            Console.WriteLine(ludi);
        }
    }
}
/*public class SearchGift : Command 
{ 
    Add add = new Add(); 
    public override void Execute() 
    { 
        foreach (string wg in add.withGift) 
        { 
            Console.WriteLine(wg); 
        } 
    } 
}*/





public class Add : Command
{
    WithGift withGift1;
    NoGift noGift;
    public Add(WithGift withGift, NoGift noGift)
    {
        this.withGift1 = withGift;
        this.noGift = noGift;
    }
    Ludi ludi = new Ludi();
    public override void Execute()
    {
        Console.WriteLine("Введите ФИО");
        string fio = Console.ReadLine();
        ludi.FIO = fio;
        Console.WriteLine("Введите статус");
        string status = Console.ReadLine();
        ludi.Status = status;
        Console.WriteLine("Дать подарок или нет(Да/нет)");
        string gift = Console.ReadLine();
        if (gift == "да" || gift == "Да" || gift == "lf")
        {
            Console.WriteLine("Какой подарок подарить?");
            string podarit = Console.ReadLine();
            Console.WriteLine("Подарок подарен");
            ludi.Gift = podarit;
            withGift1.withGift.Add(fio, fio);

        }
        else if (gift == "нет" || gift == "Нет" || gift == "ytn")
        {
            Console.WriteLine("Ну и обойдётся");
            noGift.withoutGift.Add(fio);
        }


    }
}

/*class CommandManager 
{ 
 
    Dictionary<string, (string dscrp, Command commanddscrp)> commands = new(); 
    public void Start() 
    { 
        string command; 
        do 
        { 
            Console.WriteLine("Введите команду"); 
            command = Console.ReadLine(); 
        } 
        while (command != "exit"); 
    } 
}*/