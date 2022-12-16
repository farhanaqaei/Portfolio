namespace Portfolio2.Models;

public class EducationOrExperience
{
    public string Type { get; set; }
    public string Title { get; set; }
    public string FirstDescription { get; set; }
    public string SecondDescription { get; set; }
    public string Institution { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsStillGoingOn { get; set; }
}
