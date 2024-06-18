﻿namespace WorqApp.Interfaces
{
    public interface IPremiumService
    {
        Task<List<Models.EmployeeProfessionalServiceProposalsDatesResponse>> EmployeeProfessionalServiceProposalsDatesAsync(Models.EmployeeProfessionalServiceProposalsDatesRequest request);
        Task<List<Models.EmployeeProfessionalServiceProposalsResponse>> EmployeeProfessionalServiceProposalsAsync(Models.EmployeeProfessionalServiceProposalsRequest request);
        Task<Models.PropertyDetailResponse> PropertyDetailAsync(Models.PropertyDetailRequest request);
        Task<string> UpdateProfessionalJobStatusAsync(Models.UpdateProfessionalJobStatusRequest request);
    }
}
