using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressbookusingLambda
{
    class AddressBookDetails
    {
        private List<Person> contacts;
        private static List<Person> searchContacts = new List<Person>();
        //address book dictioanry to store values
        private static Dictionary<string, List<Person>> addressBookDictionary = new Dictionary<string, List<Person>>();
        private List<Person> viewContacts;
        List<Person> SortedList = new List<Person>();

        public void AddMember()
        {
            string addressBookName;
            contacts = new List<Person>();
            while (true)
            {
                Console.WriteLine("Enter The Name of the Address Book");
                addressBookName = Console.ReadLine();
                //Checking uniqueness of address books
                if (addressBookDictionary.Count > 0)
                {
                    if (addressBookDictionary.ContainsKey(addressBookName))
                    {
                        Console.WriteLine("This name of address book already exists");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

            }

            Console.Write("Enter Number of contacts you want to add:");
            int numOfContacts = Convert.ToInt32(Console.ReadLine());
            while (numOfContacts > 0)
            {
                //object for person class
                Person person = new Person();
                while (true)
                {
                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine();
                    if (contacts.Count > 0)
                    {
                        var x = contacts.Find(x => x.firstName.Equals(firstName));
                        if (x != null)
                        {
                            Console.WriteLine("Your name  already exists");
                        }
                        else
                        {
                            person.firstName = firstName;
                            break;
                        }
                    }
                    else
                    {
                        person.firstName = firstName;
                        break;
                    }

                }

                Console.Write("Enter Last Name: ");
                person.lastName = Console.ReadLine();
                Console.Write("Enter Address: ");
                person.address = Console.ReadLine();
                Console.Write("Enter City: ");
                person.city = Console.ReadLine();
                Console.Write("Enter State: ");
                person.state = Console.ReadLine();
                Console.Write("Enter Zip Code: ");
                person.zipCode = Convert.ToInt32(Console.ReadLine());

                //verification for phone number 
                while (true)
                {
                    Console.Write("Enter Phone Number: ");
                    string phNo = Console.ReadLine();
                    if (phNo.Length == 10)
                    {
                        person.phoneNumber = phNo;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Phone Number. It should Contains 10 digits");
                    }
                }
                //verification for email id
                while (true)
                {
                    Console.Write("Enter Email-id: ");
                    string emailId = Console.ReadLine();
                    if (emailId.Contains("@"))
                    {
                        person.email = emailId;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Email Id. It should Contains @ ");
                    }
                }
                //
                contacts.Add(person);
                Console.WriteLine("***************************************");

                numOfContacts--;
            }
            //adding into address book dictionary
            addressBookDictionary.Add(addressBookName, contacts);
            Console.WriteLine("**************Successfully Added****************");
        }

        //method for view Contacts
        public void ViewContacts()
        {
            if (addressBookDictionary.Count > 0)
            {
                //printing the values in address book
                foreach (KeyValuePair<string, List<Person>> dict in addressBookDictionary)
                {
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine($"******************{dict.Key}*********************");
                    Console.WriteLine("*****************************************************");
                    foreach (var addressBook in dict.Value)
                    {
                        PrintValues(addressBook);

                    }
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }

        }

        //Printing values
        public void PrintValues(Person x)
        {
            Console.WriteLine($"First Name : {x.firstName}");
            Console.WriteLine($"Last Name : {x.lastName}");
            Console.WriteLine($"Address : {x.address}");
            Console.WriteLine($"City : {x.city}");
            Console.WriteLine($"State : {x.state}");
            Console.WriteLine($"Zip Code: {x.zipCode}");
            Console.WriteLine($"Phone Number: {x.phoneNumber}");
            Console.WriteLine($"Email: {x.email}");
            Console.WriteLine("********|||||||||||********");
        }

        //method for editing details
        public void EditDetails()
        {
            int f;//flag variable
            if (contacts.Count > 0)
            {
                Console.Write("Enter name of a person you want to edit: ");
                string editName = Console.ReadLine();

                foreach (var x in contacts)
                {
                    if (editName.ToLower() == x.firstName.ToLower())
                    {
                        while (true)
                        {
                            f = 0;
                            Console.WriteLine("1.First name\n2.Last name\n3.Address\n4.City\n5.State\n6.ZipCode\n7.Phone Number\n8.email\n9.Exit");
                            Console.WriteLine("Enter Option You want to edit");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 1:
                                    Console.WriteLine("Enter New First name");
                                    x.firstName = Console.ReadLine();
                                    Console.WriteLine("\t\t\t\tMODIFIED");
                                    break;
                                case 2:
                                    Console.WriteLine("Enter New Last name");
                                    x.lastName = Console.ReadLine();
                                    Console.WriteLine("\t\t\t\tMODIFIED");
                                    break;
                                case 3:
                                    Console.WriteLine("Enter New Address");
                                    x.address = Console.ReadLine();
                                    Console.WriteLine("\t\t\t\tMODIFIED");
                                    break;
                                case 4:
                                    Console.WriteLine("Enter New City");
                                    x.city = Console.ReadLine();
                                    Console.WriteLine("\t\t\t\tMODIFIED");
                                    break;
                                case 5:
                                    Console.WriteLine("Enter New State");
                                    x.state = Console.ReadLine();
                                    Console.WriteLine("\t\t\t\tMODIFIED");
                                    break;
                                case 6:
                                    Console.WriteLine("Enter New Zip Code");
                                    x.zipCode = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("\t\t\t\tMODIFIED");
                                    break;
                                case 7:
                                    //validation for phone number
                                    while (true)
                                    {
                                        Console.Write("Enter new Phone Number: ");
                                        string phNo = Console.ReadLine();
                                        if (phNo.Length == 10)
                                        {
                                            x.phoneNumber = phNo;
                                            Console.WriteLine("\t\t\t\tMODIFIED");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter Valid Phone Number. It should Contains 10 digits");
                                        }
                                    }
                                    break;
                                case 8:
                                    //validation for email id
                                    while (true)
                                    {
                                        Console.Write("Enter new Email-id: ");
                                        string emailId = Console.ReadLine();
                                        if (emailId.Contains("@"))
                                        {
                                            x.email = emailId;
                                            Console.WriteLine("\t\t\t\tMODIFIED");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter Valid Email Id. It should Contains @ ");
                                        }
                                    }
                                    break;
                                case 9:
                                    // to exit from main method
                                    Console.WriteLine("Exited");
                                    f = 1;
                                    break;

                            }
                            if (f == 1)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entered name is not in Contact list");
                    }
                }
            }
            else
            {
                Console.WriteLine("Your contact list is empty");
            }
        }

        //method for deleting conatcts
        public void DeleteDetails()
        {
            int f = 0;
            Console.Write("Enter name of a Address Book in which you want to Delete a person: ");
            string deleteAbName = Console.ReadLine();
            Console.Write("Enter name of a person you want to Delete: ");
            string deleteName = Console.ReadLine();
            if (addressBookDictionary.Count > 0)
            {
                if (addressBookDictionary.ContainsKey(deleteAbName))
                {
                    foreach (KeyValuePair<string, List<Person>> dict in addressBookDictionary)
                    {
                        if (dict.Key.Equals(deleteAbName))
                        {
                            foreach (var x in dict.Value)
                            {
                                if (deleteName.ToLower() == x.firstName.ToLower())
                                {
                                    //removing from list
                                    Console.WriteLine("\t\t\t\tDELETED");
                                    Console.WriteLine($"You have deleted {x.firstName} contact");
                                    dict.Value.Remove(x);
                                    f = 1;
                                    break;
                                }
                            }
                            if (f == 0)
                            {
                                Console.WriteLine("The name you have entered not in the address book");
                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Address Book is not found");
                }


            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }



        }

        public void SearchDetails()
        {
            string personName;
            Console.WriteLine("1. Search by city name\n2.Search By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to search:");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search:");
                    personName = Console.ReadLine();
                    SearchByCityName(cityName, personName);
                    break;
                case 2:
                    Console.WriteLine("Enter the state of city in which you want to search:");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search:");
                    personName = Console.ReadLine();
                    SearchByStateName(stateName, personName);
                    break;
                default:
                    return;

            }

        }
        public void ViewDetailsByStateOrCity()
        {

            Console.WriteLine("1. View by city name\n2.View By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to view:");
                    string cityName = Console.ReadLine();
                    ViewByCityName(cityName, "count");
                    break;
                case 2:
                    Console.WriteLine("Enter the state of city in which you want to view:");
                    string stateName = Console.ReadLine();
                    ViewByStateName(stateName, "count");
                    break;
                default:
                    return;

            }

        }
        public void CountByStateOrCity()
        {

            Console.WriteLine("1.Count by city name\n2.Count By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to count persons:");
                    string cityName = Console.ReadLine();
                    ViewByCityName(cityName, "count");
                    break;
                case 2:
                    Console.WriteLine("Enter the name of state in which you want to count persons:");
                    string stateName = Console.ReadLine();
                    ViewByStateName(stateName, "count");
                    break;
                default:
                    return;

            }

        }

        public void ViewByCityName(string cityName, string count)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Person>> dict in addressBookDictionary)
                {
                    viewContacts = dict.Value.FindAll(x => x.state.Equals(cityName));
                }
                if (searchContacts.Count > 0)
                {
                    foreach (var x in searchContacts)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("No Persons found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }
        public void ViewByStateName(string stateName, string count)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Person>> dict in addressBookDictionary)
                {
                    viewContacts = dict.Value.FindAll(x => x.state.Equals(stateName));
                }
                if (searchContacts.Count > 0)
                {
                    foreach (var x in searchContacts)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("No Persons found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }

        public void SearchByCityName(string cityName, string personName)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Person>> dict in addressBookDictionary)
                {
                    searchContacts = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(cityName));


                }
                if (searchContacts.Count > 0)
                {
                    foreach (var x in searchContacts)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }
        public void SearchByStateName(string stateName, string personName)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Person>> dict in addressBookDictionary)
                {
                    searchContacts = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(stateName));

                }
                if (searchContacts.Count > 0)
                {
                    foreach (var x in searchContacts)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }

        }
        public void SortEntries()
        {
            Console.WriteLine("1.Sort by person name\n2.Sort by city name\n3.Sort by state name\n4.Sort by zipcode\nEnter Your option");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    SortList("name");
                    break;
                case 2:
                    SortList("city");
                    break;
                case 3:
                    SortList("state");
                    break;
                case 4:
                    SortList("zipcode");
                    break;

            }
        }

        public void SortList(string check)
        {
            if (addressBookDictionary.Count > 0)
            {

                //printing the values in address book
                foreach (KeyValuePair<string, List<Person>> dict in addressBookDictionary)
                {
                    switch (check)
                    {
                        case "name":
                            //sorting list based on first name
                            SortedList = dict.Value.OrderBy(x => x.firstName).ToList();
                            break;
                        case "city":
                            SortedList = dict.Value.OrderBy(x => x.city).ToList();
                            break;
                        case "state":
                            SortedList = dict.Value.OrderBy(x => x.state).ToList();
                            break;
                        case "zipcode":
                            SortedList = dict.Value.OrderBy(x => x.zipCode).ToList();
                            break;
                    }

                    Console.WriteLine($"**********AFTER SORTING {dict.Key}**********");
                    foreach (var addressBook in SortedList)
                    {
                        PrintValues(addressBook);
                    }
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }

        }
    }
}