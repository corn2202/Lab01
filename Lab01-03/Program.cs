using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            List<Teacher> teacherList = new List<Teacher>();
            bool exit = false;

            // Dữ liệu mẫu
            studentList.Add(new Student("SV001", "Nguyễn Văn A", 9.5f, "CNTT"));
            studentList.Add(new Student("SV002", "Trần Thị B", 6.8f, "CNTT"));
            studentList.Add(new Student("SV003", "Lê Văn C", 8.2f, "Điện tử"));
            studentList.Add(new Student("SV004", "Phạm Văn D", 4.0f, "CNTT"));
            studentList.Add(new Student("SV005", "Hoàng Thị E", 7.5f, "Kế toán"));

            teacherList.Add(new Teacher("GV001", "Phan Văn X", "Quận 9, TP Thủ Đức"));
            teacherList.Add(new Teacher("GV002", "Trịnh Thị Y", "Quận 1, TP HCM"));
            teacherList.Add(new Teacher("GV003", "Lê Quang Z", "Quận 9, TP Thủ Đức"));
            teacherList.Add(new Teacher("GV004", "Nguyễn Đình K", "Quận 7, TP HCM"));


            while (!exit)
            {
                DisplayMenu();
                Console.Write("Chọn chức năng (0-9): ");

                string choice = Console.ReadLine();
                Console.WriteLine("------------------------------------------------------------------");

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        AddTeacher(teacherList);
                        break;
                    case "3":
                        Console.WriteLine("=== Danh sách sinh viên ===");
                        DisplayStudentList(studentList);
                        break;
                    case "4":
                        Console.WriteLine("=== Danh sách giáo viên ===");
                        DisplayTeacherList(teacherList);
                        break;
                    case "5":
                        CountTotal(studentList, teacherList);
                        break;
                    case "6":
                        Console.Write("Nhập tên Khoa cần hiển thị: ");
                        string facultyInput6 = Console.ReadLine();
                        DisplayStudentsByFaculty(studentList, facultyInput6);
                        break;
                    case "7":
                        Console.Write("Nhập thông tin Địa chỉ cần tìm: ");
                        string addressInput7 = Console.ReadLine();
                        DisplayTeachersByAddress(teacherList, addressInput7);
                        break;
                    case "8":
                        Console.Write("Nhập tên Khoa cần tìm SV có ĐTB cao nhất: ");
                        string facultyInput8 = Console.ReadLine();
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, facultyInput8);
                        break;
                    case "9":
                        CountStudentsByRank(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine("\n==================================================================\n");
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Thêm giáo viên");
            Console.WriteLine("3. Xuất danh sách sinh viên");
            Console.WriteLine("4. Xuất danh sách giáo viên");
            Console.WriteLine("5. Số lượng từng danh sách (tổng số SV, tổng số GV)");
            Console.WriteLine("6. Xuất danh sách các Sinh Viên thuộc khoa (Nhập từ bàn phím)");
            Console.WriteLine("7. Xuất ra danh sách giáo viên có địa chỉ chứa thông tin (Nhập từ bàn phím)");
            Console.WriteLine("8. Xuất ra danh sách sinh viên có điểm trung bình cao nhất và thuộc khoa (Nhập từ bàn phím)");
            Console.WriteLine("9. Thống kê xếp loại (Xuất sắc, Giỏi, Khá,...)");
            Console.WriteLine("0. Thoát");
        }

        // --- HÀM HỖ TRỢ HIỂN THỊ BẢNG ---

        static void PrintStudentHeader()
        {
            string separator = "+------------+---------------------------+------------+----------+";
            Console.WriteLine(separator);
            Console.WriteLine("| {0,-10} | {1,-25} | {2,-10} | {3,8} |", "MSSV", "HỌ VÀ TÊN", "KHOA", "ĐIỂM TB");
            Console.WriteLine(separator);
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            if (studentList == null || studentList.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }
            PrintStudentHeader();
            foreach (Student student in studentList)
            {
                student.Output();
            }
            Console.WriteLine("+------------+---------------------------+------------+----------+");
        }

        static void PrintTeacherHeader()
        {
            string separator = "+------------+---------------------------+------------------------------------------+";
            Console.WriteLine(separator);
            Console.WriteLine("| {0,-10} | {1,-25} | {2,-40} |", "Mã GV", "HỌ VÀ TÊN", "ĐỊA CHỈ");
            Console.WriteLine(separator);
        }

        static void DisplayTeacherList(List<Teacher> teacherList)
        {
            if (teacherList == null || teacherList.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }
            PrintTeacherHeader();
            foreach (Teacher teacher in teacherList)
            {
                teacher.Output();
            }
            Console.WriteLine("+------------+---------------------------+------------------------------------------+");
        }


        // --- CÁC HÀM XỬ LÝ CHỨC NĂNG ---

        // Chức năng 1
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        // Chức năng 2
        static void AddTeacher(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Nhập thông tin giáo viên ===");
            Teacher teacher = new Teacher();
            teacher.Input();
            teacherList.Add(teacher);
            Console.WriteLine("Thêm giáo viên thành công!");
        }

        // Chức năng 5
        static void CountTotal(List<Student> studentList, List<Teacher> teacherList)
        {
            Console.WriteLine("=== Thống kê số lượng ===");
            Console.WriteLine($"- Tổng số Sinh viên: {studentList.Count}");
            Console.WriteLine($"- Tổng số Giáo viên: {teacherList.Count}");
            Console.WriteLine($"- Tổng cộng (SV + GV): {studentList.Count + teacherList.Count}");
        }

        // Chức năng 6
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"=== Danh sách sinh viên thuộc khoa {faculty} ===");
            var students = studentList.Where(s => s.Faculty.Equals(faculty,
                StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        // Chức năng 7
        static void DisplayTeachersByAddress(List<Teacher> teacherList, string addressKeyword)
        {
            Console.WriteLine($"=== Danh sách giáo viên có địa chỉ chứa '{addressKeyword}' ===");
            var teachers = teacherList.Where(t => t.Address.IndexOf(addressKeyword,
                StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            DisplayTeacherList(teachers);
        }

        // Chức năng 8
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"=== Danh sách sinh viên khoa {faculty} có điểm trung bình cao nhất ===");

            var filteredStudents = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filteredStudents.Count == 0)
            {
                Console.WriteLine($"Không tìm thấy sinh viên nào thuộc khoa {faculty}.");
                return;
            }

            // Tìm điểm cao nhất
            float maxScore = filteredStudents.Max(s => s.AverageScore);

            // Lọc ra các sinh viên đạt điểm cao nhất
            var studentsWithHighestScore = filteredStudents
                .Where(s => s.AverageScore == maxScore)
                .ToList();

            Console.WriteLine($"Điểm trung bình cao nhất của khoa {faculty} là: {maxScore:F2} ({studentsWithHighestScore.Count} người)");
            DisplayStudentList(studentsWithHighestScore);
        }

        // Chức năng 9
        static void CountStudentsByRank(List<Student> studentList)
        {
            Console.WriteLine("=== Thống kê số lượng sinh viên theo xếp loại ===");

            Dictionary<string, int> rankCounts = new Dictionary<string, int>()
            {
                {"Xuất sắc (9.0-10)", 0}, {"Giỏi (8.0-8.9)", 0},
                {"Khá (7.0-7.9)", 0}, {"Trung bình (5.0-6.9)", 0},
                {"Yếu (4.0-4.9)", 0}, {"Kém (dưới 4.0)", 0}
            };

            foreach (var student in studentList)
            {
                string rank = GetStudentRank(student.AverageScore);
                // Dùng switch hoặc if để tăng count cho loại phù hợp (hoặc chỉnh sửa GetStudentRank)
                if (student.AverageScore >= 9.0f) rankCounts["Xuất sắc (9.0-10)"]++;
                else if (student.AverageScore >= 8.0f) rankCounts["Giỏi (8.0-8.9)"]++;
                else if (student.AverageScore >= 7.0f) rankCounts["Khá (7.0-7.9)"]++;
                else if (student.AverageScore >= 5.0f) rankCounts["Trung bình (5.0-6.9)"]++;
                else if (student.AverageScore >= 4.0f) rankCounts["Yếu (4.0-4.9)"]++;
                else rankCounts["Kém (dưới 4.0)"]++;
            }

            // In kết quả thống kê
            foreach (var pair in rankCounts.OrderByDescending(p => p.Key)) // Sắp xếp để Xuất sắc ở trên
            {
                Console.WriteLine($"- {pair.Key,-20}: {pair.Value} sinh viên");
            }
        }

        // Hàm phụ trợ để xác định xếp loại (chỉ dùng để tham khảo, logic đã đưa vào CountStudentsByRank)
        static string GetStudentRank(float score)
        {
            if (score >= 9.0f) return "Xuất sắc";
            else if (score >= 8.0f) return "Giỏi";
            else if (score >= 7.0f) return "Khá";
            else if (score >= 5.0f) return "Trung bình";
            else if (score >= 4.0f) return "Yếu";
            else return "Kém";
        }
    }
}