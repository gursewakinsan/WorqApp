﻿namespace WorqApp.Models
{
    public class MinimumTimeModel
    {
        public int Id { get; set; }
        public string MinimumTime { get; set; }
    }

    public class PreparationTimeModel
    {
        public int Id { get; set; }
        public string PreparationTime { get; set; }
    }

    public class PostProductionTimeModel
    {
        public int Id { get; set; }
        public string PostProductionTime { get; set; }
    }

    public class BookingTypeModel
    {
        public int Id { get; set; }
        public string BookingType { get; set; }
    }

    public class SharedTypeModel
    {
        public int Id { get; set; }
        public string SharedType { get; set; }
    }

    public class SubscriptionTypeModel
    {
        public int Id { get; set; }
        public string SubscriptionType { get; set; }
    }

    public class CustomSubscriptionTypeModel
    {
        public int Id { get; set; }
        public string CustomSubscriptionType { get; set; }
    }

    public class CustomMinimumTimeModel
    {
        public int Id { get; set; }
        public string MinimumTime { get; set; }
    }
}
