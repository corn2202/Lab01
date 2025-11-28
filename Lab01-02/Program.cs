using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            bool exit = false;

            // Dữ liệu mẫu để kiểm tra chức năng
            studentList.Add(new Student("SV001", "Nguyễn Văn A", 9.5f, "CNTT"));
            studentList.Add(new Student("SV002", "Trần Thị B", 6.8f, "CNTT"));
            studentList.Add(new Student("SV003", "Lê Văn C", 8.2f, "Điện tử"));
            studentList.Add(new Student("SV004", "Phạm Văn D", 4.0f, "CNTT"));
            studentList.Add(new Student("SV005", "Hoàng Thị E", 7.5f, "Kế toán"));
            studentList.Add(new Student("SV006", "Vũ Trung F", 3.0f, "Cơ khí"));
            studentList.Add(new Student("SV007", "Nguyễn Thị G", 9.0f, "Điện tử")); // Thêm SV Điện tử điểm cao

            while (!exit)
            {
                // CẬP NHẬT MENU Ở ĐÂY
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Hiển thị SV thuộc khoa (Nhập từ bàn phím)");
                Console.WriteLine("4. Hiển thị SV có điểm TB >= 5");
                Console.WriteLine("5. Sắp xếp SV theo điểm TB tăng dần");
                Console.WriteLine("6. Hiển thị SV đạt yêu cầu của khoa (Nhập từ bàn phím)");
                Console.WriteLine("7. Danh sách SV có ĐTB cao nhất của khoa (Nhập từ bàn phím)");
                Console.WriteLine("8. Thống kê xếp loại theo Khoa (Nhập từ bàn phím)"); // ĐÃ SỬA MÔ TẢ
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-8): ");

                string choice = Console.ReadLine();
                Console.WriteLine("---------------------------------------------------------------");

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        Console.WriteLine("=== Danh sách chi tiết thông tin sinh viên ===");
                        DisplayStudentList(studentList);
                        break;
                    case "3":
                        Console.Write("Nhập tên Khoa cần hiển thị: ");
                        string facultyInput3 = Console.ReadLine();
                        DisplayStudentsByFaculty(studentList, facultyInput3);
                        break;
                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        Console.Write("Nhập tên Khoa cần lọc: ");
                        string facultyInput6 = Console.ReadLine();
                        Console.Write("Nhập điểm TB tối thiểu (>=): ");
                        if (float.TryParse(Console.ReadLine(), out float minScore))
                        {
                            DisplayStudentsByFacultyAndScore(studentList, facultyInput6, minScore);
                        }
                        else
                        {
                            Console.WriteLine("Điểm không hợp lệ.");
                        }
                        break;
                    case "7":
                        Console.Write("Nhập tên Khoa cần tìm SV có ĐTB cao nhất: ");
                        string facultyInput7 = Console.ReadLine();
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, facultyInput7);
                        break;
                    case "8": 
                        Console.Write("Nhập tên Khoa cần thống kê xếp loại: ");
                        string facultyInput8 = Console.ReadLine();
                        CountStudentsByRank(studentList, facultyInput8);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine();
            }
        }

        // --- HÀM HỖ TRỢ HIỂN THỊ BẢNG (Giữ nguyên) ---
        static void PrintHeader()
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

            PrintHeader();
            foreach (Student student in studentList)
            {
                // Giả định Class Student có hàm Show() in ra định dạng hàng
                // Lưu ý: Cần đảm bảo hàm student.Show() in ra đúng định dạng
                // Console.WriteLine("| {0,-10} | {1,-25} | {2,-10} | {3,8:F2} |", student.ID, student.Name, student.Faculty, student.AverageScore);
                student.Show();
            }
            Console.WriteLine("+------------+---------------------------+------------+----------+");
        }

        // --- CÁC HÀM XỬ LÝ CHỨC NĂNG (Thực hiện yêu cầu 8) ---

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            // Giả định Class Student có hàm Input()
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        // Chức năng 3 (Giữ nguyên logic)
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0} ===", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty,
                StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        // Chức năng 4 (Giữ nguyên logic)
        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} ===", minDTB);
            var students = studentList.Where(s => s.AverageScore >= minDTB).ToList();
            DisplayStudentList(students);
        }

        // Chức năng 5 (Giữ nguyên logic)
        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần === ");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore).ToList();
            DisplayStudentList(sortedStudents);
        }

        // Chức năng 6 (Giữ nguyên)
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} và thuộc khoa {1} ===", minDTB, faculty);
            var students = studentList
                .Where(s => s.AverageScore >= minDTB &&
                            s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(students);
        }

        // Chức năng 7 (Giữ nguyên)
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

            Console.WriteLine($"Điểm trung bình cao nhất của khoa {faculty} là: {maxScore:F2}");
            DisplayStudentList(studentsWithHighestScore);
        }

        // CHỨC NĂNG 8: Thống kê xếp loại theo Khoa 
        static void CountStudentsByRank(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"=== Thống kê số lượng sinh viên theo xếp loại của khoa {faculty} ===");

            // Lọc sinh viên theo khoa nhập vào
            var filteredStudents = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filteredStudents.Count == 0)
            {
                Console.WriteLine($"Không tìm thấy sinh viên nào thuộc khoa {faculty} để thống kê.");
                return;
            }

            // Thực hiện thống kê trên danh sách đã lọc
            Dictionary<string, int> rankCounts = new Dictionary<string, int>()
            {
                {"Xuất sắc", 0}, {"Giỏi", 0}, {"Khá", 0},
                {"Trung bình", 0}, {"Yếu", 0}, {"Kém", 0}
            };

            foreach (var student in filteredStudents)
            {
                string rank = GetStudentRank(student.AverageScore);
                // Đảm bảo khóa tồn tại trước khi tăng
                if (rankCounts.ContainsKey(rank))
                {
                    rankCounts[rank]++;
                }
            }

            // In kết quả thống kê
            foreach (var pair in rankCounts.OrderByDescending(p => p.Value))
            {
                // Chỉ in ra các loại xếp loại có sinh viên
                if (pair.Value > 0)
                {
                    Console.WriteLine($"- {pair.Key}: {pair.Value} sinh viên");
                }
            }
        }

        // Hàm phụ trợ để xác định xếp loại (Giữ nguyên)
        static string GetStudentRank(float score)
        {
            if (score >= 9.0f)
                return "Xuất sắc";
            else if (score >= 8.0f)
                return "Giỏi";
            else if (score >= 7.0f)
                return "Khá";
            else if (score >= 5.0f)
                return "Trung bình";
            else if (score >= 4.0f)
                return "Yếu";
            else
                return "Kém";
        }
    }
}