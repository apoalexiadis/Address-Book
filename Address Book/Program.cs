using Address_Book;

AddressBook addressBook = new AddressBook();
AddressBook.GenerateTestData(addressBook);

while (true)
{
    try
    {
        Console.WriteLine("1. View all contacts");
        Console.WriteLine("2. Add new contact");
        Console.WriteLine("3. Search contact by name");
        Console.WriteLine("4. Search contact by phone");
        Console.WriteLine("5. Edit contact");
        Console.WriteLine("6. Delete contact");
        Console.WriteLine("7. Exit");
        Console.Write("Enter your choice: ");

        MenuOption choice = (MenuOption)Enum.Parse(typeof(MenuOption), Console.ReadLine());

        switch (choice)
        {
            case MenuOption.ViewAllContacts:
                addressBook.DisplayAllContacts();
                break;
            case MenuOption.AddNewContact:
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter phone: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Enter email: ");
                string email = Console.ReadLine();
                Console.Write("Enter address: ");
                string address = Console.ReadLine();
                Contact newContact = new Contact { Name = name, PhoneNumber = phoneNumber, Email = email, Address = address };
                addressBook.AddContact(newContact);
                break;
            case MenuOption.SearchByName:
                Console.Write("Enter name to search: ");
                string searchName = Console.ReadLine();
                Contact foundByName = addressBook.FindContactByName(searchName);
                if (foundByName != null)
                {
                    Console.WriteLine("Contact found:");
                    Console.WriteLine("Name: " + foundByName.Name);
                    Console.WriteLine("Phone: " + foundByName.PhoneNumber);
                    Console.WriteLine("Email: " + foundByName.Email);
                    Console.WriteLine("Address: " + foundByName.Address);
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
                break;
            case MenuOption.SearchByPhone:
                Console.Write("Enter phone to search: ");
                string searchPhone = Console.ReadLine();
                Contact foundByPhone = addressBook.FindContactByPhone(searchPhone);
                if (foundByPhone != null)
                {
                    Console.WriteLine("Contact found:");
                    Console.WriteLine("Name: " + foundByPhone.Name);
                    Console.WriteLine("Phone: " + foundByPhone.PhoneNumber);
                    Console.WriteLine("Email: " + foundByPhone.Email);
                    Console.WriteLine("Address: " + foundByPhone.Address);
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
                break;
            case MenuOption.EditContact:
                Console.Write("Enter name of contact to edit: ");
                string editName = Console.ReadLine();
                Contact existingContact = addressBook.FindContactByName(editName);
                if (existingContact != null)
                {
                    Console.Write("Enter new name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new phone: ");
                    string newPhone = Console.ReadLine();
                    Console.Write("Enter new email: ");
                    string newEmail = Console.ReadLine();
                    Console.Write("Enter new address: ");
                    string newAddress = Console.ReadLine();
                    Contact editedContact = new Contact { Name = newName, PhoneNumber = newPhone, Email = newEmail, Address = newAddress };
                    addressBook.EditContact(editName, editedContact);
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
                break;
            case MenuOption.DeleteContact:
                Console.Write("Enter name of contact to delete: ");
                string deleteName = Console.ReadLine();
                addressBook.DeleteContact(deleteName);
                Console.WriteLine("Contact deleted.");
                break;
            case MenuOption.Exit:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Invalid choice. Please enter a valid option.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}