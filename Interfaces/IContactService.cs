namespace WorqApp.Interfaces
{
    public interface IContactService
    {
        Task<List<Models.ContactResponse>> GetContactsAsync(Models.ContactRequest request);
    }
}
