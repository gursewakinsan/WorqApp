﻿using System.Text.RegularExpressions;

namespace WorqApp.Helper
{
    public static class Helper
    {
        public static T FromJson<T>(this string jsonData)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData);
        }
        public static string ToJson(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static bool IsValid(string value)
        {
            return CheckEmail(value);
        }
        public static bool CheckEmail(string input)
        {
            return Regex.IsMatch(input,
           @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
           RegexOptions.IgnoreCase);
        }

        public static int LoggedInUserId { get; set; }
        public static int CompanyId { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static int DomainId { get; set; }
        public static int ProfessionalSubcategoryId { get; set; }
        public static int CategoryId { get; set; }
        public static string SubcategoryName { get; set; }
        public static string SessionId { get; set; }
        public static string CompanyName { get; set; }
        public static Models.ContactResponse SelectedContact { get; set; }
        public static Models.OperatorQueueResponse SelectedOperatorQueue { get; set; }
        public static int QueueGuestId { get; set; }
        public static string ApartmentId { get; set; }
        public static string SelectedTabQueueText { get; set; } = string.Empty;
        public static Models.ApartmentCommunityTicketListResponse ApartmentCommunityTicketInfo { get; set; }
        public static string HotelId { get; set; }
        public static int SelectedCleaningJob { get; set; }
        public static List<Models.EmployeeProfessionalServiceProposalsDatesResponse> ProposalsDates { get; set; }
        public static bool IsAddNew { get; set; }

        public static string[] ListIconBgColorList =
        {
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125",
            "#223426", "#282732", "#342334", "#FC7125"
        };

        public static string[] ListIconTextColorList =
        {
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614",
            "#4FD471", "#6F70FB", "#E340EC","#E53614"
        };
    }
}
