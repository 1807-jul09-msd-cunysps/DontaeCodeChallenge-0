using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactLibrary;

namespace ContactClient
{
    class Program
    {
        public static List<Person> contactList = new List<Person>();

        public static void Main(string[] args)
        {
            int selNum = 0;

            while (selNum != 6)
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine("1 : Add a Contact");
                Console.WriteLine("2 : Display Contacts");
                Console.WriteLine("3 : Search for Contact");
                Console.WriteLine("4 : Edit a Contact");
                Console.WriteLine("5 : Delete Contact");
                Console.WriteLine("6 : Close App");
                Console.WriteLine("\n***************************");
                Console.Write("\nEnter number: ");

                selNum = Convert.ToInt32(Console.ReadLine());

                switch (selNum)
                {
                    case 1:
                        ContactData.addContact();
                        break;
                    case 2:
                        ContactData.displayContact();
                        break;
                    case 3:
                        ContactData.searchContact();
                        break;
                    case 4:
                        ContactData.editContact();
                        break;
                    case 5:
                        ContactData.deleteContact();
                        break;
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}