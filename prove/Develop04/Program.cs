using System;

class Program {
    static void Main(string[] args)
    {
        string reflectDescription = new ("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        string reflectStartMessage = new("Welcome to the reflection activity!");
        string reflectEndMessage = new("Thank you for completing the reflection activity!");
        
        string breatheDescription = new("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        string breatheStartMessage = new("Welcome to the breathing activity!");
        string breatheEndMessage = new("Thank you for completing the breathing activity!");
        
        string listenDescription = new("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        string listenStartMessage = new("Welcome to the listening activity!");
        string listenEndMessage = new("Thank you for completing the listening activity!");


        List<string> initialPrompt = new List<string>();
            
            initialPrompt.Add("Think of a time when you stood up for someone else. ");
            initialPrompt.Add("Think of a time when you did something really difficult.");
            initialPrompt.Add("Think of a time when you helped someone in need.");
            initialPrompt.Add("Think of a time when you did something truly selfless.");
        
        List<string> followUpQuestions = new List<string>();

            followUpQuestions.Add("Why was this experience meaningful to you?");
            followUpQuestions.Add("Have you ever done anything like this before?");
            followUpQuestions.Add("How did you get started?");
            followUpQuestions.Add("How did you feel when it was complete?");
            followUpQuestions.Add("What made this time different than other times when you were not as successful?");
            followUpQuestions.Add("What is your favorite thing about this experience?");

        var reflectingActivity = new ReflectingActivity(followUpQuestions, initialPrompt, reflectDescription, reflectStartMessage, "Reflection Activity", reflectDescription, 5);

        List<string> listeningList = new List<string>();
            listeningList.Add("Who are people that you appreciate?");
            listeningList.Add("What are personal strengths of yours?");
            listeningList.Add("Who are people that you have helped this week?");
            listeningList.Add("When have you felt the Holy Ghost this month?");
            listeningList.Add("Who are some of your personal heroes?");
        var listeningActivity = new ListeningActivity(listeningList, listenStartMessage, listenEndMessage, "Listening Activity", listenDescription, 5);
        var breathingActivity = new BreathingActivity(breatheStartMessage, breatheEndMessage, "Breathing Activity", breatheDescription, 25);
        
        int choice = 0;
        int duration = 0;

        while(choice != 4){

            Console.WriteLine("Please choose an activty(Enter a number 1-3):");
            Console.WriteLine("1. Reflecting Activity");
            Console.WriteLine("2. Listening Activity");
            Console.WriteLine("3. Breathing Activity");
            Console.WriteLine("4. Quit");

            choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("\b \b");

            if(choice == 1) {
                Console.WriteLine("How long would you like this activity to last?");
                duration = Convert.ToInt32(Console.ReadLine());
                reflectingActivity.DisplayPrompt(duration);

            }
            if(choice == 2){
                Console.WriteLine("How long would you like this activity to last?");
                duration = Convert.ToInt32(Console.ReadLine());
                listeningActivity.DisplayQuestions(duration);

            }
            if(choice ==3){
                Console.WriteLine("How long would you like this activity to last?");
                duration = Convert.ToInt32(Console.ReadLine());
                breathingActivity.BreatheCycle(duration,2,5);
            }
            
        }
}

class Activity {
    protected string _startMessage;
    protected string _endMessage; 
    protected string _activityName; 
    protected string _description; 
    protected int _durationInSeconds;

    public Activity(string startMessage, string endMessage, string activityName, string description, int durationInSeconds){
        _startMessage = startMessage;
        _endMessage = endMessage;
        _activityName = activityName;
        _description = description;
        _durationInSeconds = durationInSeconds;

    }

    public void DisplayStartMessage() {
        Console.WriteLine($"{_startMessage}");

    }

    public void DisplayEndMessage() {
        Console.WriteLine($"{_endMessage}");

    }

    public void PauseWithSpinner(int duration) {

        List<string> animations = new List<string> {
            "-",
            "\\",
            "|",
            "/",
        };

        var startTime = DateTime.Now;
        var endTime = startTime.AddSeconds(duration);
        int animationIndex = 0;

        while(DateTime.Now < endTime) {

            string frame = animations[animationIndex];
            Console.Write(frame);

            Thread.Sleep(250);

            Console.Write("\b \b");

            animationIndex++;
            if (animationIndex >= animations.Count){
                animationIndex = 0;
            }
        }
    }
        
    public void PauseWithCountdown(int duration){

        while(duration > 0) {

            duration = duration - 1;
            Console.Write($"{duration + 1}");
            Thread.Sleep(1000);

            Console.Write("\b \b");
        }
    }
}

class ReflectingActivity: Activity {
    private List<string> _prompts;
    private Random _randomPrompt = new Random();

    private string randomPrompt;

    private List<string> _followUpQuestions; 

    public ReflectingActivity(List<string> followUpQuestions,List<string> prompts, string startMessage, string endMessage, string activityName, string description, int durationInSeconds): base(startMessage, endMessage, activityName, description, durationInSeconds){
        _prompts = prompts;
        _followUpQuestions = followUpQuestions;
        int intRandomPrompt = _randomPrompt.Next(_prompts.Count);
        randomPrompt = prompts[intRandomPrompt];
    }

    public void DisplayPrompt(int duration){
        var startTime = DateTime.Now;
        var endTime = startTime.AddSeconds(duration);
        int index = 1;

        DisplayStartMessage();
        PauseWithSpinner(3);
        Console.WriteLine(randomPrompt);

        while(DateTime.Now < endTime) {
        
            Console.WriteLine(_followUpQuestions[index]);
            index++;
            if (index >= _followUpQuestions.Count){
                index = 0;
            }
            
            PauseWithSpinner(3);
        
        }
        DisplayEndMessage();
    }
    

}

class ListeningActivity: Activity {
    private List<string> _questions; 
    private Random _randomQuestion = new Random();
    private string randomQuestions;

    public ListeningActivity(List<string> questions, string startMessage, string endMessage, string activityName, string description, int durationInSeconds): base(startMessage, endMessage, activityName, description, durationInSeconds){
        _questions = questions;
        int intQuestions = _randomQuestion.Next(questions.Count);
        randomQuestions = questions[intQuestions];
    }

    public void DisplayQuestions(int duration){
        DisplayStartMessage();
        Console.WriteLine(randomQuestions);
        PauseWithCountdown(5);
        var startTime = DateTime.Now;
        var endTime = startTime.AddSeconds(duration);
        int count = 0;

        while(DateTime.Now < endTime){
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You had {count} entries. ");
    }
}

class BreathingActivity: Activity {


    public BreathingActivity(string startMessage, string endMessage, string activityName, string description, int durationInSeconds): base(startMessage, endMessage, activityName, description, durationInSeconds){
    
    }

    public void BreatheCycle(int duration, int breatheInDuration, int breatheOutDuration) {

        DisplayStartMessage();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        while (futureTime > DateTime.Now) {
            Console.WriteLine("Breathe In");
            PauseWithCountdown(breatheInDuration);

            Console.WriteLine("Breathe out");
            PauseWithCountdown(breatheOutDuration);                       
        }
    
        DisplayEndMessage();

    }
}
}