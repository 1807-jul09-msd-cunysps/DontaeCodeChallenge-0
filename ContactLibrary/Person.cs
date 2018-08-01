using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ContactLibrary
{
    [DataContract]
    public enum State
    {
        NY, FL, VA, MD, SF, OH
    }
    [DataContract]
    public enum Country
    {
        US = 1, UK = 44, India = 91, Pakistan = 92, Australia = 61
    }
    [DataContract]
    public class Person
    {
        public Person()
        {
            /// Initialise the dependant objects
            address = new Address();
            phone = new Phone();
        }
        [DataMember]
        public long Pid { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public Address address { get; set; }
        [DataMember]
        public Phone phone { get; set; }
        public string Getname { get => firstName + " " + lastName; } 

        public override string ToString()
        {
            return $"\n{firstName} {lastName}\n{address.print()}\n{phone.print()}";
        }

        public PersonMembers CreatePM()
        {
            PersonMembers pm = new PersonMembers();

            pm.Address = this.address.print();
            pm.Number = this.phone.print();
            pm.Name = this.Getname;

            return pm; 
        }

        /*public List<Person> Get()
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


            Person p2 = new Person();
            p2.firstName = "Sammy";
            p2.lastName = "Demier";
            p2.Pid = DateTime.Now.Ticks;
            p2.address.houseNum = "123";
            p2.address.Pid = p2.Pid;
            p2.address.street = "21st";
            p2.address.city = "New York";
            p2.address.State = State.NY;
            p2.address.Country = Country.US;
            p2.address.zipcode = "10018";
            p2.phone.Pid = p2.Pid;
            p2.phone.areaCode = "289";
            p2.phone.countrycode = Country.US;
            p2.phone.ext = "";
            p2.phone.number = "456622";

            List<Person> p = new List<Person>();
            p.Add(p1);
            p.Add(p2);
            return p;
        }*/
    }

    [DataContract]
    public class Address
    {
        [DataMember]
        public long Pid { get; set; }
        [DataMember]
        public string houseNum { get; set; }
        [DataMember]
        public string street { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public State state { get; set; }
        [DataMember]
        public Country country { get; set; }
        [DataMember]
        public string zipCode { get; set; }

        public string print()
        {
            return $"{houseNum} {street}\n{city},{country} {state} {zipCode}";
        }
    }

    public class Phone
    {
        [DataMember]
        public long Pid { get; set; }
        [DataMember]
        public Country countryCode { get; set; }
        [DataMember]
        public string areaCode { get; set; }
        [DataMember]
        public string number { get; set; }
        [DataMember]
        public string ext { get; set; }

        public string print()
        {
            return $"{areaCode} {number}: {ext}";
        }
    }

    public class PersonMembers
    {
        //Data members. 
        private int iD = (int)ContactQuery.ID++;
        private string name;
        private string address;
        private string number;
        //Data properties. 
        public long ID { get => iD; }
        public string Name { set => name = value; get => name; }
        public string Address { set => address = value; get => address; }
        public string Number { set => number = value; get => number; }
        //Print property. 
        public string Print { get => $"ID: {iD}; {name} {address} {number}"; }
    }
}