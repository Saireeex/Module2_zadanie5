using System;

class TemperatureSensor
{
    private int temperature;

    public event Action<int> TemperatureChanged;

    public int Temperature
    {
        get => temperature;
        set
        {
            if (temperature != value)
            {
                temperature = value;
                OnTemperatureChanged(temperature);
            }
        }
    }

    protected virtual void OnTemperatureChanged(int temperature)
    {
        TemperatureChanged?.Invoke(temperature);
    }
}

class Thermostat
{
    public Thermostat(TemperatureSensor sensor)
    {
        sensor.TemperatureChanged += OnTemperatureChanged;
    }

    private void OnTemperatureChanged(int temperature)
    {
        if (temperature < 20)
            Console.WriteLine("Heating ON");
        else
            Console.WriteLine("Heating OFF");
    }
}

class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Thermostat thermostat = new Thermostat(sensor);

        sensor.Temperature = 18; // Heating ON
        sensor.Temperature = 10; // Heating OFF
    }
}
