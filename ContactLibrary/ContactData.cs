using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary
{
    public class ContactData
    {
        //public static List<Person> contactList = new List<Person>();
        public static List<PersonMembers> contactList = new List<PersonMembers>();

        //Add contact method
        public static void addContact()
        {
            #region USER INPUTS
            Console.WriteLine("Insert first name: ");
            string fname = Console.ReadLine();

            Console.WriteLine("Insert last city: ");
            string lname = Console.ReadLine();

            Console.WriteLine("Insert Address: ");
            string streetAddress = Console.ReadLine();

            Console.WriteLine("Insert House Number: ");
            string numAddress = Console.ReadLine();

            Console.WriteLine("Insert City/Town: ");
            string cityAddress = Console.ReadLine();

            //Console.WriteLine("Insert State: ");
            //string stateAddress = Console.ReadLine();

            //Console.WriteLine("Insert city: ");
            //string countryAddress = Console.ReadLine();

            Console.WriteLine("Insert Zip Code: ");
            string zipcodeAddress = Console.ReadLine();

            Console.WriteLine("Insert Area Code: ");
            string areacodePhone = Console.ReadLine();

            //Console.WriteLine("Insert Country Code: ");
            //string countrycode = Console.ReadLine();

            Console.WriteLine("Insert ext.: ");
            string extension = Console.ReadLine();

            Console.WriteLine("Insert phone number: ");
            string numberPhone = Console.ReadLine();
            #endregion

            //Instance the class
            Person p = new Person();
            p.firstName = fname;
            p.lastName = lname;
            p.Pid = DateTime.Now.Ticks;
            p.address.houseNum = numAddress;
            p.address.Pid = p.Pid;
            p.address.street = streetAddress;
            p.address.city = cityAddress;
            p.address.state = State.NY;
            p.address.country = Country.US;
            p.address.zipCode = zipcodeAddress;
            p.phone.Pid = p.Pid;
            p.phone.areaCode = areacodePhone;
            p.phone.countryCode = Country.US;
            p.phone.ext = extension;
            p.phone.number = numberPhone;

            //adding to the list
            PersonMembers pm = p.CreatePM(); 
            contactList.Add(pm);

            //Serialize the information to my file
            System.Web.Script.Serialization.JavaScriptSerializer JSserializer;
            JSserializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string jsonstring = JSserializer.Serialize(contactList);
            ContactQuery.WritetoFile(jsonstring);

            Console.WriteLine("Contact successfully added");
        }

        //Delete contact method
        public static void deleteContact()
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter contact first name: ");
                    string name = Console.ReadLine();

                    PersonMembers temp = null;

                    foreach (PersonMembers p in contactList)
                    {
                        if (p.Name.Contains(name))
                        {
                            temp = p;
                        }
                    }

                    contactList.Remove(temp);
                    Console.WriteLine("Contact successfully removed");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nContact doesnt exist");
                }
            }
            while (true);
        }

        //Edit Contact
        public static void editContact()
        {
            Console.WriteLine("Enter first name to Edit: ");
            string name = Console.ReadLine();
            foreach (PersonMembers p in contactList)
            {
                if (p.Name.Contains(name))
                {
                    #region USERINPUTEDITS
                    Console.WriteLine("Insert first name: ");
                    string fname = Console.ReadLine();
                    Console.WriteLine("Insert last city: ");
                    string lname = Console.ReadLine();
                    Console.WriteLine("Insert Address: ");
                    string streetAddress = Console.ReadLine();
                    Console.WriteLine("Insert House Number: ");
                    string numAddress = Console.ReadLine();
                    Console.WriteLine("Insert City/Town: ");
                    string cityAddress = Console.ReadLine();
                    //Console.WriteLine("Insert State: ");
                    //string stateAddress = Console.ReadLine();
                    //Console.WriteLine("Insert city: ");
                    //string countryAddress = Console.ReadLine();
                    Console.WriteLine("Insert Zip Code: ");
                    string zipcodeAddress = Console.ReadLine();
                    Console.WriteLine("Insert Area Code: ");
                    string areacodePhone = Console.ReadLine();
                    //Console.WriteLine("Insert Country Code: ");
                    //string countrycode = Console.ReadLine();
                    Console.WriteLine("Insert ext.: ");
                    string extension = Console.ReadLine();
                    Console.WriteLine("Insert phone number: ");
                    string numberPhone = Console.ReadLine();
                    #endregion
                    //Instance the class
                    Person p = new Person();
                    p.firstName = fname;
                    p.lastName = lname;
                    p.Pid = DateTime.Now.Ticks;
                    p.address.houseNum = numAddress;
                    p.address.Pid = p.Pid;
                    p.address.street = streetAddress;
                    p.address.city = cityAddress;
                    p.address.state = State.NY;
                    p.address.country = Country.US;
                    p.address.zipCode = zipcodeAddress;
                    p.phone.Pid = p.Pid;
                    p.phone.areaCode = areacodePhone;
                    p.phone.countryCode = Country.US;
                    p.phone.ext = extension;
                    p.phone.number = numberPhone;
                    //adding to the list
                    PersonMembers pm = p.CreatePM();
                    contactList.Add(pm);
                    contactList.Remove(pm);
                    Console.WriteLine($"Address updated for {name}");
                }
                else
                {
                    Console.WriteLine($"Address for {name} count not be found.");
                }
            }
        }


        //Search contact method
        public static void searchContact()
        {

                    bool found = false;
                    Console.WriteLine("Enter first name: ");
                    string name = Console.ReadLine();

                    foreach (PersonMembers p in contactList)
                    {
                        if (p.Name.Contains(name))
                        {
                            Console.WriteLine(p.Print);
                            found = true;
                        }
                    }
                    if (found == false)
                    {

                        Console.WriteLine("Name does not exist");
                    }
        }

        //Show the list method
        public static void displayContact()
        {
            foreach (PersonMembers p in contactList)
            {
                Console.WriteLine(p.Print);
            }
        }

        public static void saveContact()
        {
            ContactQuery.WriteToSQL_DB(ContactQuery.JsonSerializer<List<PersonMembers>>(contactList));
        }

        public static void loadContact()
        {
            contactList = ContactQuery.JsonDeserialize<List<PersonMembers>>(ContactQuery.ReadFromSQL_DB());
        }
    }
}
    /*public static class DataAccess
    {
        // List for storing all contacts
        public static List<Person> contacts = new List<Person>();

        public static void Add(Person newPerson)
        {
            Person p1 = new Person();
            p1.firstName = "Tammy";
            p1.lastName = "Johnson";
            p1.Pid = DateTime.Now.Ticks;
            p1.address.houseNum = "121";
            p1.address.Pid = p1.Pid;
            p1.address.street = "1st";
            p1.address.city = "New York";
            p1.address.State = State.NY;
            p1.address.Country = Country.US;
            p1.address.zipcode = "10017";
            p1.phone.Pid = p1.Pid;
            p1.phone.areaCode = "204";
            p1.phone.countrycode = Country.US;
            p1.phone.ext = "";
            p1.phone.number = "564456";

            contacts.Add(newPerson);
        }

        public static void Edit(Person editedPerson)
        {
            long id = editedPerson.Pid;

            // Get the person with this id from contactList using a LINQ query
            var query = (from p in contacts
                         where p.Pid == editedPerson.Pid
                         select p).ToList();

            Person p = query[0];
            // Update the person in the contactList with the parameters of the editedPerson
            // OR
            // Replace the person in the contactList with the editedPerson
        }

        public static void Delete(int id)
        {
            // Get the person with this id from contactList using a LINQ query
            var query = (from p in contacts
                         where p.Pid == id
                         select p).ToList();

            Person p = query[0];

            contacts.Remove(p);
        }

        public static List<Person> Search(string query)
        {
            var query = (from p in contacts
                         where p.firstName == query
                         select p).ToList();

            return query;
        }
    }*/
