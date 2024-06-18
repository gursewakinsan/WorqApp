namespace WorqApp.Interfaces
{
    public interface IAdminService
    {
        Task<List<Models.CountryCodeListResponse>> CountryCodeListAsync();
        Task<int> InviteVisitorAsync(Models.InviteVisitorRequest request);
    }
}
