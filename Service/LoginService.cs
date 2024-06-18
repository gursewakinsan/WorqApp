﻿using System.Net;
using WorqApp.Helper;
using WorqApp.Interfaces;

namespace WorqApp.Service
{
    public class LoginService : ILoginService
    {
        public Task<Models.LoginResponse> LoginAsync(Models.LoginRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<Models.LoginResponse>(HttpWebRequest.Create(string.Format(EndPointsList.LoginUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<Models.InterAppSessionResponse> LoginWithSessionAsync(Models.InterAppSessionRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<Models.InterAppSessionResponse>(HttpWebRequest.Create(string.Format(EndPointsList.VerifyInterAppSessionUrl)), string.Empty, request.ToJson());
                return res;
            });
        }
    }
}
