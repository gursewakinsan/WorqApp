namespace WorqApp.Models
{
	public class HotelBookingListForKeyGenerationRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string HotelId { get; set; }
	}
}
