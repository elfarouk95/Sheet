using System;
using System.Collections.Generic;


partial class Program
{
    static void sortByName(List<student> ls) // using buble sort ascending order
    {
        for (int i = 0; i < ls.Count; i++)
        {
            for (int j = 0; j < ls.Count - 1; j++)
            {
                if (string.CompareOrdinal(ls[i].Name, ls[j].Name) < 0)

                #region summery
                //
                // Summary:
                //     Compares two specified System.String objects by evaluating the numeric values
                //     of the corresponding System.Char objects in each string.
                //
                // Parameters:
                //   strA:
                //     The first string to compare.
                //
                //   strB:
                //     The second string to compare.
                //
                // Returns:
                //     An integer that indicates the lexical relationship between the two comparands.
                //     Value Condition Less than zero strA is less than strB. Zero strA and strB are
                //     equal. Greater than zero strA is greater than strB.
                #endregion

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

        sortByName(students);

        students.Print();
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
