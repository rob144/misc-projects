using System;
using System.Data;

//To use MySQL connector
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PGAspNet
{
    public static class RMySqlDbHelper
    {
        private static string conString = @"server=localhost;
                                        user=root;
                                        database=photogallery1;
                                        port=3306;
                                        password=GiaaHlm4e;";

        private static MySqlConnection getConnection()
        {
            return new MySqlConnection(conString);
        }

        public static void insertTestData()
        {
            MySqlConnection con = getConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            
            con.Open();

            for (int i = 0; i <= 10; i++)
            {
                da.InsertCommand = new MySqlCommand(
                    @"INSERT INTO tbl_photos (title, file_ref, description)
                  VALUES ('Photo', 'tynesunrise.jpg', 'A photo of the Tyne Bridge')", con);
                da.InsertCommand.CommandTimeout = 5;
                da.InsertCommand.ExecuteNonQuery();
            }
            con.Close();
        }

        public static RDataResult getPhotos(){
            return getDataTable("tbl_photos");
        }

        public static RPhoto getPhoto(int id)
        {
            MySqlConnection con = getConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            RPhoto result = new RPhoto();

            da.SelectCommand = new MySqlCommand("SELECT * FROM tbl_photos WHERE id = " + id, con);
            da.SelectCommand.CommandTimeout = 5;

            try
            {
                con.Open();
                da.Fill(ds, "result");
                DataTable dt = ds.Tables[ds.Tables.IndexOf("result")];
                result = new RPhoto(
                    (int)dt.Rows[0]["id"], 
                    (string)dt.Rows[0]["title"],
                    (string)dt.Rows[0]["file_ref"],
                    (string)dt.Rows[0]["description"]
                );
                con.Close();
            }
            catch (Exception ex)
            {
                
            }

            return result;
        }

        public static RDataResult deletePhoto(int id)
        {
            RDataResult result = new RDataResult();
            MySqlConnection con = getConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            da.DeleteCommand = new MySqlCommand("DELETE FROM tbl_photos WHERE id = " + id, con);
            da.DeleteCommand.CommandTimeout = 5;

            try
            {
                con.Open();
                result.intResult = da.DeleteCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                result.err = ex.Message;
            }

            return result;
        }

        private static RDataResult getDataTable(string tblName)
        {
            RDataResult result = new RDataResult();
            MySqlConnection con = getConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            da.SelectCommand = new MySqlCommand("SELECT * FROM " + tblName, con);
            da.SelectCommand.CommandTimeout = 5;

            try
            {
                con.Open();
                da.Fill(ds, "result");
                result.dataTable = ds.Tables[ds.Tables.IndexOf("result")];
                con.Close();
            }
            catch (Exception ex)
            {
                result.err = ex.Message;
            }

            return result;
        }

        private static string dataTableToString(DataTable dt)
        {
            
            string s = "";

            foreach (DataRow row in dt.Rows)
            {
                s += "\nrow: \n";
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    s += (" item " + i + ":" + row[i]);
                }
            }

            return s;
        }

    }
}