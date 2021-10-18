using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADOEmpRollPay
{
    public class Connection
    {
        private SqlConnection conn;
        /// <summary>
        /// Constructor to establish Connection
        /// </summary>
        public Connection()
        {
            conn = new SqlConnection();
            string connString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            conn.ConnectionString = connString;
        }
        /// <summary>
        /// Method to check the database Information
        /// </summary>
        public bool DataBaseInfo()
        {
            bool flag = false;
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                Console.WriteLine("Database connection is succesfull & is opened !!");
                flag = true;
            }
            else
            {
                Console.WriteLine("Connection is not established !!");
            }
            Console.WriteLine("Data Source: " + conn.DataSource);
            Console.WriteLine("Connection State : " + conn.State);
            Console.WriteLine("Database : " + conn.Database);

            conn.Close();
            Console.WriteLine("Connection State : " + conn.State);
            return flag;
        }
        /// <summary>
        /// Method to get the details from Persons table
        /// </summary>
        internal void GetAllPersonsDetails()
        {
            SqlCommand cmd = new SqlCommand("Select * from Persons", conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("PersonID : " + dr["PersonID"].ToString());
                Console.WriteLine("FirstName : " + dr["FirstName"].ToString());
                Console.WriteLine("LastName : " + dr["LastName"].ToString());
                Console.WriteLine("Address : " + dr["Address"].ToString());               
            }
            dr.Close();
            conn.Close();
        }
        /// <summary>
        /// method to delete the records Persons table
        /// </summary>
        /// <param name="ID">persons id to delete</param>
        internal void DeleteRecordfromPersons(int ID)
        {
            string deleteQuery = "delete from Persons where PersonID=" + ID;
            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("Record Deleted Succesfully");
            }
            conn.Close();
        }
        /// <summary>
        /// method to insert the data into the 
        /// </summary>
        internal void InsertUserDataIntoTable()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_AddPersonDetails";

            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = "Pavan";
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = "N";
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = "Solpaur";           
            try
            {
                conn.Open();
                int recordUpdatedCnt = cmd.ExecuteNonQuery();
                if (recordUpdatedCnt > 0)
                {
                    Console.WriteLine("Record Inserted Successfully !!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR ::" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
