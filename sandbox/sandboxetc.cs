using System;

class Program{

    static void Main(string[] args){

        var hourly = new HourlyEmployee(1000, "elon musk", 14);
        var salary = new SalaryEmployee(90000, "Robert oppenheimer", 14);

        var employees = new List<Employee> {hourly, salary};

        foreach(var employee in employees) {
            Console.WriteLine(employee.name);
            Console.WriteLine(employee.PayPeriodWages());
        }

    }

}

class Employee{
    protected string _name;

    protected double _payPeriodLength;

    public Employee(string name, int payPeriodLength){
        _name = name;
        _payPeriodLength = payPeriodLength;
    }

    virtual public double PayPeriodWages(){
        return 0;
    }
}

class HourlyEmployee: Employee{

    protected double _rate;

    HourlyEmployee(double rate, string name, int payPeriodLength): base(name,payPeriodLength){
        _rate = rate;
    }
    public override double PayPeriodWages(){
        return rate * 8 * _payPeriodLength;
    }


}

class SalaryEmployee: Employee {

    protected double _annualRate;

    SalaryEmployee(double annualRate, string name, int payPeriodLength): base(name, payPeriodLength){
        _annualRate = annualRate;
    }

    public override double PayPeriodLength(){

        return (_payPeriodLength / 365.0) * _annualRate;

        return annualRate;
    }


}