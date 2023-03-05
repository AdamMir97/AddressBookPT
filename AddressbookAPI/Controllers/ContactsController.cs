using AddressbookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;


namespace AddressbookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactRepository _contactRepository;

        public ContactsController(ContactRepository @object)
        {
            _contactRepository = new ContactRepository();
        }

        //list all contacts
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetContacts()
        {
            var contacts = _contactRepository.GetAllContacts();
            //Console.WriteLine(contacts);

            return Ok(contacts);
            //return View();
        }

        //create

        //TODO: ensure the POST requests follow the schema
        //[HttpPost]
        //public IActionResult Post([FromBody] JObject input)
        //{
        //    //validate against schema
        //    string schemapath = ".\\Content\\contacts-schema.json";
        //    JSchema schema = JSchema.Parse(System.IO.File.ReadAllText(schemapath));
        //    IList<string> errors;
        //    bool isValid = input.IsValid(schema, out errors);

        //    if (!isValid)
        //    {
        //        return BadRequest(errors);
        //    }

        //    //Contact contact = JsonConvert.DeserializeObject<Contact>(input);
        //    Contact contact = input.ToObject<Contact>();
        //    _contactRepository.AddContact(contact);
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            _contactRepository.AddContact(contact);
            return Ok();
        }

        //read
        [HttpGet("{id}")]
        [Produces("application/json")]
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
        //TODO: ensure the IDs are not overwritten
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

        //delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingContact = _contactRepository.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            _contactRepository.DeleteContact(id);
            return Ok();
        }
    }
}
