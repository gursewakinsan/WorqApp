namespace WorqApp.Interfaces
{
    public interface IDashboardService
    {
        Task<List<Models.Company>> GetCompaniesByIdAsync(int id);
    }
}
