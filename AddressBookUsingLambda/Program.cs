using System;
using AddressbookusingLambda;

namespace AddressBookUsingLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t This is a Address book using Lambda Problem");
            AddressBookDetails abd = new AddressBookDetails();

            while (true)
            {

                Console.WriteLine("*********************************************************");
                Console.WriteLine("1.Add member to Contact list \n2.View Members in Contact List\n3.Edit members Contacts list\n4.Delete members Contacts list\n5.Search for details\n6.View details of city or state\n7.Count by city or state\n8.Sort the list\n9.Read list from file\n10.write list from file\n11.Read from Csv file\n12.Write from csv file\n13.Exit");
                Console.WriteLine("Enter an option:");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        abd.AddMember();
                        break;
                    case 2:
                        abd.ViewContacts();
                        break;
                    case 3:
                        abd.EditDetails();
                        break;
                    case 4:
                        abd.DeleteDetails();
                        break;
                    case 5:
                        abd.SearchDetails();
                        break;
                    case 6:
                        abd.ViewDetailsByStateOrCity();
                        break;
                    case 7:
                        abd.CountByStateOrCity();
                        break;
                    case 8:
                        abd.SortEntries();
                        break;
                    case 9:
                        abd.ReadFromFile();
                        break;
                    case 10:
                        abd.WriteToFile();
                        break;
                    case 11:
                        abd.ReadFromCsvFile();
                        break;
                    case 12:
                        abd.WriteToCsvFile();
                        break;
                    default:
                        // to exit from main method
                        Console.WriteLine("Exited");
                        return;


                }

            }
        }
        }
    }
