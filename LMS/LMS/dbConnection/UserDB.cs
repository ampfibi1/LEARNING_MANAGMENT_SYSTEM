using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.dbConnection
{
    public class UserDB
    {
        private readonly string connString = @"Data Source=ABDULLAH-TAMJID\SQLEXPRESS01;Initial Catalog=LMS_TEST;Integrated Security=True";

        public bool UpdateProfilePicture(int userId, string imageLocation)
        {
            try
            {
                byte[] img = File.ReadAllBytes(imageLocation);

                string query = $"UPDATE user_info SET profile_pic = @img WHERE id = {userId}";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@img", img);
                    int res = cmd.ExecuteNonQuery();
                    return res > 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void update_info(string query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int res = cmd.ExecuteNonQuery();
                if (res == 0)
                    MessageBox.Show("not update.");
                else
                {
                    MessageBox.Show("updated successfully.");
                }
                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public MemoryStream load_image(int userId)
        {
            string query = $"SELECT profile_pic FROM user_info WHERE id = {userId}";
            try
            {
                SqlConnection con = new SqlConnection(connString);

                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    byte[] imgData = (byte[])reader["profile_pic"];
                    return new MemoryStream(imgData);
                }
                else
                {
                    MessageBox.Show("No image found for this ID.");
                    return null;
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    
        public bool display_mode_search(int userId)
        {
            try
            {
                string query = $"select display_mode from user_info where id ={userId}";
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int mode = (int)reader["display_mode"];
                    return (mode == 1 ? true : false);
                }
                else
                {
                    MessageBox.Show("No mode found");
                    return true;
                }
                con.Close();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return true;
        }
    }
}
