﻿namespace WorqApp.Models
{
    public class CleanersAssignedListRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_job_id")]
        public int CleaningJobId { get; set; }
    }
}
