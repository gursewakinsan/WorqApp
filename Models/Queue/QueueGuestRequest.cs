namespace WorqApp.Models
{
    public class QueueGuestRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_id")]
        public int GuestId { get; set; }
    }
}
