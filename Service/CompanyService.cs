﻿using System.Net;
using WorqApp.Helper;
using WorqApp.Interfaces;

namespace WorqApp.Service
{
	public class CompanyService : ICompanyService
	{
		public Task<Models.VerifyAdminResponse> VerifyAdminAsync(Models.VerifyAdminRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyAdminResponse>(HttpWebRequest.Create(string.Format(EndPointsList.VerifyAdminUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CompanyDownloadedAppsResponse>> CompanyDownloadedAppsAsync(Models.CompanyDownloadedAppsRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CompanyDownloadedAppsResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CompanyDownloadedAppsUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.DaycareResponse> DaycareRequestCountAsync(Models.DaycareRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.DaycareResponse>(HttpWebRequest.Create(string.Format(EndPointsList.DaycareRequestCountUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
