using System;

class Program
{
    static void Main(string[] args)
    {

        //var savings = new Account();
        //savings.Deposit(500);
        //savings.Deposit(1000);
    }
}

//public class Account {
    //private List<int> _transactions = new List<int>();


    //public void Deposit(int amount) {
        //_transactions.Add(amount);

    //}


    //public int Balance() {
       // var balance = 0;
        //foreach (var transaction in _transactions) {
            //balance += transaction;

        //}
        //return balance;
    //}
//}

class Fraction {

    private int _top;
    private int _bottom;

    public void Frantion() {
        _top = 1;
        _bottom = 1;
    }
public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}