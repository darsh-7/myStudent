namespace mystudent
{
    class program
    {
        public class subjects
        {
            string[] subName = new string[2];
            float[] gba = new float[2];
            public string[] SubName
            {
                set { subName = value; }
                get { return subName; }
            }

            public float[] Gba
            {
                set { gba = value; }
                get { return gba; }
            }

        }
        public class Student : subjects
        {
            public Student()
            {
                name = "none";
                age = 0;

            }
            string name;
            int age;
            int id;

            public int Id { get { return id; } set { id = value; } }
            public string Name
            {
                set { name = value; }
                get { return name; }
            }

            public int Age
            {
                set { age = value; }
                get { return age; }
            }

        }
        static char ask_for_char()
        {
            char ask_char;
            do
            {
                try
                {
                    ask_char = char.Parse(Console.ReadLine());
                    return ask_char;
                }
                catch
                {
                    Console.WriteLine("Error, please enter correct symbol");
                }
            } while (true);
        }
        static int ask_for_Int()
        {
            int ask_number;
            do
            {
                try
                {
                    ask_number = int.Parse(Console.ReadLine());
                    return ask_number;
                }
                catch
                {
                    Console.WriteLine("Error, Please enter a real number");
                }
            } while (true);
        }
        static float ask_for_float()
        {
            float ask_number;
            do
            {
                try
                {
                    ask_number = float.Parse(Console.ReadLine());
                    return ask_number;
                }
                catch
                {
                    Console.WriteLine("Error, Please enter a real number");
                }
            } while (true);
        }
        public static string enterString()
        {
            string value;
            do
            {
                try
                {
                    value = Console.ReadLine();
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Error, Please enter the student name");
                        continue;
                    }
                    else
                        return value;
                }
                catch (Exception)
                {
                    throw new("Invalid input value ");
                }
            } while (true);
        }
        public static float avgGpa(Student student)
        {
            float sum = 0;
            for (int i = 1; i <= student.SubName.Length; i++)
            {
                sum += student.Gba[i];
            }

            return (sum / student.SubName.Length);
        }

        public int get_age(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age /= 365;
            return age;
        }
        public static int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }
        public static DateTime enterDate()
        {
            int d, m, y;
            Console.Write("Day : ");
            d = ask_for_Int();
            Console.Write("month : ");
            m = ask_for_Int();
            Console.Write("year : ");
            y = ask_for_Int();
            DateTime date = new DateTime(y, m, d);
            return date;

        }
        public static void printStudents(ref Student[] students)
        {
            Console.Clear();
            for (int i = 0; i <= 1; i++)
            {
                Console.Write(students[i].Name);
                Console.Write(students[i].Id);
                Console.Write(students[i].Age);
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(students[i].SubName[j]);
                    Console.Write(students[i].Gba[j]);
                }
                Console.WriteLine("");
            }


        }

        static void addStudents(ref Student[] students)
        {
            Student student = new Student();

            for (int i = 0; i < 1; i++)
            {
                students = new Student[students.Length];
                Console.Clear();
                Console.Write($"Student number ({i + 1})");
                Console.Write("Enter student Full name : ");
                student.Name = enterString();
                Console.Write("Enter your  birth day (day/month/year): ");
                student.Age = GetAge(enterDate());
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("Enter course  name : ");
                    student.SubName[j] = enterString();
                    Console.Write("Enter student gba of this course : ");
                    student.Gba[j] = ask_for_float();
                }
                student.Id = (i + 1);
                students[i] = student;
            }

        }
        static void menu()
        {
            Console.WriteLine("______________________________________________");
            Console.Write("|(a) add student");
            Console.Write(" (s) s by id");
            Console.Write(" (p) show data");
            Console.WriteLine(" (q) to close|");
            Console.WriteLine("______________________________________________");
        }


        public static void Main()
        {
            char command;
            Console.WriteLine("*** Choose the operation you want to perform by the symbol ***");
            Console.WriteLine("_______________________________________________________________________");
            Console.WriteLine("Available operations :");
            Console.WriteLine();
            do
            {
                menu();
                command = ask_for_char();
                Student[] students = new Student[9];
                switch (command)
                {
                    case 'a':
                        addStudents(ref students);
                        break;
                    case 's':
                        //s;
                        break;
                    case 'p':
                        printStudents(ref students);
                        break;
                    default:
                        Console.WriteLine("Error, please enter correct symbol");
                        //Console.Write(students[1].Name);
                        //Console.ReadLine();
                        Thread.Sleep(2000);
                        continue;
                }
            } while (command != 'q');
            Console.WriteLine("good by ;)");



        }
    }
}