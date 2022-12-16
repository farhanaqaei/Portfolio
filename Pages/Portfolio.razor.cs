namespace Portfolio2.Pages;

public partial class Portfolio
{
    private string ActiveLink = "All";
    private List<Models.Portfolio>? portfolios;
    private List<Models.Portfolio>? filteredPortfolios;
    private List<string> projectTypes = new List<string> { "All" };

    protected override void OnInitialized()
    {
        portfolios = PortfolioService.GetPortfolios();
        filteredPortfolios = portfolios;
        projectTypes.AddRange(portfolios.Select(x => x.ProjectType).Distinct().ToList());
    }

    protected void FilterPortfolios(string projectType)
    {
        ActiveLink = projectType;
        if (projectType != "All")
            filteredPortfolios = portfolios.Where(x => x.ProjectType == projectType).ToList();
        else
            filteredPortfolios = portfolios;
    }
}
