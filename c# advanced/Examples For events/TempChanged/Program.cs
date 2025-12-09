using System;

public class TempretureChanged : EventArgs
{
    public double OldTempreture { get; }
    public double NewTempreture { get; }
    public double Difference { get; }

    public TempretureChanged(double OldTempreture, double NewTempreture)
    {
        this.OldTempreture = OldTempreture;
        this.NewTempreture = NewTempreture;
        this.Difference = OldTempreture - NewTempreture;
    }
}

public class Thermostat
{

    public event EventHandler<TempretureChanged> TempChanged;

    private double OldTempreture;
    private double CurrentTempreture;

    protected virtual void OnTempChange(TempretureChanged e)
    {
        TempChanged?.Invoke(this, e);
    }

    public void SetTempretue(double NewTempreture)
    {
        if (NewTempreture != CurrentTempreture)
        {
            OldTempreture = CurrentTempreture;
            CurrentTempreture = NewTempreture;
            OnTempChange(new TempretureChanged(OldTempreture, CurrentTempreture));
        }
    }
}

public class Display
{
    public void HandleTempretureChanges(object sender, TempretureChanged e)
    {
        Console.WriteLine();
        Console.WriteLine("Temperature changed:");
        Console.WriteLine($"  From: {e.OldTempreture}°C");
        Console.WriteLine($"  To:   {e.NewTempreture}°C");
        Console.WriteLine($"  Difference:    {e.Difference}°C");
    }

    public void subscribe(Thermostat thermostat)
    {
        thermostat.TempChanged += HandleTempretureChanges;
    }

    public void Unsubscribe(Thermostat thermostat)
    {
        thermostat.TempChanged -= HandleTempretureChanges;
    }
}

public class Program
{
    static void Main()
    {
        var Thermostat = new Thermostat();
        var Display = new Display();
        Display.subscribe(Thermostat);

        Thermostat.SetTempretue(50);
        Thermostat.SetTempretue(55);
        Thermostat.SetTempretue(60);
        Thermostat.SetTempretue(65);
        Thermostat.SetTempretue(60);

    }
}