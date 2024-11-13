using SøgemaskineCase.Custom_Types;

namespace SøgemaskineCase
{
    class Program
    {
        static List<Teacher> teachers = new List<Teacher>();
        static List<Student> students = new List<Student>();
        static List<Course> courses = new List<Course>();
        static void Main(string[] args)
        {
            InitData();
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Vælg søgekriterie: ");
                Console.WriteLine("1 - Lærer");
                Console.WriteLine("2 - Elev");
                Console.WriteLine("3 - Fag");
                Console.WriteLine("4 - Afslut");
                string option = Console.ReadLine();

                if (option == "4") break;

                switch (option) 
                {
                    case "1":
                        SearchTeacher();
                        break;
                    case "2":
                        SearchStudent();
                        break;
                    case "3":
                        SearchCourse();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg. Prøv igen");
                        break;
                }
                Console.WriteLine("\nTryk på en tast for at fortsætte");
                Console.ReadKey();

            }


        }

        static void InitData()
        {

        }

        static void SearchTeacher()
        {
            Console.WriteLine("List over lærere: ");
            var sortTeachers = teachers.OrderBy(t => t.Forname).ToList();
            sortTeachers.ForEach(t => Console.WriteLine($"ID: {t.GetHashCode()} - {t.GetName()}"));

            Console.WriteLine("Indtast lære indeks: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var teachers = sortTeachers.FirstOrDefault(t => t.GetHashCode() == id);
                if (teachers != null)
                {
                    Console.WriteLine($"Fag undervist af {teachers.GetName()}:");
                    teachers.TeacherCourse.ForEach(c =>
                    {
                        Console.WriteLine($"- {c.Name} ({c.Students.Count} elever)");
                        c.Students.ForEach(s =>
                        {
                            var age = AgeValidation.CalculateAge(s.Birthdate);
                            if (age < 20)
                                Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" - {s.GetName()} (Alder: {age})");
                            Console.ResetColor();
                        });
                    });
                }
                else
                {
                    Console.WriteLine("Ingen matches fundet");

                }
        
            }
            else
            {
                Console.WriteLine("Ugyldigt ID");
            }
        }
        static void SearchStudent()
        {
            Console.WriteLine("Indtast elevens fulde navn:");
            string name = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));

            if (student != null)
            {
                Console.WriteLine($"Elev: {student.GetName()}");
                student.StudentCourse.ForEach(c => Console.WriteLine($"- {c.Name} (Underviser: {c.Teacher.GetName()}"));
            }
            else
            {
                Console.WriteLine("Ingen matches fundet");
            }
        }
        static void SearchCourse()
        {
            Console.WriteLine("Liste over fag: ");
            var sortCouse = courses.OrderBy(c => c.Name).ToList();
            sortCouse.ForEach(c => Console.WriteLine($"ID: {c.GetHashCode()} - {c.Name}"));

            Console.WriteLine("Indtast fag ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var chosenCourse = sortCouse.FirstOrDefault(c => c.GetHashCode() == id);
                if (chosenCourse != null)
                {
                    Console.WriteLine($"Fag: {chosenCourse.Name}");
                    Console.WriteLine($"Lærer: {chosenCourse.Teacher.GetName()}");
                    Console.WriteLine($"Antal Elever: {chosenCourse.Students.Count}");

                    chosenCourse.Students.ForEach(s =>
                    {
                        var age = AgeValidation.CalculateAge(s.Birthdate);
                        if (age < 20)
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($" - {s.GetName()} (Alder: {age}");
                        Console.ResetColor();
                    });
                }
                else
                {
                    Console.WriteLine("Ingen match fundet");
                }
            }
            else 
            {
                Console.WriteLine("Ugyldigt ID");
            }

        }
    }
}
