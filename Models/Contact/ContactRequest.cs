﻿namespace WorqApp.Models
{
    public class ContactRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }
    }
}
