using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TrumpSystem
{
    class Program
    {
        const string connection_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\GitHub\\TrumpSystem\\TrumpSystem\\TrumpSystem\\TrumpMe.mdf;Integrated Security=True";
        const string fakeNewsTableName = "Fake_News";
        const string reportersTableName = "Reporters";

        static void Main(string[] args)
        {
            SqlConnection connect = new SqlConnection(connection_string);
            connect.Open();
            string answer = "";
            while(!answer.Equals("quit"))
            {
                Console.WriteLine("What would you like to do, Mr. Trump?");
                answer =Console.ReadLine();
                switch (answer)
                {
                    case "list reporters":
                        PrintAllListReporters(connect);
                        break;
                    case "insert reporter":
                        NewReporter(connect);
                        break;
                    case "insert news":
                        InsertNewFakeNews(connect);
                        break;

                }
                
            }
            connect.Close();
        }

        private static void InsertNewFakeNews(SqlConnection connect)
        {
            
        }

        private static void NewReporter(SqlConnection connect)
        {
            Console.WriteLine("Please enter the reporter's first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter the reporter's last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter the reporter's address");
            string address = Console.ReadLine();
            InsertNewReporter(connect, firstName, lastName, address);
        }

        private static void InsertNewReporter(SqlConnection connect,string firstName, string lastName, string address)
        {
            SqlCommand command = connect.CreateCommand();
            command.CommandText = "INSERT INTO "+ reportersTableName + " VALUES ('"+firstName+"','"+lastName+"','"+address+"');";
            command.ExecuteNonQuery();
        }

        public static void CreateReportersTable(SqlConnection connect)
        {
            SqlCommand command = connect.CreateCommand();
            command.CommandText = "CREATE TABLE " + reportersTableName + " (Id int IDENTITY(1,1) PRIMARY KEY,FirstName varchar(255),LastName varchar(255),Address varchar(255));";
            command.ExecuteNonQuery();
        }

        private static void CreateFakeNewsTable(SqlConnection connect)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connect;
            command.CommandText = "CREATE TABLE " + fakeNewsTableName + " (Id int IDENTITY(1,1) PRIMARY KEY,Title varchar(255),ReporterId int FOREIGN KEY REFERENCES Reporters(Id));";
            command.ExecuteNonQuery();
        }

        private static void PrintAllListReporters(SqlConnection connect)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connect;
            command.CommandText = "SELECT * FROM " + reportersTableName + ";";
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine(reader.GetString(2));
                Console.WriteLine(reader.GetString(3));
            }
            reader.Close();
        }
    }
}
