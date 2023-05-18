using System;

class Program
{
    static void Main(string[] args)
    {

        var job1 = new Job("Manager", "2013", "2022");
        
        job1.Display();

    }
}

public class Job
{
    // properties
    public string title;

    public string startYear;

    public string endYear; 


    // Responsibilities
    public Job(string tl, string sy, string ey) {
       title = tl; 
       endYear = ey;
       startYear = sy; 
    }

    public void Display() {
        Console.WriteLine($"{title}, {startYear} - {endYear}");

    }
}

public class resume 
{

public void DisplayResume(string title){
    Console.WriteLine($"Name: ");
    Console.WriteLine($"Job: {title}");
}

}