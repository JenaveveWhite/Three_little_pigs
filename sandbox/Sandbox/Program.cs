using System;

class Program 
{
    static void Main(string[] args)
    {
        var personOne = new Person("Luke Skywalker");

        var BYUIPersonOne = new BYUIPerson("dhgsjgf", "ajhsgd");

        var studentOne = new Student("name", "inumber", "major");

    }
}

class Person{
    protected string _name;

    public Person(string name){
        _name = name;
    }
}

class BYUIPerson: Person {
    public BYUIPerson(string name, string iNumber) : base(name) {
        _iNumber = iNumber;
    }
    protected string _iNumber;
}

class Student: BYUIPerson {
    public Student(string name, string iNumber, string major): base(name, iNumber){
        _major = major;
    }
    private string _iNumber;

    private string _major;

}

class Teacher: BYUIPerson {

    public Teacher(string name, string iNumber, string department): base(name, iNumber) {
        _department = department;
    }
    private string _iNumber;

    private string _department;
}
