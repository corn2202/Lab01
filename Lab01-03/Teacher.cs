using System;

public class Teacher : Person
{
    private string address;

    public Teacher() { }

    public Teacher(string id, string fullname, string address)
        : base(id, fullname) // Gọi constructor của lớp Person
    {
        this.Address = address;
    }

    public string Address { get => address; set => address = value; }

    public override void Input()
    {
        base.Input(); // Gọi Input của Person
        Console.Write($"Nhập địa chỉ: ");
        Address = Console.ReadLine();
    }

    public override void Output()
    {
        base.Output(); // Gọi Output của Person
        Console.WriteLine(" {0,-40} |", this.Address);
    }
}