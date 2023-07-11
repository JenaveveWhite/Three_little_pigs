using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");
    }
}

class Video{
    protected string _title;
    protected string _author;
    protected int _length;

    public int NumberComments(){

        return ;
    }

}

class Comment {
    protected string _name;
    private string _commentText;

    Console.WriteLine("What is the name of the commentor?");
    _name = Console.ReadLine();

    Console.WriteLine("Please type your comment: ");
    _commentText = Console.ReadLine();
    
}