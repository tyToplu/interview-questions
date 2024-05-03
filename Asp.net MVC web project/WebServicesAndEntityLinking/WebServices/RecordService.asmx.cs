using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace WebServices
{
    /// <summary>
    /// Summary description for RecordService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RecordService : System.Web.Services.WebService
    {
        private const string ConnectionString = "YourConnectionString";

        [WebMethod]
        public string Add()
        {
            try
            {
                string result = "";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Record", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Process data from the database
                        result += reader["ColumnName"].ToString() + " ";
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                result = "Error: " + ex.Message;
            }

            return "Hello World";
        }
    }
}
