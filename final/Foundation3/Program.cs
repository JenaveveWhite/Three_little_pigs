using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"");
        Console.WriteLine($"Which Type of event are you planning?");
        Console.WriteLine($"");
        Console.WriteLine($"    1. Lecture");
        Console.WriteLine($"    2. Reception");
        Console.WriteLine($"    3. Outdoor Gathering");
        Console.WriteLine($"");
        int type = int.Parse(Console.ReadLine());

        Console.WriteLine($"What is the title of your event?");
        var eventTitle = Console.ReadLine();
        Console.WriteLine($"What is the description of your event?");
        var description = Console.ReadLine();
        Console.WriteLine($"What is the date of your event?");
        var date = Console.ReadLine();
        Console.WriteLine($"What is the time of your event?");
        var time = Console.ReadLine();
        Console.WriteLine($"What is the street address of your event?");
        var streetAddress = Console.ReadLine();
        Console.WriteLine($"What city is your event in?");
        var city = Console.ReadLine();
        Console.WriteLine($"What state is your event in?");
        var state = Console.ReadLine();
        Console.WriteLine($"What county is your event in?");
        var county = Console.ReadLine();        
        var address1 = new Address(streetAddress, city, state, county);
        var address = address1.GetAddress();


        if(type == 1){
            Console.WriteLine($"Who is the speaker of your event?");
            var speaker = Console.ReadLine();
            Console.WriteLine($"What is the capacity of your event?");
            var capacity = Console.ReadLine();
            var lecture = new Lecture(speaker, capacity, eventTitle, description, date, time, address);

            Console.WriteLine("");
            Console.WriteLine("Which type of description do you want for this event?");
            Console.WriteLine("");
            Console.WriteLine("     1. Standard");
            Console.WriteLine("     2. Full");
            Console.WriteLine("     3. Short");
            Console.WriteLine("");
            var int1 = int.Parse(Console.ReadLine());

            if(int1 == 1){
                var lectureinfo = lecture.Standard();
                foreach(string lec in lectureinfo){
                    Console.WriteLine(lec);
                }
            }
            if(int1 == 2){
                var lectureinfo = lecture.Full();
                foreach(string lec in lectureinfo){
                    Console.WriteLine(lec);
                }
            }
            if(int1 == 3){
                var lectureinfo = lecture.Short();
                foreach(string lec in lectureinfo){
                    Console.WriteLine(lec);
                }
            }
        }

        if(type ==2){
            Console.WriteLine($"Did they RSVP for your event?");
            var speaker = Console.ReadLine();
            var reception = new Reception(speaker , eventTitle, description, date, time, address);

            Console.WriteLine("");
            Console.WriteLine("Which type of description do you want for this event?");
            Console.WriteLine("");
            Console.WriteLine("     1. Standard");
            Console.WriteLine("     2. Full");
            Console.WriteLine("     3. Short");
            Console.WriteLine("");
            var int1 = int.Parse(Console.ReadLine());

            if(int1 == 1){
                var receptioninfo = reception.Standard();
                foreach(string lec in receptioninfo){
                    Console.WriteLine(lec);
                }
            }
            if(int1 == 2){
                var receptioninfo = reception.Full();
                foreach(string lec in receptioninfo){
                    Console.WriteLine(lec);
                }
            }
            if(int1 == 3){
                var receptioninfo = reception.Short();
                foreach(string lec in receptioninfo){
                    Console.WriteLine(lec);
                }
            }
        }

        if(type ==3){
            Console.WriteLine($"What is the weather Forecast for your event?");
            var weatherForCast = Console.ReadLine();
            var outdoor = new Outdoor(weatherForCast, eventTitle, description, date, time, address);
            Console.WriteLine("");
            Console.WriteLine("Which type of description do you want for this event?");
            Console.WriteLine("");
            Console.WriteLine("     1. Standard");
            Console.WriteLine("     2. Full");
            Console.WriteLine("     3. Short");
            Console.WriteLine("");
            var int1 = int.Parse(Console.ReadLine());
            
            if(int1 == 1){
                var outdoorinfo = outdoor.Standard();
                foreach(string lec in outdoorinfo){
                    Console.WriteLine(lec);
                }
            }
            if(int1 == 2){
                var outdoorinfo = outdoor.Full();
                foreach(string lec in outdoorinfo){
                    Console.WriteLine(lec);
                }
            }
            if(int1 == 3){
                var outdoorinfo = outdoor.Short();
                foreach(string lec in outdoorinfo){
                    Console.WriteLine(lec);
                }
            }

        }

        
    }

}

