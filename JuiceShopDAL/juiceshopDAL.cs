using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using JuiceShopEntities;
namespace JuiceShopDAL
{
    public class juiceshopDAL
    {
        private List<JuicePurchased> lst;

        public List<juice> GetJuiceFlavors()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                List<juice> lst = new List<juice>();


                con.ConnectionString = @"Data Source=IN-5CG0253HJ3\SQLEXPRESS;Initial Catalog=JuiceShop_DB;Integrated Security=True";

                SqlCommand cmd = new SqlCommand("select * from  juice", con);
                cmd.CommandType = CommandType.Text;

                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    juice j = new juice
                    {
                        juice_id = (int)sdr[0],
                        juice_flavor = sdr[1].ToString(),
                        price = (int)sdr[2],

                    };
                    lst.Add(j);
                }
                sdr.Close();

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void juicepurchase(int juice_id, int quantity)
        {

            SqlConnection con = new SqlConnection();


            List<JuicePurchased> lst = new List<JuicePurchased>();


            con.ConnectionString = @"Data Source=IN-5CG0253HJ3\SQLEXPRESS;Initial Catalog=JuiceShop_DB;Integrated Security=True";

            SqlCommand cmd = new SqlCommand("insert into JuicePurchased(juice_id,quantity) values(@jid,@qty)", con);
            con.Open();
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@jid", juice_id);
            cmd.Parameters.AddWithValue("@qty", quantity);

            SqlCommand cmd1 = new SqlCommand("update JuicePurchased set JuicePurchased.amount = jp.quantity * j.price from JuicePurchased jp inner join juice j on jp.juice_id = j.juice_id", con);
            cmd1.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();
        }


        public List<JuicePurchased>Alljuicepurchased()
        {
            List<JuicePurchased> lstjp = new List<JuicePurchased>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=IN-5CG0253HJ3\SQLEXPRESS;Initial Catalog=JuiceShop_DB;Integrated Security=True";

            SqlCommand cmd = new SqlCommand("select * from JuicePurchased", con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                JuicePurchased jp = new JuicePurchased
                {
                   
                    juice_id = (int)sdr[1],
                    quantity = (int)sdr[2],
                    amount = (int)sdr[3]
                };
                lstjp.Add(jp);
            }
            sdr.Close();
            con.Close();
            return lstjp;

        }


        public void cleardata()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = @"Data Source=IN-5CG0253HJ3\SQLEXPRESS;Initial Catalog=JuiceShop_DB;Integrated Security=True";
                SqlCommand cmd = new SqlCommand("delete from JuicePurchased", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }



    }
    }

       
    




