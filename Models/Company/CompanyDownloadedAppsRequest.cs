namespace WorqApp.Models
{
    public class CompanyDownloadedAppsRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "companyId")]
        public int CompanyId { get; set; }
    }
}
