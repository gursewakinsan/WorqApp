﻿namespace WorqApp.Interfaces
{
    public interface IHotelService
    {
        Task<int> IsHotelAsync(Models.HotelBookingRequest request);
        Task<List<Models.HotelBookingListForFrontDeskCheckinResponse>> HotelBookingListForFrontDeskCheckinAsync(Models.HotelBookingRequest request);
        Task<List<Models.HotelBookingListForFrontDeskKeyHandlingResponse>> HotelBookingListForFrontDeskKeyHandlingAsync(Models.HotelBookingListForFrontDeskKeyHandlingRequest request);
        Task<List<Models.HotelBookingListForFrontDeskKeyHandlingResponse>> HotelBookingListForFrontDeskReceivedKeyAsync(Models.HotelBookingListForFrontDeskKeyHandlingRequest request);
        Task<int> HandOverKeyAsync(Models.HandoverKeyRequest request);
        Task<List<Models.HotelBookingListForFrontDeskCheckoutResponse>> HotelBookingListForFrontDeskCheckoutAsync(Models.HotelBookingListForFrontDeskKeyHandlingRequest request);
        Task<int> CheckOutGuestAsync(Models.HandoverKeyRequest request);
        Task<List<Models.HotelBookingListForCleningStaffResponse>> HotelBookingListForCleningStaffAsync(Models.HotelBookingListForCleningStaffRequest request);
        Task<int> AllocateRoomForCleaningAsync(Models.AllocateRoomForCleaningRequest request);
        Task<int> UpdateRoomCleaningAsync(Models.UpdateRoomCleaningRequest request);
        Task<List<Models.HotelCheckedOutListForCleningStaffResponse>> HotelCheckedOutListForCleningStaffAsync(Models.HotelCheckedOutListForCleningStaffRequest request);
        Task<int> AllocateCheckedOutRoomForCleaningAsync(Models.AllocateCheckedOutRoomForCleaningRequest request);
        Task<int> UpdateCheckedOutRoomCleaningAsync(Models.UpdateCheckedOutRoomCleaningRequest request);

        //Inspect
        Task<List<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse>> HotelCheckedOutListForHousekeepingIncepectionStaffAsync(Models.HotelCheckedOutListForHousekeepingIncepectionStaffRequest request);
        Task<int> AllocateCheckedOutRoomForInspectionAsync(Models.AllocateCheckedOutRoomForInspectionRequest request);
        Task<int> UpdateCheckedOutRoomInspectionAsync(Models.UpdateCheckedOutRoomInspectionRequest request);
    }
}
