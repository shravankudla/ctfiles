namespace ContactsLib
{
    public class InMemoryContactRepo : IContactRepo
    {
        ContactContext context  = new ContactContext();
        public void AddContact(Contact c)
        {
            context.Contacts.Add(c);
            context.SaveChanges();
        }

        public void DeleteContact(int contactid)
        {
            var existingContact = context.Contacts.Where(cont => cont.ContactNo == contactid).FirstOrDefault();

            if (existingContact != null)
            {
                context.Contacts.Remove(existingContact);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No contact found");
            }
        }

        public List<Contact> GetContacts()
        {
            return context.Contacts.ToList();
        }

        public List<Contact> GetContactsByCity(string city)
        {
            var existingContact = context.Contacts.Where(cont => cont.City == city);

            if (existingContact != null)
            {
                return existingContact.ToList();
            }

            return null;
        }

        public void UpdateContact(Contact c)
        {
            var existingContact = context.Contacts.Find(c.ContactNo);

            if (existingContact != null)
            {
                existingContact.ContactName = c.ContactName;
                existingContact.City = c.City;
                existingContact.CellNo = c.CellNo;

                context.Contacts.Update(existingContact);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No contact found.");
            }
        }
    }
}
