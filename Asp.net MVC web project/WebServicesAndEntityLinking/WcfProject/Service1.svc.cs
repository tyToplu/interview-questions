using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfProject
{

    public class Service1 : IService1
    {
        // yararlanilan proje:https://github.com/javixv/WCF-CRUD-MVC/tree/master
        // EF integre edemedigim icin duz sql connection kullandim.

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebServicesAndEntityLinking.Data;Integrated Security=true;");
        public bool DeleteRecord(int recordInfo)
        {
            con.Open();
            string query = "Delete from Record where id = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", recordInfo);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // eslesen ilk ismi siliyor.
        public bool DeleteRecordByName(string recordName)
        {
            con.Open();
            string query = "SELECT TOP 1 Id FROM Record WHERE Name = @Name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", recordName);
            var id = cmd.ExecuteScalar();
            con.Close();

            if (id != null)
            {
                con.Open();
                query = "DELETE FROM Record WHERE Id = @Id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res == 1;
            }
            else
            {
                return false;
            }
        }

        public bool FindById(int id)
        {
            con.Open();
            string query = "select * from Record where id = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                return true;
            }
            else { return false; }
        }

        public List<Record> GetAllRecord()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Record", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Record> RecordList = new List<Record>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Record record = new Record();
                    record.Id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                    record.Name = dt.Rows[i]["name"].ToString();
                    record.Age = Convert.ToInt32(dt.Rows[i]["age"].ToString());
                    record.Surname = dt.Rows[i]["surname"].ToString();

                    RecordList.Add(record);
                }
                con.Close();
            }

            return RecordList;
        }

        // returns all records containing the search string
        public List<Record> GetRecord(string RecordName)
        {
            List<Record> RecordList = new List<Record>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Record where name Like '%'+@Name+'%'", con);
                cmd.Parameters.AddWithValue("@Name", RecordName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Record record = new Record();
                        record.Id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                        record.Name = dt.Rows[i]["name"].ToString();
                        record.Age = Convert.ToInt32(dt.Rows[i]["age"].ToString());
                        record.Surname = dt.Rows[i]["surname"].ToString();

                        RecordList.Add(record);
                    }
                }
                con.Close();
            }
            return RecordList;
        }

        public Record GetRecordById(int id)
        {
            con.Open();
            string query = "select * from Record where id = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            int res = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Record record = new Record();
                record.Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                record.Name = dt.Rows[0]["name"].ToString();
                record.Age = Convert.ToInt32(dt.Rows[0]["age"].ToString());
                record.Surname = dt.Rows[0]["surname"].ToString();
                con.Close();
                return record;

            }
            return null;
        }
        public string InsertRecord(Record RecordInfo)
        {
            string strMessage = string.Empty;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Record(name,surname,age) values(@name,@surname,@age)", con);
            cmd.Parameters.AddWithValue("@name", RecordInfo.Name);
            cmd.Parameters.AddWithValue("@surname", RecordInfo.Surname);
            cmd.Parameters.AddWithValue("@age", RecordInfo.Age);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                strMessage = RecordInfo.Name + " inserted successfully";
            }
            else
            {
                strMessage = RecordInfo.Name + " not inserted successfully";
            }
            con.Close();
            return strMessage;
        }

        public bool UpdateRecord(Record RecordId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Record SET name = @Name, age = @Age WHERE id = @ID", con);
            cmd.Parameters.AddWithValue("@ID", RecordId.Id);
            cmd.Parameters.AddWithValue("@Name", RecordId.Name);
            cmd.Parameters.AddWithValue("@Age", RecordId.Age);
            cmd.Parameters.AddWithValue("@Surname", RecordId.Surname);

            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }

}
