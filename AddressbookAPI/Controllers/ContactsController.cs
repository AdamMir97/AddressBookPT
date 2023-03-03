using AddressbookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressbookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactRepository _contactRepository;

        public ContactsController()
        {
            _contactRepository = new ContactRepository();
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = _contactRepository.GetAllContacts();
            Console.WriteLine(contacts);

            return Ok(contacts);
            //return View();
        }

        //read
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        //update
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact contact)
        {
            var existingContact = _contactRepository.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            _contactRepository.UpdateContact(id, contact);
            return Ok();
        }
    }
}
