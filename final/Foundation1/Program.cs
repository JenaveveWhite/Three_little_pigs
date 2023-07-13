using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to make spaghetti", "Joe B.", 10 );
        Video video2 = new Video("How to change a tire", "Susan s.", 15 );
        Video video3 = new Video("How to fold a shirt", "Sally Z.", 2 );
        Video video4 = new Video("How to fix AC", "Carl. ",  25);

        Comment comment1 = new Comment("Jerry", "WOAH");
        Comment comment2 = new Comment("Jerry", "This is so helpful!");
        Comment comment3 = new Comment("Sarah", "I already knew this");
        Comment comment4 = new Comment("Tom", "Nice video!");
        Comment comment5 = new Comment("Walter", "cool stuff");
        Comment comment6 = new Comment("Rebecca ", "I loved this video :) ");
        Comment comment7 = new Comment("Garret", "Inspirational. ");

        video1.AddComment(comment1);
        video1.AddComment(comment3);
        video2.AddComment(comment3);
        video3.AddComment(comment3);
        video4.AddComment(comment3);
        video2.AddComment(comment6);
        video2.AddComment(comment4);
        video3.AddComment(comment6);
        video3.AddComment(comment1);
        video4.AddComment(comment7);
        video4.AddComment(comment2);
        video4.AddComment(comment5);

        List<Video> videos = new List<Video>{video1, video2, video3, video4};

        foreach(Video video in videos){
            System.Console.WriteLine($"Title: {video._title}");
            System.Console.WriteLine($"Author: {video._author}");
            System.Console.WriteLine($"Duration in minutes: {video._length}");
            System.Console.WriteLine($"Number of Comments: {video.GetComments().Count()}");
            
            Console.WriteLine("Comments: ");
            foreach(Comment comment in video.GetComments()){
                System.Console.WriteLine($"- {comment._name}: {comment._text}");
            }
            
        }
    }
}

class Video{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length){
        _title = title;
        _author = author;
        _length = length;

    }

    public void AddComment(Comment comment){
        _comments.Add(comment);
    }

    public int NumberComments(){

        return _comments.Count();
    }

    public List<Comment> GetComments(){
        return _comments;
    }

}

class Comment {
    public string _name;
    public string _text;

    public Comment(string name, string text){
        _name = name;
        _text = text;
    }
    
}