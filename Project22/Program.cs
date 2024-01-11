using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project22
{
    class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
    }

    class Program
    {
        static List<Teacher> teachers = new List<Teacher>();
        static string filePath = "D:\\Mphasis\\project22\\TeacherData.txt";

        static void Main()
        {
            LoadData();

            while (true)
            {
                Console.WriteLine("1. Add Teacher\n2. Display Teachers\n3. Update Teacher\n4. Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;

                    case 2:
                        DisplayTeachers();
                        break;

                    case 3:
                        UpdateTeacher();
                        break;

                    case 4:
                        SaveData();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice please try again.");
                        break;
                }
            }
        }

        static void AddTeacher()
        {
            Console.WriteLine("Enter ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Class:");
            string classValue = Console.ReadLine();

            Console.WriteLine("Enter Section:");
            string section = Console.ReadLine();

            Teacher newTeacher = new Teacher { ID = id, Name = name, Class = classValue, Section = section };
            teachers.Add(newTeacher);

            Console.WriteLine("Teacher added successfully!");
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("\nTeacher List:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
            }
            Console.WriteLine();
        }

        static void UpdateTeacher()
        {
            Console.WriteLine("Enter the ID of the teacher to update:");
            int id = int.Parse(Console.ReadLine());

            Teacher teacherToUpdate = teachers.Find(t => t.ID == id);

            if (teacherToUpdate != null)
            {
                Console.WriteLine($"Updating details for Teacher {id}:");

                Console.WriteLine("Enter new Name:");
                string newName = Console.ReadLine();
                teacherToUpdate.Name = newName;

                Console.WriteLine("Enter new Class:");
                string newClass = Console.ReadLine();
                teacherToUpdate.Class = newClass;

                Console.WriteLine("Enter new Section:");
                string newSection = Console.ReadLine();
                teacherToUpdate.Section = newSection;

                Console.WriteLine("Teacher details updated successfully!");
            }
            else
            {
                Console.WriteLine($"Teacher with ID {id} not found.");
            }
        }

        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] values = line.Split(',');
                    Teacher teacher = new Teacher
                    {
                        ID = int.Parse(values[0]),
                        Name = values[1],
                        Class = values[2],
                        Section = values[3]
                    };
                    teachers.Add(teacher);
                }
            }
        }

        static void SaveData()
        {
            List<string> lines = new List<string>();

            foreach (var teacher in teachers)
            {
                lines.Add($"{teacher.ID},{teacher.Name},{teacher.Class},{teacher.Section}");
            }

            File.WriteAllLines(filePath, lines);
        }
    }

}