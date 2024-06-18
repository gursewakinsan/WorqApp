namespace WorqApp.Models
{
    public class CleaningServiceAvailableTodoDetailRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_job_id")]
        public int CleaningJobId { get; set; }
    }
}
