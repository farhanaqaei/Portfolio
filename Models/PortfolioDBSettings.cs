namespace Portfolio2.Models;

public class PortfolioDBSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PersonCollectionName { get; set; } = null!;

    public string ResumeCollectionName { get; set; } = null!;

    public string PortfolioCollectionName { get; set; } = null!;
}
