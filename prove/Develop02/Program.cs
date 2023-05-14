using System;

class Program
{
    static void Main(string[] args) {


        public int loop = 7;

        int Menu() {

            
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            int numberChoice = int.Parse(Console.ReadLine());

            for (loop = 7; true ) {

                if (numberChoice == 1) {
                    Console.Write("Your response:");
                    string response = Console.ReadLine();
                    Entry.DisplayEntry();
                
                }

                if (numberChoice == 2) {

                    Journal.EntryList();
                
                }
                if (numberChoice == 3) {
                
                    FileManager.LoadJournal()
                
                }

                if (numberChoice == 4) {
                
                    FileManager.SaveJournal();
                
                }
            }

            if (numberChoice == 5) {
                Console.WriteLine("Thank you, Goodbye.")
                
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
    public string DisplayEntry() {
        
        Console.WriteLine($" {randomPrompt} ");
        Console.Write(" ");
        string _text = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        _date = theCurrentTime.ToShortDateString();

        return _date;
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

    public void SaveJournal(Journal journal, string filename) {

        using (StreamWriter outputFile = new StreamWriter(filename)) {

            foreach (var entry in journal._entries) {

                string data = $"{entry._date};{entry.randomPrompt};{entry._text}";
                outputFile.WriteLine(data);

            }

        }
    }

    public Journal LoadJournal(string filename) {

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
    