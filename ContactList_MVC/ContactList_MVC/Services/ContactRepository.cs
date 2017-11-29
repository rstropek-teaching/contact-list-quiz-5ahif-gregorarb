using ContactList_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactList_MVC.Services
{
    public class ContactRepository : IContactRepository
    {
        private List<Contact> contacts = new List<Contact>
        {
            new Contact {ID = 1, FirstName = "ABCDEF", LastName = "GHIJKL", Email = "abcdef.ghijkl@gmail.com"},
            new Contact {ID = 2, FirstName = "MNOPQR", LastName = "STUVWX", Email = "mnopqr.stuvwx@gmail.com"},
            new Contact {ID = 3, FirstName = "YZABCD", LastName = "EFGHIJ", Email = "yzabcd.efghij@gmail.com"},
            new Contact {ID = 4, FirstName = "123", LastName = "321", Email = "123.321@gmail.com"},
            new Contact {ID = 5, FirstName = "345", LastName = "543", Email = "345.543@gmail.com"},
            new Contact {ID = 6, FirstName = "567", LastName = "765", Email = "567.765@gmail.com"},
            new Contact {ID = 7, FirstName = "789", LastName = "987", Email = "789.987@gmail.com"},
            new Contact {ID = 8, FirstName = "a1b", LastName = "b1a", Email = "a1b.b1a@gmail.com"},
            new Contact {ID = 9, FirstName = "c2d", LastName = "d2c", Email = "c2d.d2c@gmail.com"},
            new Contact {ID = 10, FirstName = "e3f", LastName = "f3e", Email = "e3f.f3e@gmail.com"},
            new Contact {ID = 11, FirstName = "g4h", LastName = "h4g", Email = "g4h.h4g@gmail.com"},
        };

        public IEnumerable<Contact> GetAll() => contacts.ToArray();

        public Contact GetById(int id) => contacts.First(c => c.ID == id);

        public void DeleteById(int id) => contacts.Remove(contacts.First(c => c.ID == id));

        public void AddContact(Contact contact) => contacts.Add(contact);
    }
}
