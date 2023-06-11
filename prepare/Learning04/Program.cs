using System;

class Program
{
    static void Main(string[] args)
    {
        var writtingThing = new WritingAssignment("Mary Walters", "European History", "The Cause of WWII");
        
        writtingThing.GetWritingInformation();

        var mathAssignment = new MathAssignment("Robert", "fractions", "Section 7.3", "8-19");

        mathAssignment.GetHomeworkList();
    }
}

class Assignment{
    protected string _studentName;

    protected string _topic;

    public Assignment(string studentName, string topic){
        _studentName = studentName;

        _topic = topic;
    }

    public void GetSummary() {
        Console.WriteLine($"Name: {_studentName} Topic: {_topic}  ");
    }
}

class MathAssignment: Assignment{
    private string _textbookSection;

    private string _problems;
    public MathAssignment(string studentName, string topic, string textbookSection, string problems): base(studentName, topic) {
        _textbookSection = textbookSection;

        _problems = problems;

    }

    public void GetHomeworkList() {

        Console.WriteLine($"{GetSummary}, List: {_textbookSection}, Problems: {_problems}");
    }
}

class WritingAssignment: Assignment {
    private string _title; 

    public WritingAssignment(string studentName, string topic, string title): base(studentName, topic) {
        _title = title; 

    }

     public void GetWritingInformation() {
        Console.WriteLine($"{GetSummary}, List: {_title}");
    }
}

