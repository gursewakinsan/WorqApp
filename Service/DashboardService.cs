using System.Net;
using WorqApp.Interfaces;

namespace WorqApp.Service
{
    public class DashboardService : IDashboardService
    {
        public Task<List<Models.Company>> GetCompaniesByIdAsync(int id)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Get<List<Models.Company>>(HttpWebRequest.Create(string.Format(EndPointsList.CompaniesListUrl, id)));
                return res;
            });
        }
    }
}
