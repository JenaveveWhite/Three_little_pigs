using System;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("Mosiah",2, 41, 41);
        var scripture = new Scripture("And moreover, I would desire that ye should consider on the blessed and happy state of those that keep the commandments of God. For behold, they are blessed in all things, both temporal and spiritual; and if they hold out faithful to the end they are received into heaven, that thereby they may dwell with God in a state of never-ending happiness. O remember, remember that these things are true; for the Lord God hath spoken it.", reference);

        
        while (scripture.CheckHidden() == false) {
            reference.DisplayReference();
            scripture.DisplayScripture();
            Console.ReadLine();
            scripture.Remove3Words();

        }
        }
}