using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

static class StudentEx
{
    public static void Input(this List<student> ls)
    {

        Console.WriteLine("Enter 10 student");
        for (int i = 0; i < 10; i++)
        {
            try
            {
                ls[i] = new student();

                Console.WriteLine($"Enter Name student Number : {i + 1} ");
                ls[i].Name = Console.ReadLine();

                Console.WriteLine($"Enter Age student Number : {i + 1} ");
                ls[i].age = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter GPA student Number : {i + 1} ");
                ls[i].gpa = float.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong Data please try it again");
                i--; // to return to the same student number data
            }
        }

    }
    public static void Print(this List<student> ls)
    {
        foreach (var item in ls)
        {
            Console.WriteLine(item);
        }
    }

    public static void FakeData(this List<student> ls)
    {

        List<student> fake = new List<student>()
        {
            new student{Name = "student3" , age = 20 , gpa = 3.1f},
            new student{Name = "Student2" , age = 19, gpa = 3.3f},
            new student{Name = "student3" , age = 18 , gpa = 3.6f},
            new student{Name = "student2" , age = 17 , gpa = 3.7f},
            new student{Name = "Student1" , age = 14 , gpa = 2.4f},
            new student{Name = "student1" , age = 15 , gpa = 2.3f},
            new student{Name = "student1" , age = 22 , gpa = 2.4f},
            new student{Name = "student8" , age = 20 , gpa = 3.4f},
            new student{Name = "Student2" , age = 19 , gpa = 3.3f},
            new student{Name = "student1" , age = 21 , gpa = 3.1f}
        };

        ls.AddRange(fake);


    }
}

static class TeacherEx
{
    public static void Input(this List<teacher> ls)
    {

        Console.WriteLine("Enter 10 teacher");
        for (int i = 0; i < 10; i++)
        {
            try
            {
                ls[i] = new teacher();

                Console.WriteLine($"Enter Name teacher Number : {i + 1} ");
                ls[i].Name = Console.ReadLine();

                Console.WriteLine($"Enter Age teacher Number : {i + 1} ");
                ls[i].age = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter Salary teacher Number : {i + 1} ");
                ls[i].salary = float.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong Data please try it again");
                i--; // to return to the same student number data
            }
        }

    }
    public static void Print(this List<teacher> ls)
    {
        foreach (var item in ls)
        {
            Console.WriteLine(item);
        }
    }

    public static void FakeData(this List<teacher> ls)
    {

        List<teacher> fake = new List<teacher>()
        {
            new teacher{Name = "teacher3" , age = 20 , salary = 3000f},
            new teacher{Name = "teacher2" , age = 19, salary = 3100f},
            new teacher{Name = "teacher3" , age = 18 , salary = 3400f},
            new teacher{Name = "teacher2" , age = 17 , salary = 3500f},
            new teacher{Name = "teacher1" , age = 14 , salary = 3800f},
            new teacher{Name = "teacher1" , age = 15 , salary = 2700f},
            new teacher{Name = "teacher1" , age = 22 , salary = 2200f},
            new teacher{Name = "teacher8" , age = 20 , salary = 1800f},
            new teacher{Name = "teacher2" , age = 19 , salary = 4000f},
            new teacher{Name = "teacher1" , age = 21 , salary = 3800f}
        };

        ls.AddRange(fake);


    }
}


class Program
{
    static void Main(string[] args)
    {
        List<person> people = new List<person>();

        List<student> students = new List<student>();
        students.FakeData();

        List<teacher> teachers = new List<teacher>();
        teachers.FakeData();

        people.AddRange(students);
        people.AddRange(teachers);

        people.Sort();

        foreach (var item in people)
        {
            Console.WriteLine(item);
        }

    }
}


class person : IComparable<person>
{
    public string Name { get; set; }
    public int age { get; set; }

    public int CompareTo( person other)
    {
        return string.CompareOrdinal(Name, other.Name);
    }
}
class student : person
{

    public float gpa { get; set; }

    public override string ToString()
    {
        return $"Student Data Name : {Name} , age {age} and gpa : {gpa} ";
    }
}

class teacher : person
{

    public float salary { get; set; }

    public override string ToString()
    {
        return $"Teacher Data Name : {Name} , age {age} and salary : {salary} ";
    }
}
