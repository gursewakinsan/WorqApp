﻿namespace WorqApp.Interfaces
{
    public interface IVerifyHotelStaffService
    {
        Task<int> VerifEmployeeInfoAsync(Models.VerifEmployeeInfoRequest request);
        Task<List<Models.HotelBookingListForKeyGenerationResponse>> HotelBookingListForKeyGenerationAsync(Models.HotelBookingListForKeyGenerationRequest request);
        Task<List<Models.HotelBookingInstaBoxListForKeyGenerationResponse>> HotelBookingInstaBoxListForKeyGenerationAsync(Models.HotelBookingInstaBoxListForKeyGenerationRequest request);
        Task<int> GenerateKeyForInstaBoxAsync(Models.GenerateKeyForInstaBoxRequest request);
        Task<int> ReleaseHotelInstaboxAsync(Models.HotelBookingInstaBoxListForKeyGenerationRequest request);
        Task<List<Models.GetAvailableRoomsResponse>> GetAvailableRoomsAsync(Models.GetAvailableRoomsRequest request);
    }
}
