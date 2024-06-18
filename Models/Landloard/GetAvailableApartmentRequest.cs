namespace WorqApp.Models
{
    public class GetAvailableApartmentRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "request_id")]
        public int RequestId { get; set; }
    }
}
