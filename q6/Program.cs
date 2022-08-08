using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<teacher> teachers = new List<teacher>();
        teachers.FakeData();


        Dictionary<float,teacher> teachersDict = new Dictionary<float,teacher>();

        foreach (var item in teachers)
        {
            teachersDict.TryAdd(item.salary, item);
        }

        foreach (var item in teachersDict)
        {
            Console.WriteLine(item);
        }

    }
}

class teacher : IComparable<teacher>
{
    public string Name { get; set; }
    public int age { get; set; }
    public float salary { get; set; }

    public int CompareTo( teacher other)
    {
        return salary.CompareTo(other.salary);
    }

    public override string ToString()
    {
        return $"Teacher Data Name : {Name} , age {age} and salary : {salary} ";
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
            new teacher{Name = "teacher1" , age = 22 , salary = 2700f},
            new teacher{Name = "teacher8" , age = 20 , salary = 3400f},
            new teacher{Name = "teacher2" , age = 19 , salary = 3000f},
            new teacher{Name = "teacher1" , age = 21 , salary = 3800f}
        };

        ls.AddRange(fake);


    }
}