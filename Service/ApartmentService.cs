﻿using System.Net;
using WorqApp.Helper;
using WorqApp.Interfaces;

namespace WorqApp.Service
{
    public class ApartmentService : IApartmentService
    {
		public Task<Models.ApartmentCommunityTicketListResponse> ApartmentCommunityTicketListAsync(Models.ApartmentCommunityTicketListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApartmentCommunityTicketListResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentCommunityTicketListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateApartmentCommunityTicketAsync(Models.UpdateApartmentCommunityTicketRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateApartmentCommunityTicketUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.ApartmentCommunityTicketDetailResponse> ApartmentCommunityTicketDetailAsync(Models.ApartmentCommunityTicketDetailRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApartmentCommunityTicketDetailResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentCommunityTicketDetailUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
