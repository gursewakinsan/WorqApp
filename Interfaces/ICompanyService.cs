namespace WorqApp.Interfaces
{
    public interface ICompanyService
    {
        Task<Models.VerifyAdminResponse> VerifyAdminAsync(Models.VerifyAdminRequest request);
        Task<List<Models.CompanyDownloadedAppsResponse>> CompanyDownloadedAppsAsync(Models.CompanyDownloadedAppsRequest request);
        Task<Models.DaycareResponse> DaycareRequestCountAsync(Models.DaycareRequest request);
    }
}
