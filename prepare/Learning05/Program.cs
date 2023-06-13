using System;

class Program
{
    static void Main(string[] args)
    {
        var circle = new Circle(5, "blue");
        var square = new Square(2, "red");
        var rectangle = new Rectangle(2,3,"yellow");

        Console.WriteLine(circle.GetArea());
        Console.WriteLine(square.GetArea());
        Console.WriteLine(rectangle.GetArea());

    }
}

class Shape {
    protected string _color;

    public Shape(string color){
        _color = color;
    }
    public void GetColor(){

    }

    public void SetColor(string color1){

    }

    public virtual double GetArea() {
        return 0;
    }
}

class Square: Shape{
    protected double _side;

    public Square(double side, string color): base(color){
        _side = side;
    }

    public override double GetArea(){
        return _side * _side;
    }
    
}

class Circle: Shape{
    protected double _radius;

    public Circle(double radius, string color): base(color){
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * (_radius * _radius);
        
    }
}

class Rectangle: Shape{
    protected double _height; 
    protected double _length; 

    public Rectangle(double height, double length, string color): base(color){
        _height = height;
        _length = length;

    }

    public override double GetArea()
    {
        return _height * _length;
    }
}
