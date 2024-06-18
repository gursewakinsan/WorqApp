﻿namespace WorqApp.Interfaces
{
    public interface IChildrenService
    {
        Task<List<Models.Children>> GetMissingChildrenByIdAsync(int id);
        Task<List<Models.Children>> ReportMissingChildrenByIdAsync(int id);
        Task<string> SubmitReportMissingChildrenAsync(List<Models.ReportMissing> reportMissings);
        Task<string> InformToEmployeesForMissingChildrenAsync(int id);
    }
}
