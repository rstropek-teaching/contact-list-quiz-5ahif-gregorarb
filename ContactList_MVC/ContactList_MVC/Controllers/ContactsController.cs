using Microsoft.AspNetCore.Mvc;
using ContactList_MVC.Services;
using ContactList_MVC.Models;

namespace ContactList_MVC.Controllers
{
    public class ContactsController : Controller
    {
        private IContactRepository repository;

        public ContactsController(IContactRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Shows a list of all Contacts
        /// </summary>
        /// <returns>a view with a list of all contacts</returns>
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        /// <summary>
        /// Shows a specific contact in detail
        /// </summary>
        /// <param name="id">id of the contact to be viewed in detail</param>
        /// <returns>details of the selected contact</returns>
        public IActionResult Details(int id)
        {
            var contact = repository.GetById(id);
            return View(contact);
        }

        /// <summary>
        /// This method returns a view, where the user can then delete the contact
        /// Basically, it does the same as the Details
        /// </summary>
        /// <param name="id">id of the contact to be deleted</param>
        /// <returns>A View with the contact to be deleted</returns>
        public IActionResult Delete(int id)
        {
            var contactToDelete = repository.GetById(id);
            if(contactToDelete == null)
            {
                return NotFound();
            }
            return View(contactToDelete);
        }

        /// <summary>
        /// Deletes the contact from the List
        /// </summary>
        /// <param name="id">id of the contact to be deleted</param>
        /// <returns>redirects back to the contacts-list</returns>
        public IActionResult DeleteConfirmed(int id)
        {
            repository.DeleteById(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Adds a new contact to the list
        /// </summary>
        /// <param name="contact">Contact to be added</param>
        /// <returns>A view with the new contact</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            repository.AddContact(contact);
            return RedirectToAction("Index");
        }
    }
}