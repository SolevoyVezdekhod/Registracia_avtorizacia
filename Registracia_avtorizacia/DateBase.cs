using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;




namespace Registracia_avtorizacia
{
    public class DateBase
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-VKTLJIF\SQLEXPRESS;Initial Catalog=Aviakompania;Integrated Security=True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }


        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        
        }


    }
}
