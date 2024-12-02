namespace A1;

public class Employee
{
    private string _fullName;
    private int _employeeNumber;
    private double _monthlySalary;

    public Employee(string FullName, int EmployeeNumber, double MonthlySalary)
    {
        this._fullName = FullName;
        this._monthlySalary = MonthlySalary;
        this._employeeNumber = EmployeeNumber;
    }

    public double GetYearlySalary()
    {
        return _monthlySalary * 12;
    }
}