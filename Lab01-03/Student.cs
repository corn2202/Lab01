using System;

public class Student : Person
{
    private float averageScore;
    private string faculty;

    public Student() { }

    public Student(string id, string fullname, float averageScore, string faculty)
        : base(id, fullname) // Gọi constructor của lớp Person
    {
        this.AverageScore = averageScore;
        this.Faculty = faculty;
    }

    public float AverageScore { get => averageScore; set => averageScore = value; }
    public string Faculty { get => faculty; set => faculty = value; }

    public override void Input()
    {
        base.Input(); // Gọi Input của Person
        Console.Write($"Nhập Khoa ({this.Faculty}): ");
        Faculty = Console.ReadLine();

        // Vòng lặp nhập điểm cho đến khi hợp lệ
        float score;
        while (true)
        {
            Console.Write("Nhập điểm trung bình: ");
            if (float.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 10)
            {
                AverageScore = score;
                break;
            }
            Console.WriteLine("Điểm không hợp lệ (0-10). Vui lòng nhập lại.");
        }
    }

    public override void Output()
    {
        base.Output(); // Gọi Output của Person
        Console.WriteLine(" {0,-10} | {1,8:F2} |", this.Faculty, this.AverageScore);
    }
}