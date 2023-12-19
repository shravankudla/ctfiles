namespace ContactsLib
{
    public interface IContactRepo
    {
        void AddContact(Contact c);
        List<Contact> GetContacts();
        void UpdateContact(Contact c);
        void DeleteContact(int contactid);
        List<Contact> GetContactsByCity(string city);
    }
}
