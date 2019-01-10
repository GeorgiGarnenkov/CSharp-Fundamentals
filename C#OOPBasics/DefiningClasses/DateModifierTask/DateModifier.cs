using System;

public class DateModifier
{
    private string firstDate;
    private string secondDate;

    public string FirstDate 
    {
        get => firstDate;
        set => firstDate = value;
    }

    public string SecondDate
    {
        get => secondDate;
        set => secondDate = value;
    }

    public void GetDifferens(string firstDate, string secondDate)
    {
        this.firstDate = firstDate;
        this.secondDate = secondDate;

        DateTime first = Convert.ToDateTime(firstDate);
        DateTime second = Convert.ToDateTime(secondDate);

        double diff = (first - second).TotalDays;

        Console.WriteLine(Math.Abs(diff));

    }
}
