using Newtonsoft.Json;
using System.Collections.Generic;

namespace AddressbookAPI.Models
{
    //class for interfacing with the json file
    public class ContactRepository
    {
        
        private readonly string _filePath  = ".\\Content\\contacts.json";

        //List all contacts
        public List<Contact> GetAllContacts()
        {
            string jsonData = File.ReadAllText(_filePath);
            //Console.WriteLine(jsonData);

            List < Contact> Contactlist = JsonConvert.DeserializeObject<List < Contact >>(jsonData);

            //Console.WriteLine(Contactlist);

            return Contactlist;
        }

        //Create
        public void AddContact(Contact contact)
        {
            List<Contact> contacts = GetAllContacts();
            //Console.WriteLine(contact.Id);
            //Console.WriteLine(contact.FullName);
            //Console.WriteLine(contact.Email);
            //Console.WriteLine(contact.Mobile);
            contacts.Add(contact);
            string jsonData = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(_filePath, jsonData);
        }

        //Read
        public Contact GetContactById(int id)
        {
            List<Contact> contacts = GetAllContacts();

            //Console.WriteLine(contacts[id].Id);

            Contact contact = null;

            //verify id is in the list:
            if (id < contacts.Count)
            {
                contact = contacts[id];
            }
            

            return contact;
        }

        //Update
        public void UpdateContact(int id, Contact contact)
        {
            List<Contact> contacts = GetAllContacts();
            contacts[id] = contact;
            
            string jsonData = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(_filePath, jsonData);
        }

        //Delete
        public void DeleteContact(int id)
        {
            List<Contact> contacts = GetAllContacts();
            contacts.RemoveAt(id);

            string jsonData = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(_filePath, jsonData);
        }

    }
}
