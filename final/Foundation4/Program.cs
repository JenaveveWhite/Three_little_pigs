using System;

class Program
{
    static void Main(string[] args)
    {
        Running running = new Running(5, 200);
        Cycling cycling = new Cycling(15, 60);
        Swimming swimming = new Swimming(10, 60);

        List<Activity> list = new List<Activity>();
            list.Add(running);
            list.Add(cycling);
            list.Add(swimming);

        foreach(Activity lis in list ){
            Console.WriteLine($"{lis.GetSummary()}");
            
        }

    }
}

class Activity{
    protected double _duration;

    public Activity( double lengthInMinutes){
        _duration = lengthInMinutes; 

    }

    public virtual string GetSummary(){
        return $"{DateTime.Today} ({_duration} min) - ";
    }


    
}

class Running: Activity{
    protected double _distance;

    public Running(double distance, double duration): base( duration){
        _distance = distance;
    }

    public override string GetSummary()
    {
        double speed = (_distance / _duration) * 60.0 ;
        double pace = _duration / _distance; 
        return $"{DateTime.Today} Running ({_duration} min) -- Distance {_distance}, Speed {speed} mph, Pace {pace} min per mile)";
    }
}
class Cycling: Activity{
    protected double _distance;

    public Cycling(double distance, double duration): base( duration){
        _distance = distance;

    }

    public override string GetSummary()
    {
        double speed = (_distance / _duration) * 60.0 ;
        double pace = 60.0 / speed; 
        return $"{DateTime.Today} Cycling ({_duration} min) -- Distance {_distance} miles, Speed {speed} mph, Pace {pace} min per mile)";
    }


}

class Swimming: Activity{
    protected double _laps;

    public Swimming(double laps, double duration): base(duration){
        _laps = laps;
    }

    public override string GetSummary()
    {
        double _distance = ((_laps * 50.0) / 1000.0) * 0.62;
        double speed = (_distance / _duration) * 60.0;
        double pace = 60.0 / speed;
        return $"{DateTime.Today} Swimming ({_duration} min) -- Distance {_distance}, Speed {speed} mph, Pace {Math.Round(pace,2)} min per mile)";

    }
}