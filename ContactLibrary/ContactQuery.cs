using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace ContactLibrary
{
    public static class ContactQuery
    {
        private static string myFile = "D:\\Training\\Project0.5\\ContactLibrary\\TheContacts.txt";
        private static string connectionString = "Server=tcp:dontaeserver.database.windows.net,1433;Initial Catalog=ContactDB;Persist Security Info=False;User ID=dontae;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        private static string loadStringQuery = "SELECT * FROM ContactTable";
        private static string delStringQuery = "DELETE FROM ContactTable";
        private static string saveStringQuery = "INSERT INTO ContactTable (JsonData) VALUES(Convert(VARBINARY(MAX), '";
        private static string saveStringQuery_2 = "'));";
        public static int ID = (int)DateTime.Now.Ticks;

        public static void WritetoFile(string content)
        {
            System.IO.File.WriteAllText(myFile, content);
        }

        public static string ReadFromFile()
        {
            return System.IO.File.ReadAllText(myFile);
        }

        //Method for serializing in Json, which also returns a Json in string. 
        public static string JsonSerializer<T>(T t)
        {
            string jsonstring = new JavaScriptSerializer().Serialize(t);
            ContactQuery.WritetoFile(jsonstring); 
            WriteToSQL_DB(jsonstring);
            ContactQuery.WritetoFile(jsonstring);
            return jsonstring;
        }

        //Method for deserializing in Json, which also returns that same T object. 
        public static T JsonDeserialize<T>(string jsonstring)
        {
            //string jsonstring = ContactQuery.ReadFromFile(); 
            //string jsonstring = ReadFromSQL_DB();
            JavaScriptSerializer deserializer = new JavaScriptSerializer();
            return deserializer.Deserialize<T>(jsonstring);
        }

        public static string ReadFromSQL_DB()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(loadStringQuery, connection);
                try
                {
                    connection.Open();
                    byte[] hash = (byte[])command.ExecuteScalar();
                    return Encoding.ASCII.GetString(hash);
                }
                catch (Exception e) { Console.WriteLine($"Error {e.ToString()}"); }
            }
            return null;
        }

        public static void WriteToSQL_DB(string jsonString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string fullSaveQuery = saveStringQuery + jsonString + saveStringQuery_2;
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    connection.Open();
                    adapter.InsertCommand = new SqlCommand(delStringQuery, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.InsertCommand = new SqlCommand(fullSaveQuery, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception e) { Console.WriteLine($"Error {e.ToString()}"); }
            }
        }

    }
}
