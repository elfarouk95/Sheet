using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

class compareNames : IComparer<KeyValuePair<string, int>>
{
    public int Compare([AllowNull] KeyValuePair<string, int> x, [AllowNull] KeyValuePair<string, int> y)
    {
        if (x.Value > y.Value)
        {
            return -1;
        }
        else if (x.Value < y.Value)
            return 1;
        else
        {
            return 0;
        }
    }
}

interface ISort
{
    int Compare(student x, student y);
}
interface IFilter
{
    bool canJoin(student s);
}
partial class Program // helper funcation 
{

    static void sortByName(List<student> ls) // using buble sort ascending order
    {
        for (int i = 0; i < ls.Count; i++)
        {
            for (int j = 0; j < ls.Count - 1; j++)
            {
                if (string.CompareOrdinal(ls[i].Name, ls[j].Name) < 0)

                #region summery
                //    Summary:
                //     Compares substrings of two specified System.String objects, ignoring or honoring
                //     their case, and returns an integer that indicates their relative position in
                //     the sort order.
                //
                // Parameters:
                //   strA:
                //     The first string to use in the comparison.
                //
                //   indexA:
                //     The position of the substring within strA.
                //
                //   strB:
                //     The second string to use in the comparison.
                //
                //   indexB:
                //     The position of the substring within strB.
                //
                //   length:
                //     The maximum number of characters in the substrings to compare.
                //
                //   ignoreCase:
                //     true to ignore case during the comparison; otherwise, false.
                //
                // Returns:
                //     A 32-bit signed integer that indicates the lexical relationship between the two
                //     comparands. Value Condition Less than zero The substring in strA precedes the
                //     substring in strB in the sort order. Zero The substrings occur in the same position
                //     in the sort order, or length is zero. Greater than zero The substring in strA
                //     follows the substring in strB in the sort order.

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

    static List<student> filter(List<student> ls, IFilter filter)
    {
        List<student> result = new List<student>();
        foreach (student s in ls)
        {
            if (filter.canJoin(s))
            {
                result.Add(s);
            }

        }

        return result;
    }
}
partial class Program
{

    static void q1()
    {
        List<student> students = new List<student>();

        students.FakeData(); // or use students.Input(); 

        sortByName(students);

        students.Print();

    }


    

    static void q2()
    {
        List<student> students = new List<student>();

        students.FakeData(); // or use students.Input(); 

        studentSortByAge s = new studentSortByAge();

        generalSort(students, s);

        List<student> Top3 = new List<student>();


        Top3.AddRange(students.GetRange(0, 3));

        Top3.Print();


    }
    static void q3()
    {
        List<student> students = new List<student>();

        students.FakeData(); // or use students.Input(); 


        var res = filter(students, new filterStudent());

        res.Print();

    }

    static void q5()
    {
        List<student> ls = new List<student>();
        ls.FakeData();
        Dictionary<string, int> pairs = new Dictionary<string, int>();

        foreach (var item in ls)
        {
            string name = item.Name;

            if (pairs.ContainsKey(name))
            {
                pairs[name]++;
            }
            else
            {
                pairs.Add(name, 1);
            }
        }


        var tempList = pairs.ToList();


        // you can use any type of sort or using built in sort function
        // 
        tempList.Sort(new compareNames());


        foreach (var item in tempList.GetRange(0,3))
        {
            Console.WriteLine(item);
        }


    }



    static void Main(string[] args)
    {

    }

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

class filterStudent : IFilter
{
    public bool canJoin(student s)
    {
        if (s.age == 20 && s.gpa > 3.0f)
        {
            return true;
        }
        else
            return false;
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

class teacher
{
    public string Name { get; set; }
    public int age { get; set; }
    public float salary { get; set; }

    public override string ToString()
    {
        return $"Teacher Data Name : {Name} , age {age} and salary : {salary} ";
    }
}