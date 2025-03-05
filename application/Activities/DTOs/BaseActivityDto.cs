using System;

namespace application.Activities.DTOs;

public class BaseActivityDto
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Description { get; set; } = "";
    public string Category { get; set; } = "";

    public string City { get; set; } = "";
    public string Venue { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
