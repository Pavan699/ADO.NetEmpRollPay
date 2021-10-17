using System;

namespace ADOEmpRollPay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ADO.Net Program");
            Connection connection = new Connection();
            connection.DataBaseInfo();
            connection.GetAllPersonsDetails();
            connection.DeleteRecordfromPersons(1);
            connection.InsertUserDataIntoTable();
        }
    }
}
