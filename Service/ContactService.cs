using System.Net;
using WorqApp.Helper;
using WorqApp.Interfaces;

namespace WorqApp.Service
{
	public class ContactService: IContactService
	{
		public Task<List<Models.ContactResponse>> GetContactsAsync(Models.ContactRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ContactResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ContactListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
