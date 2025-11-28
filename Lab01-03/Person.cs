using System;

public class Person
{
    private string id;
    private string fullname;

    public Person() { }

    public Person(string id, string fullname)
    {
        this.Id = id;
        this.FullName = fullname;
    }

    public string Id { get => id; set => id = value; }
    public string FullName { get => fullname; set => fullname = value; }

    // Dùng virtual để các lớp con có thể override
    public virtual void Input()
    {
        Console.Write("Nhập mã số: ");
        Id = Console.ReadLine();
        Console.Write("Nhập họ và tên: ");
        FullName = Console.ReadLine();
    }

    // Dùng virtual để các lớp con có thể override
    public virtual void Output()
    {
        Console.Write("| {0,-10} | {1,-25} |", this.Id, this.FullName);
    }
}