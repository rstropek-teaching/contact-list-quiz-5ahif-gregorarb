using ContactList_MVC.Models;
using System.Collections.Generic;

namespace ContactList_MVC.Services
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();

        Contact GetById(int id);

        void DeleteById(int id);

        void AddContact(Contact contact);

    }
}
