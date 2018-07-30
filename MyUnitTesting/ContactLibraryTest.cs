using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using ContactLibrary;

namespace MyUnitTesting
{
    public class ContactLibraryTest
    {
        public static List<Person> contactList = new List<Person>();
        private readonly ITestOutputHelper output;
        public static string fileTest = "ContactTest";
    }
}