class Event{
    protected string _eventTitle;
    protected string _description;
    protected string _date;
    protected string _time;
    protected string _address;

    public Event(string eventTitle, string description, string date, string time, string address){
        _eventTitle = eventTitle;
        _description = description;
        _date = date;
        _time = time;
        _address = address;

    }
    public virtual List<string> Standard(){
        var StandardDetails = new List<string>();

            StandardDetails.Add(_eventTitle);
            StandardDetails.Add(_description);
            StandardDetails.Add(_date);
            StandardDetails.Add(_time);
            StandardDetails.Add(_address);
            
        return StandardDetails;
    }
    public virtual List<string> Full(){
        var FullDetails = new List<string>();

            FullDetails.Add(_eventTitle);
            FullDetails.Add(_description);
            FullDetails.Add(_date);
            FullDetails.Add(_time);
            FullDetails.Add(_address);
            
        return FullDetails;        
    }

}
class Address{
    protected string _streetAddress;
    protected string _city;
    protected string _state;
    protected string _country; 

    public Address(string streetAddress, string city, string state, string country){
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;

    }

    public string GetAddress(){
        string address = $"{_streetAddress}, {_city}, {_state}, {_country}";

        return address;
    }
}

class Outdoor: Event{
    protected string _weatherForcast;

    public Outdoor(string weatherForcast, string eventTitle, string description, string date, string time, string address): base(eventTitle, description,date, time, address){
        _weatherForcast = weatherForcast;
    }

    public override List<string> Full(){
        var FullDetails = new List<string>();

            FullDetails.Add(_eventTitle);
            FullDetails.Add(_description);
            FullDetails.Add(_date);
            FullDetails.Add(_time);
            FullDetails.Add(_address);
            FullDetails.Add(_weatherForcast);
            
        return FullDetails;         

    }

    public virtual List<string> Short(){
        var ShortDetails = new List<string>();
            ShortDetails.Add("Outdoor");
            ShortDetails.Add(_eventTitle);
            ShortDetails.Add(_date);

        return ShortDetails;        
    }
}

class Reception: Event{
    protected string _rsvp;

    public Reception(string rsvp, string eventTitle, string description, string date, string time, string address): base(eventTitle, description,date, time, address){
        _rsvp = rsvp;
    }
    public override List<string> Full(){
        var FullDetails = new List<string>();

            FullDetails.Add(_eventTitle);
            FullDetails.Add(_description);
            FullDetails.Add(_date);
            FullDetails.Add(_time);
            FullDetails.Add(_address);
            FullDetails.Add(_rsvp);
            
        return FullDetails; 
    }        
    public virtual List<string> Short(){
        var ShortDetails = new List<string>();
            ShortDetails.Add("Reception");
            ShortDetails.Add(_eventTitle);
            ShortDetails.Add(_date);

        return ShortDetails;        
    }

}

class Lecture: Event{
    protected string _speaker;
    protected string _capacity;

    public Lecture(string speaker,string capacity, string eventTitle, string description, string date, string time, string address): base(eventTitle, description,date, time, address){
        _speaker = speaker;
        _capacity = capacity;
    
    }
    public override List<string> Full(){
        var FullDetails = new List<string>();

            FullDetails.Add(_eventTitle);
            FullDetails.Add(_description);
            FullDetails.Add(_date);
            FullDetails.Add(_time);
            FullDetails.Add(_address);
            FullDetails.Add(_speaker);
            FullDetails.Add(_capacity);
            
        return FullDetails;         

    }
    public List<string> Short(){
        var ShortDetails = new List<string>();
            ShortDetails.Add("Lecture");
            ShortDetails.Add(_eventTitle);
            ShortDetails.Add(_date);

        return ShortDetails;        
    }
}