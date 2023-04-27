using System;

class Program
{
    static void Main(string[] args)
    {
        Random generator = new Random();
        int magicNumber = generator.Next(1,101);

        int userGuess = -1;
        while (userGuess != magicNumber) {

            Console.Write("Please guess a number between 1-100 ");
            userGuess = int.Parse(Console.ReadLine());

            if (userGuess > magicNumber) {
                Console.WriteLine("Lower");
            }
            if (userGuess < magicNumber) {
                Console.WriteLine("Higher");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Congratulations! You Guessed the Magic Number!!");
        Console.WriteLine();
        
    }

}