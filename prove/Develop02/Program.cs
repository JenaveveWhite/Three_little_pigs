using System;

class Program
{
    static void Main(string[] args) {

        Menu();
    }
    static void Menu() {

            var journal = new Journal();


            while (true) {

            var fileManager = new FileManager();

            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            int numberChoice = int.Parse(Console.ReadLine());

            

                if (numberChoice == 1) {
                    var entry = new Entry();
                    entry.CreateEntry();
                    journal._entries.Add(entry);
                
                }

                if (numberChoice == 2) {

                    journal.DisplayEntryList();
                
                }
                if (numberChoice == 3) {
                    
                    journal = fileManager.LoadJournal();
                
                }

                if (numberChoice == 4) {
                
                    fileManager.SaveJournal(journal);
                
                }

                if (numberChoice == 5) {
                Console.WriteLine("Thank you, Goodbye.");
                break;
            }


  
                
            }            
        }
}


class Entry 
{

    // atributes 
    public string _text;

    public string randomPrompt; 

    public string _date;
    
    // methods
    public void CreateEntry() {
        
        var generator = new PromptGenerator();
        randomPrompt = generator.RandomPrompt();
        Console.WriteLine($" {randomPrompt} ");
        Console.Write(" ");
        _text = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        _date = theCurrentTime.ToShortDateString();

        
    }
}

class Journal 
{
    public List<Entry> _entries = new List<Entry>();

    public void DisplayEntryList() {
        
        foreach (var entry in _entries) {
            Console.WriteLine($"{entry._date} {entry.randomPrompt} {entry._text}");

        }

    }

}

class PromptGenerator
{


    List<string> prompts = new List<String> {
            "What is your most meaningful memory?",
            "How many siblings do you have?",
            "What is your life motto?"
            
        };
    public string RandomPrompt() {
        Random rnd = new Random();
        int number = rnd.Next(0,2);
        var randomPrompt = prompts[number];

        return randomPrompt;
    }
}

class FileManager {

    public void SaveJournal(Journal journal) {

        Console.Write("Please name file: ");
        var filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename)) {

            foreach (var entry in journal._entries) {

                string data = $"{entry._date};{entry.randomPrompt};{entry._text}";
                outputFile.WriteLine(data);

            }

        }
    }

    public Journal LoadJournal() {

        Console.Write("Please name file: ");
        var filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);
        Journal journal = new Journal();
        
        foreach (string line in lines) {

            string[] parts = line.Split(";");

            string date = parts[0];
            string prompt = parts[1];
            string text = parts[2];

            Entry entry = new Entry();
            entry._date = date;
            entry.randomPrompt = prompt;
            entry._text = text;

            journal._entries.Add(entry);
        }

        return journal;

    
    }
}
    