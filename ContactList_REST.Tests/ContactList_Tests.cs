using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ContactList_REST.Tests
{
    [TestClass]
    public class ContactList_Tests
    {
        [TestMethod]
        public void GetAllItems()
        {
            var controller = new ContactsController();

            var result = controller.GetAll() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void InsertItemSuccess()
        {
            var controller = new ContactsController();

            var result = controller.Add(new Person(10, "Vorname", "Nachname", "vorname.nachname@gmail.com")) as CreatedResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
        }

        [TestMethod]
        public void DeleteItemFailed()
        {
            var controller = new ContactsController();

            // A person with that ID doesn't exist
            var result = controller.Delete(12133123) as NotFoundResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void FindByName()
        {
            var controller = new ContactsController();

            // There should be 2 persons containing a 'x'
            var result = controller.FindByName("x") as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
