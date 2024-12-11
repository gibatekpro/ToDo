namespace ToDo.Models;

//Author: Anthony Gibah
public class LocationItem
{
    //Location model
    
    //Longitude String
    public decimal Longitude { get; set; }
    
    //Author: Anthony Gibah
    //Latitude String
    public decimal Latitude { get; set; }

    //Controller to ensure if LocationItem is created, it should include
    //the longitude and latitude
    public LocationItem(decimal longitude, decimal latitude)
    {
        this.Longitude = longitude;
        this.Latitude = latitude;
        
    }
}