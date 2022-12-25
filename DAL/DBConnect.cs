using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect
    {
        private static DBConnect instance;

        public static DBConnect Instance
        {
            get { if (instance == null) instance = new DBConnect(); return DBConnect.instance; }
            private set { DBConnect.instance = value; }
        }

        private DBConnect() { }

        string conectionString = @"Server=103.95.197.121,9696;Database=NVH_14;User Id=DACNPM;Password=khoa19@itf";

        public DataTable ExcuteQuery(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
              
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(conectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                data = command.ExecuteNonQuery();

                connection.Close();

            }
            return data;
        }
        
        
    }
}
