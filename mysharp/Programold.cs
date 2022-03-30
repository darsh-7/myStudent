using Newtonsoft.Json;
using System;

namespace StudentTable
{
    class Program
    {

        static void Main(string[] args)
        {
            Student[] students = new Student[100];
            Student.StudentAvg += NewStudent;
            int poss = 0;
            while (true)
            {
                Menu();
                char op = (char)Console.ReadKey().Key;  //store user key input
                // check user input
                if (op == (char)ConsoleKey.N)
                {
                    NewStudent(ref students, poss);
                }
                else if (op == (char)ConsoleKey.S)
                {
                    ShowStudent(students, poss);
                    Console.WriteLine("\nEnter ant key to continue");
                    Console.ReadKey();
                }
                else if (op == (char)ConsoleKey.C)
                {
                    Console.WriteLine($"Number of students = {poss}\n");
                    Console.WriteLine("\nEnter ant key to continue");
                    Console.ReadKey();
                }
                else if (op == (char)ConsoleKey.V)
                {
                    AvgGPA(ref students, poss);
                    Console.WriteLine("\nEnter ant key to continue");
                    Console.ReadKey();
                }
                else if (op == (char)ConsoleKey.E)
                {
                    ShowStudent(students, poss);
                    Console.WriteLine("\n---------->>>>>>>Enter students id to edit<<<<<---------");
                    NewStudent(ref students, int.Parse(Console.ReadLine()) - 1);
                }
                else if (op == (char)ConsoleKey.F)
                {
                    asd(students);
                }

                else if (op == (char)ConsoleKey.Q)
                    break;
                else
                {
                    Console.WriteLine($"--->>Please enter a valid key<<---");
                    Thread.Sleep(5000);
                }
            }


        }
        //add new student
        static void NewStudent(ref Student[] students, int poss)
        {
            Console.Clear();
            Student temp = new Student();
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"New student default id : {poss + 1}\n");
                    Console.WriteLine("student name");
                    temp.Name = Console.ReadLine();
                    Console.WriteLine("Enter student age");
                    temp.Age = byte.Parse(Console.ReadLine());
                    /*
                    Console.WriteLine("student id (beta optional)");
                    string val = Console.ReadLine();
                    if ((val == ""))
                        temp.id = poss;
                    else
                        temp.id = byte.Parse(val);
                    */
                    temp.ID = poss;
                    Console.WriteLine("enter 6 coursesfor this student");
                    for (int i = 0; i <= 5; i++)
                    {
                        Console.WriteLine($"course number {i + 1}");
                        temp.Courses[i] = Console.ReadLine();
                    }
                    Console.WriteLine("student level");
                    temp.Level = byte.Parse(Console.ReadLine());
                    Console.WriteLine("student gpa");
                    temp.Gpa = float.Parse(Console.ReadLine());

                    students[poss++] = temp;
                    break;
                }
                catch
                {
                    //Console.WriteLine("Data entry error\nPlease re-enter the student data correctly\n");
                    new Exception("Data entry error\nPlease re-enter the student data correctly");
                    Thread.Sleep(4000);
                }
            } while (true);
        }

        // show the table of students
        static void ShowStudent(Student[] students, int poss)
        {
            Console.Clear();
            Console.WriteLine("id\tName\tage\tcourses\t\t\t\t\tlevel\tgpa");
            for (int i = 0; i < poss; i++)
            {
                Console.Write((students[i].ID+1)+"\t");
                Console.Write(students[i].Name + "\t");
                Console.Write(students[i].Age + "\t");
                foreach (var item in students[i].Courses)
                    Console.Write(item + "\t");
                Console.Write(students[i].Level + "\t");
                Console.WriteLine(students[i].Gpa + "\n");

            }
        }

        static void AvgGPA(ref Student[] students, int poss)
        {
            Console.Clear();
            Console.WriteLine($"Number of students = {poss}\n");
            double sum = 0;
            for (int i = 0; i < poss - 1; i++)
            {
                sum += students[i].Gpa;
            }

            Console.WriteLine($"average ={sum / (poss)}");
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("-------->>StudentTable<<--------");
            Console.WriteLine("Press N for new student");
            Console.WriteLine("Press S to see all the student data");
            Console.WriteLine("Press E to edit student data");
            Console.WriteLine("Press C to count the students");
            Console.WriteLine("Press V to get the avrage gpa");
            Console.WriteLine("Press Q to qiut");
            Console.WriteLine("--------------------------------");

        }

        static void asd(Student[] student)
        {

            foreach (var item in student)
            {
                var userInfo = new Student();
                // write the data (overwrites)
                using (var stream = new StreamWriter("students.json", append: false))
                {
                    stream.Write(JsonConvert.SerializeObject(userInfo));
                }

            }


        class Student
        {
            //student data info
            int id;
            string name="";
            byte age;
            string[] courses = new string[10];
            byte level;
            float gpa;


            // delegate
            public delegate void StudentDelegate(Student student);
            // event avg
            public event StudentDelegate StudentAvg;


            protected virtual void onStudentAvg()
            {
                if (StudentAvg != null)
                {
                    StudentAvg(this);
                }

            }

            public string[] Courses
            {
                get
                {
                    return courses;
                }
                set
                {
                    courses = value;
                }

            }

            public int ID
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }

            }

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public float Gpa
            {
                get
                {
                    return gpa;
                }
                set
                {
                    if (value > 0 && value <=4)
                    {
                        gpa = value;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                        gpa = 0;
                    }
                }

            }
            public byte Age
            {
                get
                {
                    return age;
                }
                set
                {
                    if (value > 0 && value < 120)
                    {
                        age = value;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                        age = 0;
                    }
                }

            }


            public byte Level
            {
                get
                {
                    return level;
                }
                set
                {
                    if (value > 0 && value < 8)
                    {
                        level = value;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                        level = 0;
                    }
                }
            }


        }
    }
}