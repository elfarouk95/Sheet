using System;
using System.Collections.Generic;


partial class Program
{
    static void generalSort(List<student> ls, ISort sort) // using interface 
    {
        for (int i = 0; i < ls.Count; i++)
        {
            for (int j = 0; j < ls.Count - 1; j++)
            {
                if (sort.Compare(ls[i], ls[j]) > 0)
                {
                    // swap
                    var temp = ls[i];
                    ls[i] = ls[j];
                    ls[j] = temp;

                }
            }
        }
    }
}
partial class Program
{
    static void Main(string[] args)
    {
        List<student> students = new List<student>();

        students.FakeData(); // or use students.Input(); 

        studentSortByAge s = new studentSortByAge();

        generalSort(students, s);

        List<student> Top3 = new List<student>();


        Top3.AddRange(students.GetRange(0, 3));

        Top3.Print();
    }
}

class student
{
    public string Name { get; set; }
    public int age { get; set; }
    public float gpa { get; set; }

    public override string ToString()
    {
        return $"Student Data Name : {Name} , age {age} and gpa : {gpa} ";
    }
}


interface ISort
{
    int Compare(student x, student y);
}


class studentSortByAge : ISort
{
    public int Compare(student x, student y)
    {
        if (x.age > y.age)
        {
            return 1;
        }
        else if (x.age < y.age)
        {
            return -1;
        }
        else return 0;
    }
}




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