using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    internal class AddressBook
    {

        private List<Contact> contacts;

        public AddressBook() 
        { 
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public Contact? FindContactByName(string name)
        {
            return contacts.Find(contact => contact.Name == name);
        }

        public Contact FindContactByPhone(string phone)
        {
            return contacts.Find(contact => contact.PhoneNumber == phone);
        }

        public void EditContact(string name, Contact newContact)
        {
            int index = contacts.FindIndex(contact => contact.Name == name);
            if (index != -1)
            {
                contacts[index] = newContact;
            }
        }

        public void DeleteContact(string name)
        {
            try
            {
                contacts.RemoveAll(contact => contact.Name == name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the contact: " + ex.Message);
            }
        }
        

        public void DisplayAllContacts()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("Name: " + contact.Name);
                Console.WriteLine("Phone: " + contact.PhoneNumber);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine();
            }
        }

        public static void GenerateTestData(AddressBook addressBook)
        {
            try
            {
                addressBook.AddContact(new Contact { Name = "Kostas Papadopoulos", PhoneNumber = "1234567890", Email = "kostakis@example.com", Address = "Athens, Nea Filadelfia 5" });
                addressBook.AddContact(new Contact { Name = "Maria Zormpa", PhoneNumber = "9876543210", Email = "maria@example.com", Address = "Thessaloniki, Old Town 12" });
                addressBook.AddContact(new Contact { Name = "Nikos Nikolaou", PhoneNumber = "5556667777", Email = "nikos@example.com", Address = "Patra, Central Street 71" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading initial contacts: " + ex.Message);
            }        
        }
    }
}
