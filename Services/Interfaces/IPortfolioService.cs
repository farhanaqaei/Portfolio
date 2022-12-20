using Portfolio2.Dtos;
using Portfolio2.Models;

namespace Portfolio2.Services.Interfaces;

public interface IPortfolioService
{
    public Person GetPersonalData();
    public ResumeDTO GetResume();
    public List<Portfolio> GetPortfolios();
}
