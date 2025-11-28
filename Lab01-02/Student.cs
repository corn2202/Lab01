using System;
using System.Text;

namespace Lab01_02
{
    class Student
    {
        // 1. Field
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        // 2. Property
        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public float AverageScore
        {
            get => averageScore;
            set => averageScore = value;
        }
        public string Faculty { get => faculty; set => faculty = value; }

        // 3. Constructor
        public Student()
        {
        }
        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        // 4. Methods
        public void Input()
        {
            Console.Write("Nhập MSSV:");
            StudentID = Console.ReadLine();
            Console.Write("Nhập Họ tên Sinh viên:");
            FullName = Console.ReadLine();

            Console.Write("Nhập Điểm TB:");
            if (float.TryParse(Console.ReadLine(), out float score))
            {
                AverageScore = score;
            }
            else
            {
                Console.WriteLine("Điểm không hợp lệ, đặt mặc định là 0.");
                AverageScore = 0;
            }

            Console.Write("Nhập Khoa:");
            Faculty = Console.ReadLine();
        }

        // HÀM MỚI: Trả về chuỗi đã định dạng (cần cho hàm Show())
        public string GetFormattedString()
        {
            // Căn chỉnh cột: MSSV 10 ký tự, Họ tên 25, Khoa 10, Điểm TB 8 (2 chữ số thập phân)
            return String.Format("| {0,-10} | {1,-25} | {2,-10} | {3,8:F2} |",
                                 this.StudentID, this.fullName, this.Faculty, this.AverageScore);
        }

        // HÀM CHỈNH SỬA: Dùng để hiển thị ra Console
        public void Show()
        {
            Console.WriteLine(GetFormattedString());
        }
    }
}