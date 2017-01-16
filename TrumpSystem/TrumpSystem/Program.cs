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
        const string name_of_table1 = "Fake News";
        const string name_of_table2 = "Reporters";

        static void Main(string[] args)
        {
            SqlConnection connect = new SqlConnection(connection_string);
            connect.Open();
            CreateTable(connect);
            /*string answer = "";
            while(!answer.Equals("quit"))
            {
                Console.WriteLine("What would you like to do, Mr. Trump?");
                answer =Console.ReadLine();
                if (answer.Equals("list reporters"))
                {

                }
                //CreateTable(connect);
                //Insert(connect, "Bohemian Rhapsody", "Queen", 1975);
                //Insert(connect, "Do I Wanna Know", "Arctic Monkeys", 2013);
                //Insert(connect, "Dancing Shoes", "Arctic Monkeys", 2006);
                //Insert(connect, "Wolves of Winter", "Biffy Clyro", 2016);
                //Select(connect);
            }*/
            connect.Close();
        }

        public static void CreateTable(SqlConnection connect)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connect;
     
            command.CommandText = "CREATE TABLE " + name_of_table2 + " (Id IDENTITY(1,1) int PRIMARY KEY,FirstName varchar(255),LastName varchar(255),Address varchar(255));";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE " + name_of_table1 + " (Id IDENTITY(1,1) int PRIMARY KEY,Title varchar(255),ReporterId int FOREIGN KEY REFERENCES Reporters(Id));";
            command.ExecuteNonQuery();
        }
    }
}
