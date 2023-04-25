using System;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int grade_percent = int.Parse(grade);


        if (grade_percent >= 90) 
        {
            Console.WriteLine("Your grade is an A");
        }
        if (grade_percent >= 80 && grade_percent <= 89)
        {
            Console.WriteLine("Your grade is a B");
        }
        if (grade_percent >= 70 && grade_percent <= 79) 
        {
            Console.WriteLine("Your grade is a C");
        }
        if (grade_percent >= 60 && grade_percent <= 69) 
        {
            Console.WriteLine("Your grade is a D");
        }
        if (grade_percent <= 59) 
        {
            Console.WriteLine("Your grade is an F");
        }
    }
}