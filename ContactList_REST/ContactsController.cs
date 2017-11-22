using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList_REST
{
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        private static List<Person> items = new List<Person>();

        /// <summary>
        /// Add some test data
        /// </summary>
        public ContactsController()
        {
            // This way the items are only added once
            if (items.Count() == 0)
            {
                items.Add(new Person(1, "ABCD", "EFGH", "abcd.efgh@gmail.com"));
                items.Add(new Person(2, "IJKL", "MNOP", "ijkl.mnop@gmail.com"));
                items.Add(new Person(3, "QRST", "UVWX", "qrst.uvwx@gmail.com"));
                items.Add(new Person(4, "YZYX", "WVUT", "yzyx.wvut@gmail.com"));
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // Returns Status 200 (OK) with all existing items
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Person body)
        {
            if (body == null)
            {
                return BadRequest();
            }

            items.Add(body);
            return Created("api/contacts", body);
        }

        [HttpDelete("{personId}")]
        public IActionResult Delete(long personId)
        {
            // an invalid id was entered, for example a letter (can't be saved into long)
            if(personId == 0)
            {
                return BadRequest();
            }

            var person = items.FirstOrDefault(p => p.Id == personId);
            if (person == null)
            {
                return NotFound();
            }

            items.Remove(person);
            // NoContentResult has Statuscode 204
            return new NoContentResult();
        }

        [HttpGet("findByName")]
        public IActionResult FindByName([FromQuery] string nameFilter)
        {   
            if (string.IsNullOrEmpty(nameFilter))
            {
                return BadRequest();
            }

            // Ignore case
            var matchingItems = items.Where(n => n.LastName.ToUpper().Contains(nameFilter.ToUpper()) 
                                              || n.FirstName.ToUpper().Contains(nameFilter.ToUpper()))
                                              .ToList();

            if (matchingItems == null || matchingItems.Count == 0)
            {
                return BadRequest();
            }

            return Ok(matchingItems);
        }
    }
}
