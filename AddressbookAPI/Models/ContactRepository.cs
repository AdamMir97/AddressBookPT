using Newtonsoft.Json;
using System.Collections.Generic;

namespace AddressbookAPI.Models
{
    public class ContactRepository
    {
        private readonly string _filePath  = ".\\Content\\contacts.json";

        public List<Contact> GetAllContacts()
        //public Contact GetAllContacts()
        {
            string jsonData = File.ReadAllText(_filePath);
            Console.WriteLine(jsonData);

            List < Contact> Contactlist = JsonConvert.DeserializeObject<List < Contact >>(jsonData);
            //Contact Contactlist = JsonConvert.DeserializeObject<Contact>(jsonData);

            //Console.WriteLine(Contactlist);

            return Contactlist;
        }

        public Contact GetContactById(int id)
        {
            List<Contact> contacts = GetAllContacts();

            //Console.WriteLine(contacts[id].Id);
            return contacts[id];
        }

        public void UpdateContact(int id, Contact contact)
        {
            List<Contact> contacts = GetAllContacts();
            contacts[id] = contact;
            
            string jsonData = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(_filePath, jsonData);
        }

    }
}
