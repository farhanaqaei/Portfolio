namespace Portfolio2.Models;

public class EducationOrWorkExperience
{
    public string Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Institution { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsStillGoingOn { get; set; }
}
