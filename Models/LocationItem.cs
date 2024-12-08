namespace ToDo.Models;

public class LocationItem
{
    //Location model
    
    //Longitude String
    public string Longitude { get; set; }
    
    //Latitude String
    public string Latitude { get; set; }

    //Controller to ensure if LocationItem is created, it should include
    //the longitude and latitude
    public LocationItem(string longitude, string latitude)
    {
        this.Longitude = longitude;
        this.Latitude = latitude;
        
    }
}