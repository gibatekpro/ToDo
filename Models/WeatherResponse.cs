namespace ToDo.Models;

public class WeatherResponse
{
    public Current Current { get; set; }
}

public class Current
{
    public decimal Temp_c { get; set; } //Represents temperature in Degree Celsius
    public Condition Condition { get; set; }
}

public class Condition
{
    public string Text { get; set; } //e.g (partly cloudy)
}