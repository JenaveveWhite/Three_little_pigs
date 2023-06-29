using System;

class Program
{
    
    static void Main(string[] args){
        List<string> programMenu = new List<string>();

            programMenu.Add("");
            programMenu.Add(" Menu Options:");
            programMenu.Add("     1. Create New Goal");
            programMenu.Add("     2. List Goals");
            programMenu.Add("     3. Save Goals");
            programMenu.Add("     4. Load Goals");
            programMenu.Add("     5. Record Event");
            programMenu.Add("     6. Quit");
            programMenu.Add(" ");


        List<string> goalMenu = new List<string>();
            goalMenu.Add("1. Simple");
            goalMenu.Add("2. Eternal");
            goalMenu.Add("3. Checklist");

        var goals = new List<Goal>();
        int points = 0;

      
        while(true){
            Console.WriteLine($"You have {points} points.");
            var choice = GetIntMenu(6, programMenu);

            if(choice == 1){
                Console.WriteLine("Select a choice from the menu");
                var choice1 = GetIntMenu(3,goalMenu);
                if(choice1 == 1){
                    var newgoal = new SimpleGoal();
                    goals.Add(newgoal);
                }
                if(choice1 == 2){
                    var newgoal = new EternalGoal();
                    goals.Add(newgoal);

                }
                if(choice1 == 3){
                    var newgoal = new CheckListGoal();
                    goals.Add(newgoal);

                }
                continue;
            } 

            if(choice ==2){
                Console.WriteLine($"{goals}");
                continue;
            }

            if(choice == 3){
                Save(goals);
                continue;

            }
        
            if(choice == 4){
                Console.WriteLine("Please enter filename");
                var filename = Console.ReadLine();
                Load(filename);
                continue;

            }

            if(choice == 5){
                RecordEvent(goals);
                continue;

            }

            if(choice == 6){
                Console.WriteLine("");
                Console.WriteLine("Goodbye!");
                Console.WriteLine("");
                break;
            }
        }   
    }

    static int GetIntMenu(int amount, List<string> menu){
        while (true) {

            foreach(var m in menu){
                Console.WriteLine(" ");
                Console.WriteLine(m);
                Console.WriteLine("");
            }
            Console.WriteLine($"Enter a number 1-{amount} (Press {amount + 1} to view menu again): ");
            var input = Console.ReadLine();

            try {
            var value = int.Parse(input);
                if (value < 1){
                    Console.WriteLine($"Please enter a number 1-{amount}");
                    continue;
                }
                if (value == (amount + 1)){
                    foreach(var m in menu){
                        Console.WriteLine(m);
                    }                    
                    continue;
                }
                if (value > (amount + 1)){
                    Console.WriteLine($"Please enter a number 1-{amount}");
                    continue;
                }
            return value;
            } catch(Exception) {
                Console.WriteLine($"Incorrect format, please enter a number 1-{amount}");
            }
        }
    }

// what needs to be saved in this file?

// - type of goal
// - dat for each goal
//      - simple#name#description#points#completed
//      - Eternal#name#description#points#completed
//      - Checklist#name#description#points#completedCount#requiredCount#bonus
// - user point total 
// 
    public static void Save(List<Goal> goals){
        string fileName = "myFile.txt";

        using (StreamWriter outputFile = new StreamWriter(fileName)){
        outputFile.WriteLine(" ");
    
        foreach(var goal in goals){
        outputFile.WriteLine($"{goal.GetData()}");
        }
        }
    }

    public static List<Goal> Load(string filename){

        var entries = new List<Goal>();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach(string line in lines){

            string [] parts = line.Split("#");
            string goalType = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            bool isC = bool.Parse(parts[4]);
        

            if(goalType == "Simple"){
                var goal = new SimpleGoal(isC, name, desc, points);

            }else if( goalType == "Eternal"){
                var goal = new EternalGoal(isC, name, desc, points);
            }else if(goalType == "Checklist"){
                var bonus = int.Parse(parts[6]);
                var timesDetermined = int.Parse(parts[4]);
                var timesComplete = int.Parse(parts[5]);
                var goal = new CheckListGoal();
            }
        }
        return entries;
    }
}

class Goal{
    protected string _name;
    protected string _description;
    protected int _points;

    protected bool _isComplete;


    public Goal(bool isComplete, string name, string description, int points){
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;

    }

    public Goal(){
        GatherData();
    }

    virtual public void GatherData(){

        Console.WriteLine("What is the name of your Goal?");
        _name = Console.ReadLine();
        Console.WriteLine("Please describe your goal.");
        _description = Console.ReadLine();
        Console.WriteLine("How many points is this goal worth?");
        _points = int.Parse(Console.ReadLine());

    }
    virtual public string GetData(){
        return $"#{_name}#{_points}#{_isComplete}";

    }

    virtual public void RecordEvent(){
        _isComplete = true;
        
    }


}

class EternalGoal: Goal {
    public EternalGoal(bool isComplete, string name, string description, int points): base(isComplete,name, description, points){

    }

    public override void GatherData(){

        base.GatherData();        
    }
    public EternalGoal(){
        base.GetData();
    }
    public override string GetData(){
        return $"Eternal#{_name}#{_points}#{_isComplete}";

    }
   
    public override void RecordEvent()
    {
        _isComplete = false;
    }
}
class SimpleGoal: Goal{
    public SimpleGoal(bool isComplete, string name, string description, int points): base(isComplete, name, description, points){

    }
    public SimpleGoal(){
        base.GatherData();

    }
    public override void GatherData(){
        base.GatherData();
    }
    public override string GetData(){

        return $"Simple#{_name}#{_points}#{_isComplete}";

    }

}

class CheckListGoal: Goal{
    protected int _bonus;
    protected int _timesDetermined;
    protected int _timesComplete;
    
    public CheckListGoal(int bonus, int timesDetermined, int timesComplete, bool isComplete, string name,string description, int points): base(isComplete, name, description, points){
        _bonus = bonus;
        _timesDetermined = timesDetermined;
        _timesComplete = timesComplete;
    }
    public CheckListGoal(){
        base.GatherData();
    }
    public override void GatherData(){
        base.GatherData();
        Console.WriteLine("How many times do you want to complete this goal?");
        _timesDetermined = int.Parse(Console.ReadLine());
        Console.WriteLine("How many points for completing this checklist goal?");
        _bonus = int.Parse(Console.ReadLine());
        
    }

    public override string GetData(){
        return $"Checklist#{_name}#{_points}#{_isComplete}#{_timesDetermined}#{_timesComplete}#{_bonus}";

    }
    public override void RecordEvent()
    {
        _timesComplete += 1;
        if( _timesDetermined == _timesComplete){
        _points = _points + _bonus;
        _isComplete = true;
        }
        
    }
}