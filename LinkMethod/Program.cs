public class Program
{
public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double Tuition { get; set; }
    }
    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }
    }
    public class StudentGPA
    {
        public int StudentID { get; set; }
        public double GPA { get; set; }
    }
        public static void Main()
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 1, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 2, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 3, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 5, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };
            // Student GPA Collection
             IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
             // Club collection
             IList<StudentClubs> studentClubList = new List<StudentClubs>() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
        };
        var result = studentGPAList.Where(s => s.StudentID > 0).GroupBy(s => s.GPA);
        var result2 = studentClubList.OrderBy(s => s.ClubName).GroupBy(s => s.ClubName);
        var result3 = studentList.Where(s => s.Tuition == 5500);

        var count = studentGPAList.Count(s => s.GPA >= 2.5 && s.GPA <= 4.0);
        var avg = studentList.Average(s => s.Tuition);
        foreach (var s in result)
        {
            foreach (StudentGPA z in s)
            { 
                Console.WriteLine($"{z.StudentID}");
            }
        }
        Console.WriteLine("-----------------------");
        foreach (var s in result2)
        {
            foreach (StudentClubs z in s)
            {
                Console.WriteLine($"{z.StudentID}");
            }
        }
        Console.WriteLine("-----------------------");
        Console.WriteLine($"Number of students with gpa between 2.5 and 4.0; {count}");
        Console.WriteLine("-----------------------");
        Console.WriteLine($"Average tuition; ${avg}");
        Console.WriteLine("-----------------------");
        foreach (var s in result3)
        {
            if (s.Tuition == 5500)
            {
                Console.WriteLine($"{s.StudentName}");
                Console.WriteLine($"{s.Major}");
                Console.WriteLine($"{s.Tuition}");
            }
        }
        Console.WriteLine("-----------------------");
        var innerJoin = studentList.Join(studentGPAList,
                                student => student.StudentID,
                                gpa => gpa.GPA,
                                (student, gpa) => new
                                {
                                    StudentName = student.StudentName,
                                    Major = student.Major,
                                    GPA = gpa.GPA,
                                });


        foreach (var s in innerJoin)
        {
            Console.WriteLine($"Name: {s.StudentName}   Major: {s.Major}    GPA: {s.GPA}");
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------");
        var innerJoin2 = studentList.Join(studentClubList,
                                student => student.StudentID,
                                club => club.StudentID,
                                (student, club) => new
                                {
                                    StudentName = student.StudentName,
                                    Age = student.Age,
                                    ClubName = club.ClubName
                                });


        Console.WriteLine("Students who belong to the game club");
        Console.WriteLine();
        foreach (var s in innerJoin2)
        {
            if (s.ClubName == "Game")
            {
                Console.WriteLine($"Name: {s.StudentName}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}